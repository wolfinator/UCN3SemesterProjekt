using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace DesktopApp
{
    public partial class OpretBooking : Form
    {
        DateTime dt;

        public OpretBooking()
        {
            InitializeComponent();
        }
        
        private void btnBookBane_Click_1(object sender, EventArgs e)
        {
            TimeSpan ts;
            //dt = monthCalendar1.SelectionStart;
            //ts = TimeSpan.Parse((string)comboKlok.SelectedItem);
            //dt = dt.Date + ts;
            if (comboKlok.SelectedIndex > -1)
            {
                dt = monthCalendarOverview.SelectionStart;
                ts = TimeSpan.Parse((string)comboKlok.SelectedItem);
                dt = dt.Date + ts;
                this.Hide();
                BookingInfo bookingInfo = new BookingInfo(dt);
                bookingInfo.ShowDialog();
            }
            else
            {
                string message = "Vælg tidspunkt!";
                string title = "Information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            //this.Hide();
            //BookingInfo bookingInfo = new BookingInfo(dt);
            //bookingInfo.ShowDialog();

        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
        }

        private void btnGetCourts_Click(object sender, EventArgs e)
        {
            dataGridViewCourts.Rows.Clear();
            dataGridViewCourts.ColumnCount = 2;
            dataGridViewCourts.Columns[0].Name = "Hal nummer:";
            dataGridViewCourts.Columns[1].Name = "Ledige baner:";
            string[] row = new string[] { "1", "3" };
            dataGridViewCourts.Rows.Add(row);
            row = new string[] { "2", "1" };
            dataGridViewCourts.Rows.Add(row);
            row = new string[] { "3", "2" };
            dataGridViewCourts.Rows.Add(row);
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewCourts.SelectedRows)
            {
                string value1 = row.Cells[0].Value.ToString();
                string value2 = row.Cells[1].Value.ToString();
                
            }
        }

        private void monthCalendarOverview_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }
    }
}
