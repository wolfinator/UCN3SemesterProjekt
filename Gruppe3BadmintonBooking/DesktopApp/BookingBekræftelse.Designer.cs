namespace DesktopApp
{
    partial class BookingBekræftelse
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
            this.lblBekraeftet = new System.Windows.Forms.Label();
            this.btnAfslut = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtMobil = new System.Windows.Forms.TextBox();
            this.txtEfternavn = new System.Windows.Forms.TextBox();
            this.lblMobil = new System.Windows.Forms.Label();
            this.txtFornavn = new System.Windows.Forms.TextBox();
            this.lblEfternavn = new System.Windows.Forms.Label();
            this.lblFornavn = new System.Windows.Forms.Label();
            this.lblKundeInfo = new System.Windows.Forms.Label();
            this.lblKetsjer = new System.Windows.Forms.Label();
            this.txtKetsjer = new System.Windows.Forms.TextBox();
            this.txtPris = new System.Windows.Forms.TextBox();
            this.txtSted = new System.Windows.Forms.TextBox();
            this.txtKlok = new System.Windows.Forms.TextBox();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.lblPris = new System.Windows.Forms.Label();
            this.lblBaneInfo = new System.Windows.Forms.Label();
            this.lblSted = new System.Windows.Forms.Label();
            this.lblKlok = new System.Windows.Forms.Label();
            this.lblDato = new System.Windows.Forms.Label();
            this.txtBold = new System.Windows.Forms.TextBox();
            this.lblBold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBekraeftet
            // 
            this.lblBekraeftet.AutoSize = true;
            this.lblBekraeftet.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBekraeftet.Location = new System.Drawing.Point(310, 9);
            this.lblBekraeftet.Name = "lblBekraeftet";
            this.lblBekraeftet.Size = new System.Drawing.Size(195, 27);
            this.lblBekraeftet.TabIndex = 0;
            this.lblBekraeftet.Text = "Booking Bekræftet";
            // 
            // btnAfslut
            // 
            this.btnAfslut.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAfslut.Location = new System.Drawing.Point(350, 398);
            this.btnAfslut.Name = "btnAfslut";
            this.btnAfslut.Size = new System.Drawing.Size(108, 40);
            this.btnAfslut.TabIndex = 1;
            this.btnAfslut.Text = "Afslut";
            this.btnAfslut.UseVisualStyleBackColor = true;
            this.btnAfslut.Click += new System.EventHandler(this.btnAfslut_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel1.Controls.Add(this.lblEmail);
            this.splitContainer1.Panel1.Controls.Add(this.txtMobil);
            this.splitContainer1.Panel1.Controls.Add(this.txtEfternavn);
            this.splitContainer1.Panel1.Controls.Add(this.lblMobil);
            this.splitContainer1.Panel1.Controls.Add(this.txtFornavn);
            this.splitContainer1.Panel1.Controls.Add(this.lblEfternavn);
            this.splitContainer1.Panel1.Controls.Add(this.lblFornavn);
            this.splitContainer1.Panel1.Controls.Add(this.lblKundeInfo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblBold);
            this.splitContainer1.Panel2.Controls.Add(this.txtBold);
            this.splitContainer1.Panel2.Controls.Add(this.lblKetsjer);
            this.splitContainer1.Panel2.Controls.Add(this.txtKetsjer);
            this.splitContainer1.Panel2.Controls.Add(this.txtPris);
            this.splitContainer1.Panel2.Controls.Add(this.txtSted);
            this.splitContainer1.Panel2.Controls.Add(this.txtKlok);
            this.splitContainer1.Panel2.Controls.Add(this.txtDato);
            this.splitContainer1.Panel2.Controls.Add(this.lblPris);
            this.splitContainer1.Panel2.Controls.Add(this.lblBaneInfo);
            this.splitContainer1.Panel2.Controls.Add(this.lblSted);
            this.splitContainer1.Panel2.Controls.Add(this.lblKlok);
            this.splitContainer1.Panel2.Controls.Add(this.lblDato);
            this.splitContainer1.Size = new System.Drawing.Size(776, 353);
            this.splitContainer1.SplitterDistance = 388;
            this.splitContainer1.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(115, 229);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(149, 23);
            this.txtEmail.TabIndex = 16;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(26, 235);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 17);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // txtMobil
            // 
            this.txtMobil.Location = new System.Drawing.Point(115, 177);
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.ReadOnly = true;
            this.txtMobil.Size = new System.Drawing.Size(149, 23);
            this.txtMobil.TabIndex = 15;
            // 
            // txtEfternavn
            // 
            this.txtEfternavn.Location = new System.Drawing.Point(115, 124);
            this.txtEfternavn.Name = "txtEfternavn";
            this.txtEfternavn.ReadOnly = true;
            this.txtEfternavn.Size = new System.Drawing.Size(149, 23);
            this.txtEfternavn.TabIndex = 14;
            // 
            // lblMobil
            // 
            this.lblMobil.AutoSize = true;
            this.lblMobil.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMobil.Location = new System.Drawing.Point(26, 183);
            this.lblMobil.Name = "lblMobil";
            this.lblMobil.Size = new System.Drawing.Size(59, 17);
            this.lblMobil.TabIndex = 3;
            this.lblMobil.Text = "Mobilnr.:";
            // 
            // txtFornavn
            // 
            this.txtFornavn.Location = new System.Drawing.Point(115, 70);
            this.txtFornavn.Name = "txtFornavn";
            this.txtFornavn.ReadOnly = true;
            this.txtFornavn.Size = new System.Drawing.Size(149, 23);
            this.txtFornavn.TabIndex = 13;
            // 
            // lblEfternavn
            // 
            this.lblEfternavn.AutoSize = true;
            this.lblEfternavn.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEfternavn.Location = new System.Drawing.Point(26, 130);
            this.lblEfternavn.Name = "lblEfternavn";
            this.lblEfternavn.Size = new System.Drawing.Size(69, 17);
            this.lblEfternavn.TabIndex = 2;
            this.lblEfternavn.Text = "Efternavn:";
            // 
            // lblFornavn
            // 
            this.lblFornavn.AutoSize = true;
            this.lblFornavn.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFornavn.Location = new System.Drawing.Point(26, 76);
            this.lblFornavn.Name = "lblFornavn";
            this.lblFornavn.Size = new System.Drawing.Size(59, 17);
            this.lblFornavn.TabIndex = 1;
            this.lblFornavn.Text = "Fornavn:";
            // 
            // lblKundeInfo
            // 
            this.lblKundeInfo.AutoSize = true;
            this.lblKundeInfo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblKundeInfo.Location = new System.Drawing.Point(115, 19);
            this.lblKundeInfo.Name = "lblKundeInfo";
            this.lblKundeInfo.Size = new System.Drawing.Size(149, 21);
            this.lblKundeInfo.TabIndex = 0;
            this.lblKundeInfo.Text = "Kunde information";
            // 
            // lblKetsjer
            // 
            this.lblKetsjer.AutoSize = true;
            this.lblKetsjer.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKetsjer.Location = new System.Drawing.Point(33, 280);
            this.lblKetsjer.Name = "lblKetsjer";
            this.lblKetsjer.Size = new System.Drawing.Size(54, 17);
            this.lblKetsjer.TabIndex = 14;
            this.lblKetsjer.Text = "Ketsjer:";
            // 
            // txtKetsjer
            // 
            this.txtKetsjer.Location = new System.Drawing.Point(109, 274);
            this.txtKetsjer.Name = "txtKetsjer";
            this.txtKetsjer.ReadOnly = true;
            this.txtKetsjer.Size = new System.Drawing.Size(152, 23);
            this.txtKetsjer.TabIndex = 13;
            // 
            // txtPris
            // 
            this.txtPris.Location = new System.Drawing.Point(109, 227);
            this.txtPris.Name = "txtPris";
            this.txtPris.ReadOnly = true;
            this.txtPris.Size = new System.Drawing.Size(152, 23);
            this.txtPris.TabIndex = 12;
            // 
            // txtSted
            // 
            this.txtSted.Location = new System.Drawing.Point(109, 175);
            this.txtSted.Name = "txtSted";
            this.txtSted.ReadOnly = true;
            this.txtSted.Size = new System.Drawing.Size(152, 23);
            this.txtSted.TabIndex = 11;
            // 
            // txtKlok
            // 
            this.txtKlok.Location = new System.Drawing.Point(109, 122);
            this.txtKlok.Name = "txtKlok";
            this.txtKlok.ReadOnly = true;
            this.txtKlok.Size = new System.Drawing.Size(152, 23);
            this.txtKlok.TabIndex = 10;
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(109, 68);
            this.txtDato.Name = "txtDato";
            this.txtDato.ReadOnly = true;
            this.txtDato.Size = new System.Drawing.Size(152, 23);
            this.txtDato.TabIndex = 9;
            // 
            // lblPris
            // 
            this.lblPris.AutoSize = true;
            this.lblPris.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPris.Location = new System.Drawing.Point(33, 233);
            this.lblPris.Name = "lblPris";
            this.lblPris.Size = new System.Drawing.Size(34, 17);
            this.lblPris.TabIndex = 8;
            this.lblPris.Text = "Pris:";
            // 
            // lblBaneInfo
            // 
            this.lblBaneInfo.AutoSize = true;
            this.lblBaneInfo.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.lblBaneInfo.Location = new System.Drawing.Point(124, 19);
            this.lblBaneInfo.Name = "lblBaneInfo";
            this.lblBaneInfo.Size = new System.Drawing.Size(137, 21);
            this.lblBaneInfo.TabIndex = 1;
            this.lblBaneInfo.Text = "Bane information";
            // 
            // lblSted
            // 
            this.lblSted.AutoSize = true;
            this.lblSted.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSted.Location = new System.Drawing.Point(33, 181);
            this.lblSted.Name = "lblSted";
            this.lblSted.Size = new System.Drawing.Size(37, 17);
            this.lblSted.TabIndex = 7;
            this.lblSted.Text = "Sted:";
            // 
            // lblKlok
            // 
            this.lblKlok.AutoSize = true;
            this.lblKlok.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKlok.Location = new System.Drawing.Point(33, 128);
            this.lblKlok.Name = "lblKlok";
            this.lblKlok.Size = new System.Drawing.Size(67, 17);
            this.lblKlok.TabIndex = 6;
            this.lblKlok.Text = "Tidspunkt:";
            // 
            // lblDato
            // 
            this.lblDato.AutoSize = true;
            this.lblDato.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDato.Location = new System.Drawing.Point(33, 74);
            this.lblDato.Name = "lblDato";
            this.lblDato.Size = new System.Drawing.Size(40, 17);
            this.lblDato.TabIndex = 5;
            this.lblDato.Text = "Dato:";
            // 
            // txtBold
            // 
            this.txtBold.Location = new System.Drawing.Point(109, 323);
            this.txtBold.Name = "txtBold";
            this.txtBold.ReadOnly = true;
            this.txtBold.Size = new System.Drawing.Size(152, 23);
            this.txtBold.TabIndex = 15;
            // 
            // lblBold
            // 
            this.lblBold.AutoSize = true;
            this.lblBold.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBold.Location = new System.Drawing.Point(33, 329);
            this.lblBold.Name = "lblBold";
            this.lblBold.Size = new System.Drawing.Size(45, 17);
            this.lblBold.TabIndex = 16;
            this.lblBold.Text = "Bolde:";
            // 
            // BookingBekræftelse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnAfslut);
            this.Controls.Add(this.lblBekraeftet);
            this.Name = "BookingBekræftelse";
            this.Text = "BookingBekræftelse";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblBekraeftet;
        private Button btnAfslut;
        private SplitContainer splitContainer1;
        private Label lblEmail;
        private Label lblMobil;
        private Label lblEfternavn;
        private Label lblFornavn;
        private Label lblKundeInfo;
        private Label lblBaneInfo;
        private Label lblPris;
        private Label lblSted;
        private Label lblKlok;
        private Label lblDato;
        private TextBox txtKlok;
        private TextBox txtDato;
        private TextBox txtEmail;
        private TextBox txtMobil;
        private TextBox txtEfternavn;
        private TextBox txtFornavn;
        private TextBox txtPris;
        private TextBox txtSted;
        private Label lblKetsjer;
        private TextBox txtKetsjer;
        private Label lblBold;
        private TextBox txtBold;
    }
}