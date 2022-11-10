using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class BookingInfo : Form
    {
        public BookingInfo()
        {
            InitializeComponent();
        }

        private void btnBekraeft_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingBekræftelse bookingBekræftelse = new();
            bookingBekræftelse.ShowDialog();
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpretBooking opretBooking = new OpretBooking();
            opretBooking.ShowDialog();

        }
    }
}
