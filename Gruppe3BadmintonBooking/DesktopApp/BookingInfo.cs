using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using RestSharpClient;
using RestSharpClient.Interfaces;

namespace DesktopApp
{
    public partial class BookingInfo : Form
    {
        List<string> customerInformation = new();

        private IReservationService _reservationService;
        private ICustomerService _customerService;

        private Reservation currentReservation;
        private int BasePrice = 150;

        public BookingInfo(Reservation reservation)
        {
            InitializeComponent();

            _reservationService = new ReservationService();
            _customerService = new CustomerService();

            txtSted.Text = $"Bane {reservation.courtNo}";
            txtDato.Text = $"{DateOnly.FromDateTime(reservation.startTime)}";
            txtKlok.Text = $"{reservation.startTime.TimeOfDay} - {reservation.endTime.TimeOfDay}";
            UpdatePrice();
            comboBoxKetsjer.SelectedIndex = 0;

            currentReservation = reservation;
        }

        private void btnBekraeft_ClickV2(object sender, EventArgs e)
        {
            // Sæt adressen til tomme strenge i stedet for den default værdi null
            // så rest sharp ikke klager og laver en Bad Request exception
            Customer customer = new() { street="", houseNo= "", zipcode = ""};
            Invoice invoice = new();

            // Valdidering, burde nok blevet lavet lidt pænere
            if (!String.IsNullOrEmpty(txtFornavn.Text))
            {
                customer.firstName = txtFornavn.Text;
            }
            else
            {
                string message = "Indtast et fornavn!";
                string title = "Mangler fornavn";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }

            if (!String.IsNullOrEmpty(txtEfternavn.Text))
            {
                customer.lastName = txtEfternavn.Text;
            }
            else
            {
                string message = "Indtast et efternavn!";
                string title = "Mangler efternavn";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }
            if (txtMobil.TextLength == 8)
            {
                customer.phoneNo = txtMobil.Text;
            }
            else
            {
                string message = "Indtast et gyldigt telefonnummer!";
                string title = "Ugyldig telefonnummer";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }
            if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."))
            {
                customer.email = txtEmail.Text;
            }
            else
            {
                string message = "Indtast en gyldig emailadresse!";
                string title = "Ugyldig Email!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }
            currentReservation.numberOfRackets = int.Parse(comboBoxKetsjer.SelectedItem.ToString());
            currentReservation.shuttleReserved = checkBoxBold.Checked;

            customer.id = _customerService.Create(customer);
            currentReservation.customer = customer;
            invoice.totalPrice = GetPrice();

            try
            {
                currentReservation.creationDate = DateTime.Now;
                currentReservation.id = _reservationService.Create(currentReservation);
                invoice.reservation = currentReservation;
                if (currentReservation.id != -1)
                {
                    this.Hide();
                    BookingBekræftelse bookingBekræftelse = new(invoice);
                    bookingBekræftelse.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Den valgte tid er allerede blevet booket", "Meddelse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fejl ved oprettelse af reservation, prøv igen senere", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                OpretBooking opretBooking = new();
                opretBooking.ShowDialog();
                this.Close();
            }
            
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpretBooking opretBooking = new OpretBooking();
            opretBooking.ShowDialog();
            // Close så vinduet bliver LUKKET og ikke kun SKJULT
            this.Close();
        }

        private void UpdatePrice()
        {
            // parametrene til ToString metoden "C2" og "da-DK" betyder den formatere pris variablen,
            // til at have 2 decimaler (,00) og sætter ",- kr" på
            string priceText = GetPrice().ToString("C2", CultureInfo.CreateSpecificCulture("da-DK"));

            txtPris.Text = priceText;
        }

        private void checkBoxBold_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }

        private decimal GetPrice()
        {
            return (BasePrice + (checkBoxBold.Checked ? 50 : 0));
        }
    }
}
