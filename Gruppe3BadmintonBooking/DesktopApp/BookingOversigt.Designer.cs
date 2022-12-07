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
            this.dataGridViewOverview = new System.Windows.Forms.DataGridView();
            this.btnTilbage = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.lblKalender = new System.Windows.Forms.Label();
            this.btnSlet = new System.Windows.Forms.Button();
            this.btnRediger = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dataGridViewNu = new System.Windows.Forms.DataGridView();
            this.dataGridViewHistorik = new System.Windows.Forms.DataGridView();
            this.lblHistorik = new System.Windows.Forms.Label();
            this.lblNuvaerende = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMobil = new System.Windows.Forms.TextBox();
            this.lblSoeg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOverview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorik)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewOverview);
            this.splitContainer1.Panel1.Controls.Add(this.btnTilbage);
            this.splitContainer1.Panel1.Controls.Add(this.monthCalendar1);
            this.splitContainer1.Panel1.Controls.Add(this.lblKalender);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSlet);
            this.splitContainer1.Panel2.Controls.Add(this.btnRediger);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewNu);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewHistorik);
            this.splitContainer1.Panel2.Controls.Add(this.lblHistorik);
            this.splitContainer1.Panel2.Controls.Add(this.lblNuvaerende);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxMobil);
            this.splitContainer1.Panel2.Controls.Add(this.lblSoeg);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 381;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridViewOverview
            // 
            this.dataGridViewOverview.AllowUserToAddRows = false;
            this.dataGridViewOverview.AllowUserToDeleteRows = false;
            this.dataGridViewOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOverview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOverview.Location = new System.Drawing.Point(9, 227);
            this.dataGridViewOverview.Name = "dataGridViewOverview";
            this.dataGridViewOverview.ReadOnly = true;
            this.dataGridViewOverview.RowTemplate.Height = 25;
            this.dataGridViewOverview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOverview.Size = new System.Drawing.Size(369, 161);
            this.dataGridViewOverview.TabIndex = 9;
            // 
            // btnTilbage
            // 
            this.btnTilbage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTilbage.Location = new System.Drawing.Point(137, 394);
            this.btnTilbage.Name = "btnTilbage";
            this.btnTilbage.Size = new System.Drawing.Size(110, 44);
            this.btnTilbage.TabIndex = 0;
            this.btnTilbage.Text = "Tilbage";
            this.btnTilbage.UseVisualStyleBackColor = true;
            this.btnTilbage.Click += new System.EventHandler(this.btnTilbage_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(61, 50);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelectedV2);
            // 
            // lblKalender
            // 
            this.lblKalender.AutoSize = true;
            this.lblKalender.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKalender.Location = new System.Drawing.Point(147, 9);
            this.lblKalender.Name = "lblKalender";
            this.lblKalender.Size = new System.Drawing.Size(100, 27);
            this.lblKalender.TabIndex = 0;
            this.lblKalender.Text = "Kalender";
            // 
            // btnSlet
            // 
            this.btnSlet.Location = new System.Drawing.Point(276, 415);
            this.btnSlet.Name = "btnSlet";
            this.btnSlet.Size = new System.Drawing.Size(75, 23);
            this.btnSlet.TabIndex = 11;
            this.btnSlet.Text = "&Slet";
            this.btnSlet.UseVisualStyleBackColor = true;
            this.btnSlet.Click += new System.EventHandler(this.btnSlet_Click);
            // 
            // btnRediger
            // 
            this.btnRediger.Location = new System.Drawing.Point(86, 415);
            this.btnRediger.Name = "btnRediger";
            this.btnRediger.Size = new System.Drawing.Size(75, 23);
            this.btnRediger.TabIndex = 10;
            this.btnRediger.Text = "&Rediger";
            this.btnRediger.UseVisualStyleBackColor = true;
            this.btnRediger.Click += new System.EventHandler(this.btnRediger_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(276, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Søg";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_ClickV2);
            // 
            // dataGridViewNu
            // 
            this.dataGridViewNu.AllowUserToAddRows = false;
            this.dataGridViewNu.AllowUserToDeleteRows = false;
            this.dataGridViewNu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewNu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewNu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNu.Location = new System.Drawing.Point(22, 98);
            this.dataGridViewNu.Name = "dataGridViewNu";
            this.dataGridViewNu.ReadOnly = true;
            this.dataGridViewNu.RowTemplate.Height = 25;
            this.dataGridViewNu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewNu.Size = new System.Drawing.Size(369, 135);
            this.dataGridViewNu.TabIndex = 8;
            this.dataGridViewNu.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNu_CellContentDoubleClick);
            // 
            // dataGridViewHistorik
            // 
            this.dataGridViewHistorik.AllowUserToAddRows = false;
            this.dataGridViewHistorik.AllowUserToDeleteRows = false;
            this.dataGridViewHistorik.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewHistorik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewHistorik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistorik.Location = new System.Drawing.Point(22, 269);
            this.dataGridViewHistorik.Name = "dataGridViewHistorik";
            this.dataGridViewHistorik.ReadOnly = true;
            this.dataGridViewHistorik.RowTemplate.Height = 25;
            this.dataGridViewHistorik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistorik.Size = new System.Drawing.Size(369, 135);
            this.dataGridViewHistorik.TabIndex = 7;
            // 
            // lblHistorik
            // 
            this.lblHistorik.AutoSize = true;
            this.lblHistorik.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHistorik.Location = new System.Drawing.Point(173, 247);
            this.lblHistorik.Name = "lblHistorik";
            this.lblHistorik.Size = new System.Drawing.Size(60, 19);
            this.lblHistorik.TabIndex = 6;
            this.lblHistorik.Text = "Historik:";
            // 
            // lblNuvaerende
            // 
            this.lblNuvaerende.AutoSize = true;
            this.lblNuvaerende.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNuvaerende.Location = new System.Drawing.Point(164, 76);
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
            // textBoxMobil
            // 
            this.textBoxMobil.Location = new System.Drawing.Point(86, 50);
            this.textBoxMobil.Name = "textBoxMobil";
            this.textBoxMobil.Size = new System.Drawing.Size(164, 23);
            this.textBoxMobil.TabIndex = 3;
            // 
            // lblSoeg
            // 
            this.lblSoeg.AutoSize = true;
            this.lblSoeg.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSoeg.Location = new System.Drawing.Point(164, 9);
            this.lblSoeg.Name = "lblSoeg";
            this.lblSoeg.Size = new System.Drawing.Size(130, 27);
            this.lblSoeg.TabIndex = 2;
            this.lblSoeg.Text = "Søg booking";
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOverview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistorik)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private MonthCalendar monthCalendar1;
        private Label lblKalender;
        private Label lblNuvaerende;
        private Label label1;
        private TextBox textBoxMobil;
        private Label lblSoeg;
        private Label lblHistorik;
        private Button btnTilbage;
        private DataGridView dataGridViewNu;
        private DataGridView dataGridViewHistorik;
        private Button btnSearch;
        private DataGridView dataGridViewOverview;
        private Button btnSlet;
        private Button btnRediger;
    }
}