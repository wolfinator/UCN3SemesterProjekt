using Model;

namespace DesktopApp
{
    public partial class Startside : Form
    {
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