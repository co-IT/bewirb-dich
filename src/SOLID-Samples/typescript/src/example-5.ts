class LagerortSuche {
  constructor(
    private readonly artikelZuLagerortDictionary: Record<string, string>
  ) {}

  findeLagerortFürArtikel(artikel: string): string {
    return !!this.artikelZuLagerortDictionary[artikel]
      ? this.artikelZuLagerortDictionary[artikel]
      : '';
  }
}

class ErweiterteLagerortSuche extends LagerortSuche {
  constructor(
    private readonly artikelZuAußenlagerDictionary: Record<string, string>,
    artikelZuLagerortDictionary: Record<string, string>
  ) {
    super(artikelZuLagerortDictionary);
  }

  findeLagerortFürArtikel(artikel: string): string {
    var lagerSuche = this.findeLagerortFürArtikel(artikel);

    if (!!lagerSuche) {
      return lagerSuche;
    }

    if (!!this.artikelZuAußenlagerDictionary[artikel]) {
      return this.artikelZuAußenlagerDictionary[artikel];
    }

    throw new Error('Artikel konnte nicht gefunden werden');
  }
}
