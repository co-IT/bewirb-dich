using Api.Domain;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Controller]
    public class DokumenteController : Controller
    {
        public Logger<DokumenteController> logger;

        public DokumenteController(ILoggerFactory loggerFactory)
        {
            logger = new Logger<DokumenteController>(loggerFactory);
        }
        
        [HttpGet]
        [Route("/Dokumente")]
        public ActionResult<IEnumerable<Dokument>> DokumenteAbrufen()
        {
            var service = DokumenteService.Instance;

            var okResult = new OkObjectResult(service.List());
            
            return okResult;
        }
        
        [HttpGet]
        [Route("/Dokumente/{id}")]
        public Dokument DokumentFinden([FromRoute] Guid id)
        {
            var dokument = DokumenteService.Instance.Find(id);

            if (dokument == null)
            {
                logger.LogError("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
                throw new ArgumentNullException("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
            }
            else
            {
                return dokument;
            }
        }
        
        [HttpPost]
        [Route("/Dokumente/Erstellen")]
        public ActionResult DokumenteErstellen([FromBody] CreateDokumentDto dto)
        {
            var service = DokumenteService.Instance;

            if (dto.Versicherungssumme < 0)
            {
                throw new ArgumentOutOfRangeException("Die Versicherungssumme darf nicht negativ sein.");
            }

            if (dto.ZusatzschutzAufschlag < 0)
            {
                throw new ArgumentOutOfRangeException("Der Zusatzschutzaufschlag darf nicht negativ sein.");
            }

            var dokument = Dokument.Create();
            dokument.InkludiereZusatzschutz = dto.InkludiereZusatzschutz;
            dokument.HatWebshop = dto.HatWebshop;
            dokument.VersicherungsscheinAusgestellt = dto.VersicherungsscheinAusgestellt;
            dokument.Risiko = dto.Risiko;
            dokument.Berechnungbasis = dto.Berechnungbasis;
            dokument.Beitrag = dto.Beitrag;
            dokument.Versicherungssumme = dto.Versicherungssumme;
            dokument.ZusatzschutzAufschlag = dto.ZusatzschutzAufschlag;
            dokument.Typ = dto.Typ;
            dokument.Berechnungsart = dto.Berechnungsart;
            
            Kalkuliere(dokument);
            
            service.Add(dokument);
            service.Save();

            return CreatedAtAction("DokumentFinden", "Dokumente", new { Id = dokument.Id }, dokument);
        }
        
        [HttpPatch]
        [Route("/Dokumente/{id}")]
        public ActionResult DokumenteAktualisieren([FromRoute] Guid id, [FromBody] UpdateDokumentDto updatedDokument)
        {
            var service = DokumenteService.Instance;

            if (updatedDokument.Versicherungssumme < 0)
            {
                throw new ArgumentOutOfRangeException("Die Versicherungssumme darf nicht negativ sein.");
            }

            if (updatedDokument.ZusatzschutzAufschlag < 0)
            {
                throw new ArgumentOutOfRangeException("Der Zusatzschutzaufschlag darf nicht negativ sein.");
            }

            var dokument = service.Find(id);

            if (dokument == null)
            {
                logger.LogError("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
                throw new ArgumentException("Das Dokument mit der Id " + id + " konnte nicht gefunden werden.");
            }

            dokument.InkludiereZusatzschutz = updatedDokument.InkludiereZusatzschutz;
            dokument.HatWebshop = updatedDokument.HatWebshop;
            dokument.VersicherungsscheinAusgestellt = updatedDokument.VersicherungsscheinAusgestellt;
            dokument.Risiko = updatedDokument.Risiko;
            dokument.Berechnungbasis = updatedDokument.Berechnungbasis;
            dokument.Beitrag = updatedDokument.Beitrag;
            dokument.Versicherungssumme = updatedDokument.Versicherungssumme;
            dokument.ZusatzschutzAufschlag = updatedDokument.ZusatzschutzAufschlag;
            dokument.Typ = updatedDokument.Typ;
            dokument.Berechnungsart = updatedDokument.Berechnungsart;

            Kalkuliere(dokument);

            service.Save();

            return new AcceptedResult();
        }
        
        [HttpPost]
        [Route("/Dokumente/{id}/annehmen")]
        public ActionResult DokumentAnnehmen([FromRoute] Guid id)
        {
            var service = DokumenteService.Instance;

            var dokument = service.Find(id);

            if (dokument == null)
            {
                logger.LogError("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
                throw new ArgumentException("Das Dokument mit der Id " + id + " konnte nicht gefunden werden.");
            }

            dokument.Typ = Dokumenttyp.Versicherungsschein;
            service.Save();

            return new AcceptedResult();
        }
        
        [HttpPost]
        [Route("/Dokumente/{id}/ausstellen")]
        public ActionResult DokumentAusstellen([FromRoute] Guid id)
        {
            var service = DokumenteService.Instance;

            var dokument = service.Find(id);

            if (dokument == null)
            {
                logger.LogError("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
                throw new ArgumentException("Das Dokument mit der Id " + id + " konnte nicht gefunden werden.");
            }

            if (dokument.Typ != Dokumenttyp.Versicherungsschein)
            {
                throw new ArgumentException("Nur ein Versicherungsschein kann ausgestellt werden.");
            }
            dokument.VersicherungsscheinAusgestellt = true;
            service.Save();

            return new AcceptedResult();
        }
        
        [HttpDelete]
        [Route("/Dokumente/{id}")]
        public void DokumentEntfernen([FromRoute] Guid id)
        {
            var service = DokumenteService.Instance;
                
            var dokument = service.Find(id);

            if (dokument == null)
            {
                logger.LogError("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
                throw new ArgumentNullException("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
            }
            
            service.Delete(dokument);
            service.Save();
        }
        
        private void Kalkuliere(Dokument dokument)
        {
            //Versicherungsnehmer, die nach Haushaltssumme versichert werden (primär Vereine) stellen immer ein mittleres Risiko da
            if (dokument.Berechnungsart == Berechnungsart.Haushaltssumme)
            {
                dokument.Risiko = Risiko.Mittel;
            }

            //Versicherungsnehmer, die nach Anzahl Mitarbeiter abgerechnet werden und mehr als 5 Mitarbeiter haben, können kein Lösegeld absichern
            if (dokument.Berechnungsart == Berechnungsart.AnzahlMitarbeiter)
                if (dokument.Berechnungbasis > 5)
                {
                    dokument.InkludiereZusatzschutz = false;
                    dokument.ZusatzschutzAufschlag = 0;
                }

            //Versicherungsnehmer, die nach Umsatz abgerechnet werden, mehr als 100.000€ ausweisen und Lösegeld versichern, haben immer mittleres Risiko
            if (dokument.Berechnungsart == Berechnungsart.Umsatz)
                if (dokument.Berechnungbasis > 100000m && dokument.InkludiereZusatzschutz)
                {
                    dokument.Risiko = Risiko.Mittel;
                }

            decimal beitrag;
            switch (dokument.Berechnungsart)
            {
                case Berechnungsart.Umsatz:
                    var faktorUmsatz  = (decimal) Math.Pow((double)dokument.Versicherungssumme, 0.25d);
                    beitrag = 1.1m + faktorUmsatz * (dokument.Berechnungbasis / 100000);
                    if (dokument.HatWebshop) //Webshop gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
                        beitrag *= 2;
                    break;
                case Berechnungsart.Haushaltssumme:
                    var faktorHaushaltssumme = (decimal)Math.Log10((double) dokument.Versicherungssumme);
                    beitrag = 1.0m + faktorHaushaltssumme * dokument.Berechnungbasis + 100m;
                    break;
                case Berechnungsart.AnzahlMitarbeiter:
                    var faktorMitarbeiter = dokument.Versicherungssumme / 1000;

                    if (dokument.Berechnungbasis < 4)
                        beitrag = faktorMitarbeiter +  dokument.Berechnungbasis * 250m;
                    else
                        beitrag = faktorMitarbeiter + dokument.Berechnungbasis * 200m;

                    break;
                default:
                    throw new Exception();
            }

            if (dokument.InkludiereZusatzschutz)
                beitrag *= 1.0m + (decimal) dokument.ZusatzschutzAufschlag / 100.0m;

            if (dokument.Risiko == Risiko.Mittel)
            {
                if (dokument.Berechnungsart is Berechnungsart.Haushaltssumme or Berechnungsart.Umsatz)
                    beitrag *= 1.2m;
                else
                    beitrag *= 1.3m;
            }

            dokument.Berechnungbasis = Math.Round(dokument.Berechnungbasis, 2);
            dokument.Beitrag = Math.Round(beitrag, 2);
        }
    }
    
    

    public class UpdateDokumentDto
    {
        public Dokumenttyp Typ { get; set; }
        public Berechnungsart Berechnungsart { get; set; }
        public decimal Berechnungbasis { get; set; }
        public bool InkludiereZusatzschutz { get; set; }
        public float ZusatzschutzAufschlag { get; set; }
        public bool HatWebshop { get; set; }
        public Risiko Risiko { get; set; }
        public decimal Beitrag { get; set; }
        public bool VersicherungsscheinAusgestellt { get; set; }
        public decimal Versicherungssumme { get; set; }
    }

    public class CreateDokumentDto
    {
        public Dokumenttyp Typ { get; set; }
        public Berechnungsart Berechnungsart { get; set; }
        public decimal Berechnungbasis { get; set; }
        public bool InkludiereZusatzschutz { get; set; }
        public float ZusatzschutzAufschlag { get; set; }
        public bool HatWebshop { get; set; }
        public Risiko Risiko { get; set; }
        public decimal Beitrag { get; set; }
        public bool VersicherungsscheinAusgestellt { get; set; }
        public decimal Versicherungssumme { get; set; }
    }
}