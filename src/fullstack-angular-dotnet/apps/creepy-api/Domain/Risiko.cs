namespace CreepyApi.Domain;

public enum Risiko
{
    Gering = 1,
    Mittel = 2
}

public static class RisikoHelper
{
    public static Risiko Parse(string risiko)
    {
        switch (risiko)
        {
            case "Gering": return Risiko.Gering;
            case "Mittel": return Risiko.Mittel;
            default: throw new ArgumentException($"{risiko} ist kein gültiger Wert");
        }
    }
}