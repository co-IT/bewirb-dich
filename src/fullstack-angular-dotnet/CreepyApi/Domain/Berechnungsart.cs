namespace Api.Domain;

public enum Berechnungsart
{
    Umsatz = 1,
    Haushaltssumme = 2,
    AnzahlMitarbeiter = 3
}

public static class BerechnungsartHelper
{
    public static Berechnungsart Parse(string berechnungsart)
    {
        switch (berechnungsart)
        {
            case "Umsatz": return Berechnungsart.Umsatz;
            case "Haushaltssumme": return Berechnungsart.Haushaltssumme;
            case "AnzahlMitarbeiter": return Berechnungsart.AnzahlMitarbeiter;
            default: throw new ArgumentException($"{berechnungsart} ist kein gültiger Wert");
        }
    }
}