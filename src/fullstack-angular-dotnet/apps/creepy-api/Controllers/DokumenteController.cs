using CreepyApi.Domain;
using CreepyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CreepyApi.Controllers;

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
  public ActionResult<IEnumerable<DokumentenlisteEintragDto>> DokumenteAbrufen()
  {
    var service = DokumenteService.Instance;

    var okResult = new OkObjectResult(service.List().Select(dokument => MapToDto(dokument)));

    return okResult;
  }

  private DokumentenlisteEintragDto MapToDto(Dokument dokument)
  {
    return new DokumentenlisteEintragDto()
    {
      Id = dokument.Id,
      Beitrag = dokument.Beitrag,
      Berechnungsart = Enum.GetName(typeof(Berechnungsart), dokument.Berechnungsart)!,
      Dokumenttyp = Enum.GetName(typeof(Dokumenttyp), dokument.Typ),
      Risiko = Enum.GetName(typeof(Risiko), dokument.Risiko)!,
      Versicherungssumme = dokument.Versicherungssumme,
      Zusatzschutz = $"{dokument.ZusatzschutzAufschlag}%",
      WebshopVersichert = dokument.HatWebshop,
      KannAngenommenWerden = !dokument.VersicherungsscheinAusgestellt && dokument.Typ == Dokumenttyp.Angebot,
      KannAusgestelltWerden = !dokument.VersicherungsscheinAusgestellt && dokument.Typ == Dokumenttyp.Versicherungsschein
    };
  }

  [HttpGet]
  [Route("/Dokumente/{id}")]
  public DokumentenlisteEintragDto DokumentFinden([FromRoute] Guid id)
  {
    var dokument = DokumenteService.Instance.Find(id);

    if (dokument == null)
    {
      logger.LogError("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
      throw new ArgumentNullException("Das Dokument mit der ID " + id + " konnte nicht gefunden werden.");
    }
    else
    {
      return MapToDto(dokument);
    }
  }

  [HttpPost]
  [Route("/Dokumente")]
  public ActionResult DokumenteErstellen([FromBody] ErzeugeNeuesAngebotDto dto)
  {
    var service = DokumenteService.Instance;

    if (dto.Versicherungssumme < 0)
    {
      throw new ArgumentOutOfRangeException("Die Versicherungssumme darf nicht negativ sein.");
    }

    if (string.IsNullOrWhiteSpace(dto.ZusatzschutzAufschlag))
    {
      dto.ZusatzschutzAufschlag = "0%";
    }

    if (dto.ZusatzschutzAufschlag.StartsWith("-"))
    {
      throw new ArgumentOutOfRangeException("Der Zusatzschutzaufschlag darf nicht negativ sein.");
    }

    var dokument = Dokument.Create();
    dokument.InkludiereZusatzschutz = dto.WillZusatzschutz;
    dokument.HatWebshop = dto.HatWebshop;
    dokument.VersicherungsscheinAusgestellt = false;
    dokument.Risiko = RisikoHelper.Parse(dto.Risiko);
    dokument.Versicherungssumme = dto.Versicherungssumme;
    dokument.ZusatzschutzAufschlag = float.Parse(dto.ZusatzschutzAufschlag.Replace("%", ""));
    dokument.Typ = Dokumenttyp.Angebot;
    dokument.Berechnungsart = BerechnungsartHelper.Parse(dto.Berechnungsart);

    Kalkuliere(dokument);

    service.Add(dokument);
    service.Save();

    return Ok();
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

public class ErzeugeNeuesAngebotDto
{
  public bool HatWebshop { get; init; }
  public string Berechnungsart { get; init; }
  public string Risiko { get; init; }
  public bool WillZusatzschutz { get; init; }
  public string ZusatzschutzAufschlag { get; set; }
  public decimal Versicherungssumme { get; init; }
}

public class DokumentenlisteEintragDto
{
  public Guid Id { get; init; }
  public string Dokumenttyp { get; init; }
  public string Berechnungsart { get; init; }
  public string Risiko { get; init; }
  public string Zusatzschutz { get; init; }
  public bool WebshopVersichert { get; init; }
  public decimal Versicherungssumme { get; init; }
  public decimal Beitrag { get; init; }
  public bool KannAngenommenWerden { get; init; }
  public bool KannAusgestelltWerden { get; init; }
}
