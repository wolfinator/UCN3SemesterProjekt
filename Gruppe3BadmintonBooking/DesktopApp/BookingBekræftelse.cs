using Model;
using RestSharpClient;
using RestSharpClient.Interfaces;
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

namespace DesktopApp
{
    public partial class BookingBekræftelse : Form
    {
        private List<string> customerInformation;
        private IInvoiceService _invoiceService;
        public BookingBekræftelse(List<string> customerInformation)
        {
            InitializeComponent();
            this.customerInformation = customerInformation;
            txtFornavn.Text = customerInformation[0];
            txtEfternavn.Text = customerInformation[1];
            txtMobil.Text = customerInformation[2];
            txtEmail.Text = customerInformation[3];
            txtDato.Text = customerInformation[4];
            txtKlok.Text = customerInformation[5];
            txtSted.Text = customerInformation[6];
            txtPris.Text = customerInformation[7];
            txtKetsjer.Text = customerInformation[8];
            txtBold.Text = customerInformation[9];
        }

        public BookingBekræftelse(Invoice invoice)
        {
            InitializeComponent();

            _invoiceService = new InvoiceService();

            Reservation reservation = invoice.reservation;
            Customer customer = reservation.customer;

            txtFornavn.Text = customer.firstName;
            txtEfternavn.Text = customer.lastName;
            txtMobil.Text = customer.phoneNo;
            txtEmail.Text = customer.email;
            txtDato.Text = reservation.startTime.Date.ToShortDateString();
            txtKlok.Text = $"{reservation.startTime.ToShortTimeString()} - {reservation.endTime.ToShortTimeString()}";
            txtSted.Text = $"Bane {reservation.courtNo}";
            txtPris.Text = invoice.totalPrice.ToString("C2", CultureInfo.CreateSpecificCulture("da-DK"));
            txtKetsjer.Text = reservation.numberOfRackets.ToString();
            txtBold.Text = reservation.shuttleReserved ? "Ja" : "Nej";

            _invoiceService.Create(invoice);
        }

        private void btnAfslut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();

        }
    }
}
