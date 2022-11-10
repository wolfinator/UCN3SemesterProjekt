namespace DesktopApp
{
    partial class OpretBooking
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
            this.label2 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnBookBane = new System.Windows.Forms.Button();
            this.btnTilbage = new System.Windows.Forms.Button();
            this.listCourts = new System.Windows.Forms.ListView();
            this.Bane = new System.Windows.Forms.ColumnHeader();
            this.Hal = new System.Windows.Forms.ColumnHeader();
            this.lblKlok = new System.Windows.Forms.Label();
            this.comboKlok = new System.Windows.Forms.ComboBox();
            this.btnGetCourts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(48, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(310, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ledige baner:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(48, 41);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // btnBookBane
            // 
            this.btnBookBane.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookBane.Location = new System.Drawing.Point(433, 411);
            this.btnBookBane.Name = "btnBookBane";
            this.btnBookBane.Size = new System.Drawing.Size(117, 27);
            this.btnBookBane.TabIndex = 4;
            this.btnBookBane.Text = "Book bane";
            this.btnBookBane.UseVisualStyleBackColor = true;
            this.btnBookBane.Click += new System.EventHandler(this.btnBookBane_Click_1);
            // 
            // btnTilbage
            // 
            this.btnTilbage.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTilbage.Location = new System.Drawing.Point(310, 411);
            this.btnTilbage.Name = "btnTilbage";
            this.btnTilbage.Size = new System.Drawing.Size(117, 27);
            this.btnTilbage.TabIndex = 5;
            this.btnTilbage.Text = "Tilbage";
            this.btnTilbage.UseVisualStyleBackColor = true;
            this.btnTilbage.Click += new System.EventHandler(this.btnTilbage_Click);
            // 
            // listCourts
            // 
            this.listCourts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Bane,
            this.Hal});
            this.listCourts.Location = new System.Drawing.Point(310, 41);
            this.listCourts.Name = "listCourts";
            this.listCourts.Size = new System.Drawing.Size(432, 218);
            this.listCourts.TabIndex = 6;
            this.listCourts.UseCompatibleStateImageBehavior = false;
            // 
            // lblKlok
            // 
            this.lblKlok.AutoSize = true;
            this.lblKlok.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKlok.Location = new System.Drawing.Point(48, 218);
            this.lblKlok.Name = "lblKlok";
            this.lblKlok.Size = new System.Drawing.Size(97, 21);
            this.lblKlok.TabIndex = 7;
            this.lblKlok.Text = "Klokkeslæt:";
            // 
            // comboKlok
            // 
            this.comboKlok.FormattingEnabled = true;
            this.comboKlok.Items.AddRange(new object[] {
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00"});
            this.comboKlok.Location = new System.Drawing.Point(48, 242);
            this.comboKlok.Name = "comboKlok";
            this.comboKlok.Size = new System.Drawing.Size(171, 23);
            this.comboKlok.TabIndex = 8;
            // 
            // btnGetCourts
            // 
            this.btnGetCourts.Location = new System.Drawing.Point(314, 280);
            this.btnGetCourts.Name = "btnGetCourts";
            this.btnGetCourts.Size = new System.Drawing.Size(75, 23);
            this.btnGetCourts.TabIndex = 9;
            this.btnGetCourts.Text = "SEARCH";
            this.btnGetCourts.UseVisualStyleBackColor = true;
            // 
            // OpretBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGetCourts);
            this.Controls.Add(this.comboKlok);
            this.Controls.Add(this.lblKlok);
            this.Controls.Add(this.listCourts);
            this.Controls.Add(this.btnTilbage);
            this.Controls.Add(this.btnBookBane);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OpretBooking";
            this.Text = "Opret Booking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private MonthCalendar monthCalendar1;
        private Label lblDato;
        private Label lblKalender;
        private MonthCalendar Calender;
        private Button btnBookBane;
        private Button btnTilbage;
        private ListView listCourts;
        private Label lblKlok;
        private ComboBox comboKlok;
        private Button btnGetCourts;
        private ColumnHeader Bane;
        private ColumnHeader Hal;
    }
}