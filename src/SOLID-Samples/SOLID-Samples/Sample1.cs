namespace SOLID_Samples;

internal class Sample1
{
    private interface IAlgorithmen
    {
        double BerechneDurchschnittlichenLagerbestand();
        double BerechneInventurPreis();
    }

    private class LagerbestandsService
    {
        private readonly IAlgorithmen _lagerAlgorithmus;

        public LagerbestandsService(IAlgorithmen lagerAlgorithmus)
        {
            _lagerAlgorithmus = lagerAlgorithmus;
        }

        public double BewerteDurchschnittlichenLagerbestand()
        {
            return _lagerAlgorithmus.BerechneDurchschnittlichenLagerbestand() * 10;
        }
    }
}