enum Angebotstyp {
  Umsatz,
  Haushaltssumme,
  AnzahlMitarbeiter
}

class Angebot {
  constructor(
    private readonly angebotstyp: Angebotstyp,
    private readonly versicherungssumme: number
  ) {
    angebotstyp = angebotstyp;
    versicherungssumme = versicherungssumme;
  }

  berechneBeitrag(): number {
    if (this.angebotstyp == Angebotstyp.Haushaltssumme)
      return Math.log10(this.versicherungssumme) + 100;

    if (this.angebotstyp == Angebotstyp.Umsatz)
      return Math.pow(this.versicherungssumme, 0.25) * 1.1;

    return this.versicherungssumme / 4;
  }
}
