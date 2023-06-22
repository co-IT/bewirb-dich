export interface Dokument {
  id: string;
	typ: Dokumententyp;
	berechnungsart: Berechnungsart;
	
	// Berechnungsart Umsatz => Jahresumsatz in Euro,
	// Berechnungsart Haushaltssumme => Haushaltssumme in Euro,
	// Berechnungsart AnzahlMitarbeiter => Ganzzahl
	
  berechnungbasis: number;
	inkludiereZusatzschutz: boolean;
	zusatzschutzAufschlag: number
	//Gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
	hatWebshop: boolean;
	risiko: Risiko
	beitrag: number;
	versicherungsscheinAusgestellt: boolean;
	versicherungssumme: number;

}

export enum Dokumententyp {
	VERSICHERUNGSSCHEIN = 2,
	ANGEBOT = 1,
}

export enum Berechnungsart
{
    Umsatz = 1,
    Haushaltssumme = 2,
    AnzahlMitarbeiter = 3
}

export enum Risiko
{
    Gering = 1,
    Mittel = 2
}