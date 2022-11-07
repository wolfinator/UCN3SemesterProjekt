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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBookBane = new System.Windows.Forms.Button();
            this.btnTilbage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(105, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dato:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(105, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kalender:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(196, 17);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(196, 206);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(456, 199);
            this.listBox1.TabIndex = 3;
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
            // OpretBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTilbage);
            this.Controls.Add(this.btnBookBane);
            this.Controls.Add(this.listBox1);
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
        private ListBox listBox1;
        private Button btnBookBane;
        private Button btnTilbage;
    }
}