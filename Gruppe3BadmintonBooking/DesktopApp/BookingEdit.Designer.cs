namespace DesktopApp
{
    partial class BookingEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblNavn = new System.Windows.Forms.Label();
            this.lblMobil = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblDato = new System.Windows.Forms.Label();
            this.lblTid = new System.Windows.Forms.Label();
            this.lblHal = new System.Windows.Forms.Label();
            this.lblBane = new System.Windows.Forms.Label();
            this.lblEkstra = new System.Windows.Forms.Label();
            this.lblKetsjer = new System.Windows.Forms.Label();
            this.lblBold = new System.Windows.Forms.Label();
            this.btnSlet = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtMobil = new System.Windows.Forms.TextBox();
            this.txtNavn = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtKetsjer = new System.Windows.Forms.TextBox();
            this.txtBold = new System.Windows.Forms.TextBox();
            this.txtTid = new System.Windows.Forms.TextBox();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.txtHal = new System.Windows.Forms.TextBox();
            this.txtBane = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(238, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Redigér kundeinformation";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtBold);
            this.splitContainer1.Panel1.Controls.Add(this.txtKetsjer);
            this.splitContainer1.Panel1.Controls.Add(this.txtEmail);
            this.splitContainer1.Panel1.Controls.Add(this.txtNavn);
            this.splitContainer1.Panel1.Controls.Add(this.txtMobil);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.lblBold);
            this.splitContainer1.Panel1.Controls.Add(this.lblKetsjer);
            this.splitContainer1.Panel1.Controls.Add(this.lblEkstra);
            this.splitContainer1.Panel1.Controls.Add(this.lblEmail);
            this.splitContainer1.Panel1.Controls.Add(this.lblMobil);
            this.splitContainer1.Panel1.Controls.Add(this.lblNavn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBane);
            this.splitContainer1.Panel2.Controls.Add(this.txtHal);
            this.splitContainer1.Panel2.Controls.Add(this.txtDato);
            this.splitContainer1.Panel2.Controls.Add(this.txtTid);
            this.splitContainer1.Panel2.Controls.Add(this.btnSlet);
            this.splitContainer1.Panel2.Controls.Add(this.lblBane);
            this.splitContainer1.Panel2.Controls.Add(this.lblHal);
            this.splitContainer1.Panel2.Controls.Add(this.lblTid);
            this.splitContainer1.Panel2.Controls.Add(this.lblDato);
            this.splitContainer1.Size = new System.Drawing.Size(776, 393);
            this.splitContainer1.SplitterDistance = 377;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblNavn
            // 
            this.lblNavn.AutoSize = true;
            this.lblNavn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNavn.Location = new System.Drawing.Point(3, 30);
            this.lblNavn.Name = "lblNavn";
            this.lblNavn.Size = new System.Drawing.Size(53, 21);
            this.lblNavn.TabIndex = 0;
            this.lblNavn.Text = "Navn:";
            // 
            // lblMobil
            // 
            this.lblMobil.AutoSize = true;
            this.lblMobil.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMobil.Location = new System.Drawing.Point(3, 85);
            this.lblMobil.Name = "lblMobil";
            this.lblMobil.Size = new System.Drawing.Size(82, 21);
            this.lblMobil.TabIndex = 1;
            this.lblMobil.Text = "Mobil nr.:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(3, 145);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(55, 21);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email:";
            // 
            // lblDato
            // 
            this.lblDato.AutoSize = true;
            this.lblDato.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDato.Location = new System.Drawing.Point(3, 30);
            this.lblDato.Name = "lblDato";
            this.lblDato.Size = new System.Drawing.Size(50, 21);
            this.lblDato.TabIndex = 3;
            this.lblDato.Text = "Dato:";
            // 
            // lblTid
            // 
            this.lblTid.AutoSize = true;
            this.lblTid.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTid.Location = new System.Drawing.Point(3, 85);
            this.lblTid.Name = "lblTid";
            this.lblTid.Size = new System.Drawing.Size(89, 21);
            this.lblTid.TabIndex = 4;
            this.lblTid.Text = "Tidspunkt:";
            // 
            // lblHal
            // 
            this.lblHal.AutoSize = true;
            this.lblHal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHal.Location = new System.Drawing.Point(3, 145);
            this.lblHal.Name = "lblHal";
            this.lblHal.Size = new System.Drawing.Size(39, 21);
            this.lblHal.TabIndex = 5;
            this.lblHal.Text = "Hal:";
            // 
            // lblBane
            // 
            this.lblBane.AutoSize = true;
            this.lblBane.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBane.Location = new System.Drawing.Point(3, 203);
            this.lblBane.Name = "lblBane";
            this.lblBane.Size = new System.Drawing.Size(51, 21);
            this.lblBane.TabIndex = 6;
            this.lblBane.Text = "Bane:";
            // 
            // lblEkstra
            // 
            this.lblEkstra.AutoSize = true;
            this.lblEkstra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEkstra.Location = new System.Drawing.Point(110, 194);
            this.lblEkstra.Name = "lblEkstra";
            this.lblEkstra.Size = new System.Drawing.Size(61, 21);
            this.lblEkstra.TabIndex = 7;
            this.lblEkstra.Text = "Ekstra:";
            // 
            // lblKetsjer
            // 
            this.lblKetsjer.AutoSize = true;
            this.lblKetsjer.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKetsjer.Location = new System.Drawing.Point(3, 239);
            this.lblKetsjer.Name = "lblKetsjer";
            this.lblKetsjer.Size = new System.Drawing.Size(66, 21);
            this.lblKetsjer.TabIndex = 8;
            this.lblKetsjer.Text = "Ketsjer:";
            // 
            // lblBold
            // 
            this.lblBold.AutoSize = true;
            this.lblBold.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBold.Location = new System.Drawing.Point(3, 293);
            this.lblBold.Name = "lblBold";
            this.lblBold.Size = new System.Drawing.Size(58, 21);
            this.lblBold.TabIndex = 9;
            this.lblBold.Text = "Bolde:";
            // 
            // btnSlet
            // 
            this.btnSlet.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSlet.Location = new System.Drawing.Point(149, 340);
            this.btnSlet.Name = "btnSlet";
            this.btnSlet.Size = new System.Drawing.Size(117, 37);
            this.btnSlet.TabIndex = 7;
            this.btnSlet.Text = "Slet booking";
            this.btnSlet.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdate.Location = new System.Drawing.Point(128, 340);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 37);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Opdatér";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // txtMobil
            // 
            this.txtMobil.Location = new System.Drawing.Point(91, 83);
            this.txtMobil.Name = "txtMobil";
            this.txtMobil.Size = new System.Drawing.Size(100, 23);
            this.txtMobil.TabIndex = 8;
            // 
            // txtNavn
            // 
            this.txtNavn.Location = new System.Drawing.Point(91, 30);
            this.txtNavn.Name = "txtNavn";
            this.txtNavn.Size = new System.Drawing.Size(100, 23);
            this.txtNavn.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(91, 146);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 23);
            this.txtEmail.TabIndex = 12;
            // 
            // txtKetsjer
            // 
            this.txtKetsjer.Location = new System.Drawing.Point(91, 237);
            this.txtKetsjer.Name = "txtKetsjer";
            this.txtKetsjer.Size = new System.Drawing.Size(100, 23);
            this.txtKetsjer.TabIndex = 13;
            // 
            // txtBold
            // 
            this.txtBold.Location = new System.Drawing.Point(91, 291);
            this.txtBold.Name = "txtBold";
            this.txtBold.ReadOnly = true;
            this.txtBold.Size = new System.Drawing.Size(100, 23);
            this.txtBold.TabIndex = 14;
            // 
            // txtTid
            // 
            this.txtTid.Location = new System.Drawing.Point(98, 83);
            this.txtTid.Name = "txtTid";
            this.txtTid.ReadOnly = true;
            this.txtTid.Size = new System.Drawing.Size(100, 23);
            this.txtTid.TabIndex = 15;
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(98, 28);
            this.txtDato.Name = "txtDato";
            this.txtDato.ReadOnly = true;
            this.txtDato.Size = new System.Drawing.Size(100, 23);
            this.txtDato.TabIndex = 16;
            // 
            // txtHal
            // 
            this.txtHal.Location = new System.Drawing.Point(98, 145);
            this.txtHal.Name = "txtHal";
            this.txtHal.ReadOnly = true;
            this.txtHal.Size = new System.Drawing.Size(100, 23);
            this.txtHal.TabIndex = 17;
            // 
            // txtBane
            // 
            this.txtBane.Location = new System.Drawing.Point(98, 201);
            this.txtBane.Name = "txtBane";
            this.txtBane.ReadOnly = true;
            this.txtBane.Size = new System.Drawing.Size(100, 23);
            this.txtBane.TabIndex = 18;
            // 
            // BookingEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "BookingEdit";
            this.Text = "BookingEdit";
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

        private Label label1;
        private SplitContainer splitContainer1;
        private Label lblBold;
        private Label lblKetsjer;
        private Label lblEkstra;
        private Label lblEmail;
        private Label lblMobil;
        private Label lblNavn;
        private Label lblBane;
        private Label lblHal;
        private Label lblTid;
        private Label lblDato;
        private TextBox txtBold;
        private TextBox txtKetsjer;
        private TextBox txtEmail;
        private TextBox txtNavn;
        private TextBox txtMobil;
        private Button btnUpdate;
        private TextBox txtBane;
        private TextBox txtHal;
        private TextBox txtDato;
        private TextBox txtTid;
        private Button btnSlet;
    }
}