namespace DesktopApp
{
    partial class Startside
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
            this.btnOpretBooking = new System.Windows.Forms.Button();
            this.btnBookingOversigt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpretBooking
            // 
            this.btnOpretBooking.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnOpretBooking.Font = new System.Drawing.Font("Times New Roman", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOpretBooking.Location = new System.Drawing.Point(0, 0);
            this.btnOpretBooking.Name = "btnOpretBooking";
            this.btnOpretBooking.Size = new System.Drawing.Size(396, 450);
            this.btnOpretBooking.TabIndex = 0;
            this.btnOpretBooking.Text = "Opret booking";
            this.btnOpretBooking.UseVisualStyleBackColor = true;
            this.btnOpretBooking.Click += new System.EventHandler(this.btnOpretBooking_Click);
            // 
            // btnBookingOversigt
            // 
            this.btnBookingOversigt.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnBookingOversigt.Font = new System.Drawing.Font("Times New Roman", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBookingOversigt.Location = new System.Drawing.Point(416, 0);
            this.btnBookingOversigt.Name = "btnBookingOversigt";
            this.btnBookingOversigt.Size = new System.Drawing.Size(384, 450);
            this.btnBookingOversigt.TabIndex = 1;
            this.btnBookingOversigt.Text = "Booking oversigt";
            this.btnBookingOversigt.UseVisualStyleBackColor = true;
            this.btnBookingOversigt.Click += new System.EventHandler(this.btnBookingOversigt_Click);
            // 
            // Startside
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBookingOversigt);
            this.Controls.Add(this.btnOpretBooking);
            this.Name = "Startside";
            this.Text = "Booking startside";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnOpretBooking;
        private Button btnBookingOversigt;
    }
}