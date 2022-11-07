namespace DesktopApp
{
    partial class BookingOversigt
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblKalender = new System.Windows.Forms.Label();
            this.lblNuvaerende = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSoeg = new System.Windows.Forms.Label();
            this.lblHistorik = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTilbage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnTilbage);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar1);
            this.splitContainer1.Panel1.Controls.Add(this.lblKalender);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.lblHistorik);
            this.splitContainer1.Panel2.Controls.Add(this.lblNuvaerende);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBox1);
            this.splitContainer1.Panel2.Controls.Add(this.lblSoeg);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 490;
            this.splitContainer1.TabIndex = 0;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(133, 138);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            // 
            // lblKalender
            // 
            this.lblKalender.AutoSize = true;
            this.lblKalender.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKalender.Location = new System.Drawing.Point(193, 9);
            this.lblKalender.Name = "lblKalender";
            this.lblKalender.Size = new System.Drawing.Size(100, 27);
            this.lblKalender.TabIndex = 0;
            this.lblKalender.Text = "Kalender";
            // 
            // lblNuvaerende
            // 
            this.lblNuvaerende.AutoSize = true;
            this.lblNuvaerende.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNuvaerende.Location = new System.Drawing.Point(113, 125);
            this.lblNuvaerende.Name = "lblNuvaerende";
            this.lblNuvaerende.Size = new System.Drawing.Size(83, 19);
            this.lblNuvaerende.TabIndex = 5;
            this.lblNuvaerende.Text = "Nuværende:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mobil nr.:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 23);
            this.textBox1.TabIndex = 3;
            // 
            // lblSoeg
            // 
            this.lblSoeg.AutoSize = true;
            this.lblSoeg.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSoeg.Location = new System.Drawing.Point(103, 9);
            this.lblSoeg.Name = "lblSoeg";
            this.lblSoeg.Size = new System.Drawing.Size(130, 27);
            this.lblSoeg.TabIndex = 2;
            this.lblSoeg.Text = "Søg booking";
            // 
            // lblHistorik
            // 
            this.lblHistorik.AutoSize = true;
            this.lblHistorik.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHistorik.Location = new System.Drawing.Point(123, 281);
            this.lblHistorik.Name = "lblHistorik";
            this.lblHistorik.Size = new System.Drawing.Size(60, 19);
            this.lblHistorik.TabIndex = 6;
            this.lblHistorik.Text = "Historik:";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(62, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Location = new System.Drawing.Point(62, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 8;
            // 
            // btnTilbage
            // 
            this.btnTilbage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTilbage.Location = new System.Drawing.Point(193, 394);
            this.btnTilbage.Name = "btnTilbage";
            this.btnTilbage.Size = new System.Drawing.Size(110, 44);
            this.btnTilbage.TabIndex = 0;
            this.btnTilbage.Text = "Tilbage";
            this.btnTilbage.UseVisualStyleBackColor = true;
            this.btnTilbage.Click += new System.EventHandler(this.btnTilbage_Click);
            // 
            // BookingOversigt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "BookingOversigt";
            this.Text = "Booking Oversigt";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private MonthCalendar monthCalendar1;
        private Label lblKalender;
        private Label lblNuvaerende;
        private Label label1;
        private TextBox textBox1;
        private Label lblSoeg;
        private Label lblHistorik;
        private Button btnTilbage;
        private Panel panel2;
        private Panel panel1;
    }
}