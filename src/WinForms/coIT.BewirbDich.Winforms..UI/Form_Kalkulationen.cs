using coIT.BewirbDich.Winforms.Domain;
using coIT.BewirbDich.Winforms.Infrastructure;

namespace coIT.BewirbDich.Winforms.UI;

public partial class Form1 : Form
{
    private readonly IRepository _repo;

    private BindingSource _kalkulationen;

    public Form1()
    {
        InitializeComponent();
        _repo = new JsonRepository("database.json");
    }

    private void ctr_NeueKalkulation_Click(object sender, EventArgs e)
    {
        var neueKalkulationForm = new Form_NeueKalkulation();

        var dialog = neueKalkulationForm.ShowDialog();
        if (dialog == DialogResult.OK)
        {
            var neueKalkulation = neueKalkulationForm.Kalkulation;
            _repo.Add(neueKalkulation);
            _kalkulationen.List.Add(neueKalkulation);
            _kalkulationen.ResetBindings(false);
        }

    }

    private void ctrl_Speichern_Click(object sender, EventArgs e)
    {
        _repo.Save();
        MessageBox.Show("Daten gespeichert.", "Vorgang", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ctrl_ListeKalkulationen_SelectionChanged(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();

        if (kalkulation == null)
            return;

        OptionenAnzeigen(kalkulation);
    }

    private void OptionenAnzeigen(Dokument kalkulation)
    {
        ctrl_VersicherungsscheinAusstellen.Enabled = false;
        ctrl_AngebotAnnehmen.Enabled = false;

        switch (kalkulation.Typ)
        {
            case Dokumenttyp.Angebot:
                ctrl_AngebotAnnehmen.Enabled = true;
                break;
            case Dokumenttyp.Versicherungsschein:
                if (!kalkulation.VersicherungsscheinAusgestellt)
                    ctrl_VersicherungsscheinAusstellen.Enabled = true;
                break;
            default: throw new InvalidDataException("Unbekannter Dokumenttyp");
        }
    }

    private void ctrl_AngebotAnnehmen_Click(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();
        if (kalkulation == null)
            return;

        kalkulation.Typ = Dokumenttyp.Versicherungsschein;
        
        OptionenAnzeigen(kalkulation);
        _kalkulationen.ResetBindings(false);
    }

    private void ctrl_VersicherungsscheinAusstellen_Click(object sender, EventArgs e)
    {
        var kalkulation = AuswahlEinlesen();
        if (kalkulation == null)
            return;

        kalkulation.VersicherungsscheinAusgestellt = true;
        
        OptionenAnzeigen(kalkulation);

        MessageBox.Show("Der Versicherungsschein wurde an den Versicherungsnehmer verschickt.", "Vorgang", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private Dokument? AuswahlEinlesen()
    {
        var rowsCount = ctrl_ListeKalkulationen.SelectedRows.Count;
        if (rowsCount == 0 || rowsCount > 1) return null;

        var zeile = ctrl_ListeKalkulationen.SelectedRows[0];
        if (zeile == null) return null;

        var kalkulation = (Dokument)zeile.DataBoundItem;
        return kalkulation;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        _kalkulationen = new BindingSource
        {
            DataSource = _repo.List()
        };

        ctrl_ListeKalkulationen.DataSource = _kalkulationen;

        ctrl_ListeKalkulationen.ColumnHeadersVisible = true;
        ctrl_ListeKalkulationen.AutoGenerateColumns = true;
        ctrl_ListeKalkulationen.Columns["Id"].Visible = false;
        ctrl_ListeKalkulationen.Columns["Beitrag"].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.Columns["Versicherungssumme"].DefaultCellStyle.Format = "c";
        ctrl_ListeKalkulationen.AutoResizeColumns();
        ctrl_ListeKalkulationen.AutoSize = true;

        _kalkulationen.ResetBindings(false);
    }
}