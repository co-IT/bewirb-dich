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