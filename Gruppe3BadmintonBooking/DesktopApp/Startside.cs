using Model;
using System.Data.SqlClient;

namespace DesktopApp
{
    public partial class Startside : Form
    {

        public static SqlConnectionStringBuilder conStr = new SqlConnectionStringBuilder()
        { DataSource = "hildur.ucn.dk", InitialCatalog = "DMA-CSD-S212_10407522", Encrypt = false, UserID = "DMA-CSD-S212_10407522", Password = "Password1!" };

        public Startside()
        {
            InitializeComponent();

            //Reservation reservation = new(reservation.dateTime, 1, true, );
        }

        private void btnOpretBooking_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpretBooking opretBooking = new OpretBooking();
            opretBooking.ShowDialog();
            

        }

        private void btnBookingOversigt_Click(object sender, EventArgs e)
        {
            this.Hide();
            BookingOversigt bookingOversigt = new();
            bookingOversigt.ShowDialog();
        }
    }
}