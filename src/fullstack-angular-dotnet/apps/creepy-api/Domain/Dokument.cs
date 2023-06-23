using Newtonsoft.Json;

namespace CreepyApi.Domain;

public class Dokument
{
    [JsonProperty]
    public Guid Id { get; private set; }

    public Dokumenttyp Typ { get; set; }
    public Berechnungsart Berechnungsart { get; set; }
    /// <summary>
    /// Berechnungsart Umsatz => Jahresumsatz in Euro,
    /// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
    /// Berechnungsart AnzahlMitarbeiter => Ganzzahl
    /// </summary>
    public decimal Berechnungbasis { get; set; }

    public bool InkludiereZusatzschutz { get; set; }
    public float ZusatzschutzAufschlag { get; set; }

    //Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
    public bool HatWebshop { get; set; }

    public Risiko Risiko { get; set; }

    public decimal Beitrag { get; set; }

    public bool VersicherungsscheinAusgestellt { get; set; }
    public decimal Versicherungssumme { get; set; }

    [System.Text.Json.Serialization.JsonConstructor]
    private Dokument()
    {

    }

    public static Dokument Create()
    {
        var dokument = new Dokument();

        dokument.Id = Guid.NewGuid();

        return dokument;
    }
}
