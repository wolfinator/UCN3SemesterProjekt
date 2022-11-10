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
            dt = monthCalendar1.SelectionStart;
            ts = TimeSpan.Parse((string)comboKlok.SelectedItem);
            dt = dt.Date + ts;
            this.Hide();
            BookingInfo bookingInfo = new BookingInfo(dt);
            bookingInfo.ShowDialog();

        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
        }
    }
}
