using coIT.BewirbDich.Winforms.Domain;

namespace coIT.BewirbDich.Winforms.UI
{
    public partial class Form_NeueKalkulation : Form
    {
        public Domain.Dokument Kalkulation { get; set; }

        public Form_NeueKalkulation()
        {
            InitializeComponent();
        }

        private void ctrl_Abbrechen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ctrl_Kalkuliere_Click(object sender, EventArgs e)
        {
            var kalkulation = new Dokument();
            kalkulation.Typ = Dokumenttyp.Angebot;
            kalkulation.Berechnungsart = (Berechnungsart)Enum.Parse(typeof(Berechnungsart), ctrl_Berechnungsart.Text);
            kalkulation.Risiko = (Risiko)Enum.Parse(typeof(Risiko), ctrl_Risiko.Text);
            kalkulation.InkludiereZusatzschutz = ctrl_InkludiereZusatzschutz.Checked;
            if (float.TryParse(ctrl_ZusatzschutzAufschlag.Text.Replace("%", string.Empty), out var zuschlag))
                kalkulation.ZusatzschutzAufschlag = zuschlag;
            else
                kalkulation.ZusatzschutzAufschlag = 0;
            kalkulation.HatWebshop = ctrl_HatWebshop.Checked;
            kalkulation.Versicherungssumme = decimal.Parse(ctrl_Versicherungssumme.Text);

            Kalkuliere(kalkulation);

            Kalkulation = kalkulation;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void Kalkuliere(Dokument dokument)
        {
            //Versicherungsnehmer, die nach Haushaltssumme versichert werden (primär Vereine) stellen immer ein mittleres Risiko da
            if (dokument.Berechnungsart == Berechnungsart.Haushaltssumme)
            {
                ctrl_Risiko.SelectedText = Enum.GetName(typeof(Risiko), Risiko.Mittel);
                dokument.Risiko = Risiko.Mittel;
            }

            //Versicherungsnehmer, die nach Anzahl Mitarbeiter abgerechnet werden und mehr als 5 Mitarbeiter haben, können kein Lösegeld absichern
            if (dokument.Berechnungsart == Berechnungsart.AnzahlMitarbeiter)
                if (dokument.Berechnungbasis > 5)
                {
                    dokument.InkludiereZusatzschutz = false;
                    dokument.ZusatzschutzAufschlag = 0;
                    ctrl_ZusatzschutzAufschlag.Visible = false;
                    ctrl_InkludiereZusatzschutz.Checked = false;
                }

            //Versicherungsnehmer, die nach Umsatz abgerechnet werden, mehr als 100.000€ ausweisen und Lösegeld versichern, haben immer mittleres Risiko
            if (dokument.Berechnungsart == Berechnungsart.Umsatz)
                if (dokument.Berechnungbasis > 100000m && dokument.InkludiereZusatzschutz)
                {
                    ctrl_Risiko.SelectedText = Enum.GetName(typeof(Risiko), Risiko.Mittel);
                    dokument.Risiko = Risiko.Mittel;
                }

            decimal beitrag;
            switch (dokument.Berechnungsart)
            {
                case Berechnungsart.Umsatz:
                    dokument.Berechnungbasis = (decimal) Math.Pow((double)dokument.Versicherungssumme, 0.25d);
                    beitrag = 1.1m * dokument.Berechnungbasis;
                    if (dokument.HatWebshop) //Webshop gibt es nur bei Unternehmen, die nach Umsatz abgerechnet werden
                        beitrag *= 2;
                    break;
                case Berechnungsart.Haushaltssumme:
                    dokument.Berechnungbasis = (decimal)Math.Log10((double) dokument.Versicherungssumme);
                    beitrag = 1.0m * dokument.Berechnungbasis + 100m;
                    break;
                case Berechnungsart.AnzahlMitarbeiter:
                    dokument.Berechnungbasis = dokument.Versicherungssumme / 1000;

                    if (dokument.Berechnungbasis < 4)
                        beitrag = dokument.Berechnungbasis * 250m;
                    else
                        beitrag = dokument.Berechnungbasis * 200m;

                    break;
                default:
                    throw new Exception();
            }

            if (dokument.InkludiereZusatzschutz)
                beitrag *= 1.0m + (decimal) dokument.ZusatzschutzAufschlag / 100.0m;

            if (dokument.Risiko == Risiko.Mittel)
            {
                if (dokument.Berechnungsart is Berechnungsart.Haushaltssumme or Berechnungsart.Umsatz)
                    beitrag *= 1.2m;
                else
                    beitrag *= 1.3m;
            }

            dokument.Berechnungbasis = Math.Round(dokument.Berechnungbasis, 2);
            dokument.Beitrag = Math.Round(beitrag, 2);
        }

        private void Form_NeueKalkulation_Load(object sender, EventArgs e)
        {
            var berechnungsarten = Enum.GetNames(typeof(Berechnungsart));
            ctrl_Berechnungsart.Items.AddRange(berechnungsarten);

            var risiken = Enum.GetNames(typeof(Risiko));
            ctrl_Risiko.Items.AddRange(risiken);
        }

        private void ctrl_InkludiereZusatzschutz_CheckedChanged(object sender, EventArgs e)
        {
            ctrl_ZusatzschutzAufschlag.Visible = ctrl_InkludiereZusatzschutz.Checked;
        }
    }
}
