namespace coIT.BewirbDich.Winforms.UI
{
    partial class Form_NeueKalkulation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctrl_Berechnungsart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ctrl_Risiko = new System.Windows.Forms.ComboBox();
            this.ctrl_HatWebshop = new System.Windows.Forms.RadioButton();
            this.ctrl_Versicherungssumme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ctrl_Kalkuliere = new System.Windows.Forms.Button();
            this.ctrl_Abbrechen = new System.Windows.Forms.Button();
            this.ctrl_InkludiereZusatzschutz = new System.Windows.Forms.CheckBox();
            this.ctrl_ZusatzschutzAufschlag = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ctrl_Berechnungsart
            // 
            this.ctrl_Berechnungsart.FormattingEnabled = true;
            this.ctrl_Berechnungsart.Location = new System.Drawing.Point(165, 12);
            this.ctrl_Berechnungsart.Name = "ctrl_Berechnungsart";
            this.ctrl_Berechnungsart.Size = new System.Drawing.Size(231, 23);
            this.ctrl_Berechnungsart.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Berechnungsart";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Risiko";
            // 
            // ctrl_Risiko
            // 
            this.ctrl_Risiko.FormattingEnabled = true;
            this.ctrl_Risiko.Location = new System.Drawing.Point(165, 58);
            this.ctrl_Risiko.Name = "ctrl_Risiko";
            this.ctrl_Risiko.Size = new System.Drawing.Size(231, 23);
            this.ctrl_Risiko.TabIndex = 2;
            // 
            // ctrl_HatWebshop
            // 
            this.ctrl_HatWebshop.Appearance = System.Windows.Forms.Appearance.Button;
            this.ctrl_HatWebshop.Location = new System.Drawing.Point(21, 177);
            this.ctrl_HatWebshop.Name = "ctrl_HatWebshop";
            this.ctrl_HatWebshop.Size = new System.Drawing.Size(375, 47);
            this.ctrl_HatWebshop.TabIndex = 6;
            this.ctrl_HatWebshop.TabStop = true;
            this.ctrl_HatWebshop.Text = "Hat Webshop";
            this.ctrl_HatWebshop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ctrl_HatWebshop.UseVisualStyleBackColor = true;
            // 
            // ctrl_Versicherungssumme
            // 
            this.ctrl_Versicherungssumme.Location = new System.Drawing.Point(165, 104);
            this.ctrl_Versicherungssumme.Name = "ctrl_Versicherungssumme";
            this.ctrl_Versicherungssumme.Size = new System.Drawing.Size(231, 23);
            this.ctrl_Versicherungssumme.TabIndex = 7;
            this.ctrl_Versicherungssumme.Text = "100000";
            this.ctrl_Versicherungssumme.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Versicherungssumme";
            // 
            // ctrl_Kalkuliere
            // 
            this.ctrl_Kalkuliere.Location = new System.Drawing.Point(218, 261);
            this.ctrl_Kalkuliere.Name = "ctrl_Kalkuliere";
            this.ctrl_Kalkuliere.Size = new System.Drawing.Size(178, 44);
            this.ctrl_Kalkuliere.TabIndex = 9;
            this.ctrl_Kalkuliere.Text = "Kalkulieren";
            this.ctrl_Kalkuliere.UseVisualStyleBackColor = true;
            this.ctrl_Kalkuliere.Click += new System.EventHandler(this.ctrl_Kalkuliere_Click);
            // 
            // ctrl_Abbrechen
            // 
            this.ctrl_Abbrechen.Location = new System.Drawing.Point(21, 261);
            this.ctrl_Abbrechen.Name = "ctrl_Abbrechen";
            this.ctrl_Abbrechen.Size = new System.Drawing.Size(178, 44);
            this.ctrl_Abbrechen.TabIndex = 10;
            this.ctrl_Abbrechen.Text = "Abbrechen";
            this.ctrl_Abbrechen.UseVisualStyleBackColor = true;
            this.ctrl_Abbrechen.Click += new System.EventHandler(this.ctrl_Abbrechen_Click);
            // 
            // ctrl_InkludiereZusatzschutz
            // 
            this.ctrl_InkludiereZusatzschutz.AutoSize = true;
            this.ctrl_InkludiereZusatzschutz.Location = new System.Drawing.Point(21, 152);
            this.ctrl_InkludiereZusatzschutz.Name = "ctrl_InkludiereZusatzschutz";
            this.ctrl_InkludiereZusatzschutz.Size = new System.Drawing.Size(94, 19);
            this.ctrl_InkludiereZusatzschutz.TabIndex = 11;
            this.ctrl_InkludiereZusatzschutz.Text = "Zusatzschutz";
            this.ctrl_InkludiereZusatzschutz.UseVisualStyleBackColor = true;
            this.ctrl_InkludiereZusatzschutz.CheckedChanged += new System.EventHandler(this.ctrl_InkludiereZusatzschutz_CheckedChanged);
            // 
            // ctrl_ZusatzschutzAufschlag
            // 
            this.ctrl_ZusatzschutzAufschlag.FormattingEnabled = true;
            this.ctrl_ZusatzschutzAufschlag.Items.AddRange(new object[] {
            "10%",
            "20%",
            "25%"});
            this.ctrl_ZusatzschutzAufschlag.Location = new System.Drawing.Point(165, 148);
            this.ctrl_ZusatzschutzAufschlag.Name = "ctrl_ZusatzschutzAufschlag";
            this.ctrl_ZusatzschutzAufschlag.Size = new System.Drawing.Size(231, 23);
            this.ctrl_ZusatzschutzAufschlag.TabIndex = 12;
            this.ctrl_ZusatzschutzAufschlag.Visible = false;
            // 
            // Form_NeueKalkulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 362);
            this.Controls.Add(this.ctrl_ZusatzschutzAufschlag);
            this.Controls.Add(this.ctrl_InkludiereZusatzschutz);
            this.Controls.Add(this.ctrl_Abbrechen);
            this.Controls.Add(this.ctrl_Kalkuliere);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrl_Versicherungssumme);
            this.Controls.Add(this.ctrl_HatWebshop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ctrl_Risiko);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrl_Berechnungsart);
            this.Name = "Form_NeueKalkulation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neue Kalkulation";
            this.Load += new System.EventHandler(this.Form_NeueKalkulation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox ctrl_Berechnungsart;
        private Label label1;
        private Label label2;
        private ComboBox ctrl_Risiko;
        private RadioButton ctrl_HatWebshop;
        private TextBox ctrl_Versicherungssumme;
        private Label label3;
        private Button ctrl_Kalkuliere;
        private Button ctrl_Abbrechen;
        private CheckBox ctrl_InkludiereZusatzschutz;
        private ComboBox ctrl_ZusatzschutzAufschlag;
    }
}