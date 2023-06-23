export interface DokumentenlisteEintragDto {
  id: string;
  dokumenttyp: string;
  berechnungsart: string;
  zusatzschutz: string
  webshopVersichert: boolean;
  risiko: string;
  versicherungssumme: number;
  beitrag: number;
  kannAngenommenWerden: boolean;
  kannAusgestelltWerden: boolean;
}

export interface ErzeugeNeuesAngebotDto {
  berechnungsart: string;
  willZusatzschutz: boolean;
  zusatzschutzAufschlag: string;
  hatWebshop: boolean;
  risiko: string;
  versicherungssumme: number;
}
