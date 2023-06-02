namespace SOLID_Samples;

internal class Sample5
{
    private class ErweiterteLageortSuche : LagerortSuche
    {
        private readonly Dictionary<string, string> _artikelZuAußenlagerDictionary;

        public ErweiterteLageortSuche(Dictionary<string, string> artikelZuAußenlagerDictionary,
            Dictionary<string, string> artikelZuLagerortDictionary)
            : base(artikelZuLagerortDictionary)
        {
            _artikelZuAußenlagerDictionary = artikelZuAußenlagerDictionary;
        }

        public override string FindeLagerortFürArtikel(string artikel)
        {
            var lagerSuche = base.FindeLagerortFürArtikel(artikel);
            if (lagerSuche != string.Empty)
                return lagerSuche;

            if (_artikelZuAußenlagerDictionary.ContainsKey(artikel))
                return _artikelZuAußenlagerDictionary[artikel];

            throw new Exception("Artikel konnte nicht gefunden werden");
        }
    }

    private class LagerortSuche
    {
        private readonly Dictionary<string, string> _artikelZuLagerortDictionary;

        public LagerortSuche(Dictionary<string, string> artikelZuLagerortDictionary)
        {
            _artikelZuLagerortDictionary = artikelZuLagerortDictionary;
        }

        public virtual string FindeLagerortFürArtikel(string artikel)
        {
            return _artikelZuLagerortDictionary.ContainsKey(artikel)
                ? _artikelZuLagerortDictionary[artikel]
                : string.Empty;
        }
    }
}