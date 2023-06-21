interface Algorithmen {
  berechneDurchschnittlichenLagerbestand(): number;
  berechneInventurPreis(): number;
}

class LagerbestandsService {
  constructor(private readonly lagerAlgorithmus: Algorithmen) {}

  public BewerteDurchschnittlichenLagerbestand(): number {
    return this.lagerAlgorithmus.berechneDurchschnittlichenLagerbestand() * 10;
  }
}
