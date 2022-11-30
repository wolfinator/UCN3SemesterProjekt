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

        public BookingInfo(DateTime dateCalender, string hal, string bane)
        {
            InitializeComponent();

            _reservationService = new ReservationService();
            _customerService = new CustomerService();

            txtSted.Text = $"Hal {hal}, Bane {bane}";
            txtDato.Text = DateOnly.FromDateTime(dateCalender).ToString();
            txtKlok.Text = TimeOnly.FromDateTime(dateCalender).ToString();
        }

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

        private void btnBekraeft_Click(object sender, EventArgs e)
        {
            customerInformation.Clear();
            if (!String.IsNullOrEmpty(txtFornavn.Text))
            {
                customerInformation.Add(txtFornavn.Text);
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
                customerInformation.Add(txtEfternavn.Text);
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
                customerInformation.Add(txtMobil.Text);
            } else
            {
                string message = "Indtast et gyldigt telefonnummer!";
                string title = "Ugyldig telefonnummer";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }
            if (txtEmail.Text.Contains("@") && txtEmail.Text.Contains("."))
            {
                customerInformation.Add(txtEmail.Text);
            }
            else
            {
                string message = "Indtast en gyldig emailadresse!";
                string title = "Ugyldig Email!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                return;
            }
            customerInformation.Add(txtDato.Text);
            customerInformation.Add(txtKlok.Text);
            customerInformation.Add(txtSted.Text);
            customerInformation.Add(txtPris.Text);
            customerInformation.Add(comboBoxKetsjer.Text);
            if (checkBoxBold.Checked)
            {
                checkBoxBold.Text = "Ja";
                //TODO tilføj 50 kr til samlet invoice pris
            }
            else
            {
                checkBoxBold.Text = "Nej";
            }
            customerInformation.Add(checkBoxBold.Text);
            

            this.Hide();
            BookingBekræftelse bookingBekræftelse = new(customerInformation);
            bookingBekræftelse.ShowDialog();
        }

        private void btnBekraeft_ClickV2(object sender, EventArgs e)
        {
            Customer customer = new() { street="", houseNo= "", zipcode = ""};
            Invoice invoice = new();
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
            invoice.reservation = currentReservation;

            currentReservation.creationDate = DateTime.Now;
            if (_reservationService.Create(currentReservation) != -1)
            {
                this.Hide();
                BookingBekræftelse bookingBekræftelse = new(invoice);
                bookingBekræftelse.ShowDialog();
            }
            else
            {
                MessageBox.Show("Fejl ved oprettelse af reservation, prøv igen senere", "Fejl", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpretBooking opretBooking = new OpretBooking();
            opretBooking.ShowDialog();

        }

        private void UpdatePrice()
        {
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
