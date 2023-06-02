namespace SOLID_Samples;

internal class Sample2
{
    private enum Angebotstyp
    {
        Umsatz,
        Haushaltssumme,
        AnzahlMitarbeiter
    }

    private class Angebot
    {
        private readonly Angebotstyp _angebotstyp;
        private readonly int _versicherungssumme;

        public Angebot(Angebotstyp angebotstyp, int versicherungssumme)
        {
            _angebotstyp = angebotstyp;
            _versicherungssumme = versicherungssumme;
        }

        public double BerechneBeitrag()
        {
            if (_angebotstyp == Angebotstyp.Haushaltssumme)
                return Math.Log10(_versicherungssumme) + 100;

            if (_angebotstyp == Angebotstyp.Umsatz)
                return Math.Pow(_versicherungssumme, 0.25d) * 1.1d;

            return _versicherungssumme / 4d;
        }
    }
}