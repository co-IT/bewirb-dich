namespace coIT.BewirbDich.Winforms.Domain;

public class Dokument
{
    public Guid Id { get; }

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

    public Dokument()
    {
        Id = Guid.NewGuid();
    }
}