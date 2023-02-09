namespace coIT.BewirbDich.Winforms.UI;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.ctr_NeueKalkulation = new System.Windows.Forms.Button();
            this.ctrl_ListeKalkulationen = new System.Windows.Forms.DataGridView();
            this.ctrl_Speichern = new System.Windows.Forms.Button();
            this.ctrl_AngebotAnnehmen = new System.Windows.Forms.Button();
            this.ctrl_VersicherungsscheinAusstellen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ctrl_ListeKalkulationen)).BeginInit();
            this.SuspendLayout();
            // 
            // ctr_NeueKalkulation
            // 
            this.ctr_NeueKalkulation.Location = new System.Drawing.Point(12, 12);
            this.ctr_NeueKalkulation.Name = "ctr_NeueKalkulation";
            this.ctr_NeueKalkulation.Size = new System.Drawing.Size(75, 41);
            this.ctr_NeueKalkulation.TabIndex = 0;
            this.ctr_NeueKalkulation.Text = "+ NEU";
            this.ctr_NeueKalkulation.UseVisualStyleBackColor = true;
            this.ctr_NeueKalkulation.Click += new System.EventHandler(this.ctr_NeueKalkulation_Click);
            // 
            // ctrl_ListeKalkulationen
            // 
            this.ctrl_ListeKalkulationen.AllowUserToOrderColumns = true;
            this.ctrl_ListeKalkulationen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrl_ListeKalkulationen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ctrl_ListeKalkulationen.Location = new System.Drawing.Point(12, 79);
            this.ctrl_ListeKalkulationen.Name = "ctrl_ListeKalkulationen";
            this.ctrl_ListeKalkulationen.RowTemplate.Height = 25;
            this.ctrl_ListeKalkulationen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ctrl_ListeKalkulationen.Size = new System.Drawing.Size(1184, 359);
            this.ctrl_ListeKalkulationen.TabIndex = 1;
            this.ctrl_ListeKalkulationen.SelectionChanged += new System.EventHandler(this.ctrl_ListeKalkulationen_SelectionChanged);
            // 
            // ctrl_Speichern
            // 
            this.ctrl_Speichern.Location = new System.Drawing.Point(1111, 12);
            this.ctrl_Speichern.Name = "ctrl_Speichern";
            this.ctrl_Speichern.Size = new System.Drawing.Size(75, 41);
            this.ctrl_Speichern.TabIndex = 2;
            this.ctrl_Speichern.Text = "Speichern";
            this.ctrl_Speichern.UseVisualStyleBackColor = true;
            this.ctrl_Speichern.Click += new System.EventHandler(this.ctrl_Speichern_Click);
            // 
            // ctrl_AngebotAnnehmen
            // 
            this.ctrl_AngebotAnnehmen.Enabled = false;
            this.ctrl_AngebotAnnehmen.Location = new System.Drawing.Point(93, 12);
            this.ctrl_AngebotAnnehmen.Name = "ctrl_AngebotAnnehmen";
            this.ctrl_AngebotAnnehmen.Size = new System.Drawing.Size(94, 41);
            this.ctrl_AngebotAnnehmen.TabIndex = 3;
            this.ctrl_AngebotAnnehmen.Text = "Annehmen 👍";
            this.ctrl_AngebotAnnehmen.UseVisualStyleBackColor = true;
            this.ctrl_AngebotAnnehmen.Click += new System.EventHandler(this.ctrl_AngebotAnnehmen_Click);
            // 
            // ctrl_VersicherungsscheinAusstellen
            // 
            this.ctrl_VersicherungsscheinAusstellen.Enabled = false;
            this.ctrl_VersicherungsscheinAusstellen.Location = new System.Drawing.Point(193, 12);
            this.ctrl_VersicherungsscheinAusstellen.Name = "ctrl_VersicherungsscheinAusstellen";
            this.ctrl_VersicherungsscheinAusstellen.Size = new System.Drawing.Size(94, 41);
            this.ctrl_VersicherungsscheinAusstellen.TabIndex = 4;
            this.ctrl_VersicherungsscheinAusstellen.Text = "Ausstellen 🖨";
            this.ctrl_VersicherungsscheinAusstellen.UseVisualStyleBackColor = true;
            this.ctrl_VersicherungsscheinAusstellen.Click += new System.EventHandler(this.ctrl_VersicherungsscheinAusstellen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 450);
            this.Controls.Add(this.ctrl_VersicherungsscheinAusstellen);
            this.Controls.Add(this.ctrl_AngebotAnnehmen);
            this.Controls.Add(this.ctrl_Speichern);
            this.Controls.Add(this.ctrl_ListeKalkulationen);
            this.Controls.Add(this.ctr_NeueKalkulation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deine Bewerbung";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctrl_ListeKalkulationen)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private Button ctr_NeueKalkulation;
    private DataGridView ctrl_ListeKalkulationen;
    private Button ctrl_Speichern;
    private Button ctrl_AngebotAnnehmen;
    private Button ctrl_VersicherungsscheinAusstellen;
}