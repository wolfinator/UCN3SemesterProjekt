using Model;
using System.Data.SqlClient;

namespace DesktopApp
{
    public partial class Startside : Form
    {

        public Startside()
        {
            InitializeComponent();
        }

        private void btnOpretBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpretBooking opretBooking = new OpretBooking();
            opretBooking.ShowDialog();
            this.Close();
        }

        private void btnBookingOversigt_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingOversigt bookingOversigt = new();
            bookingOversigt.ShowDialog();
            this.Close();
        }
    }
}