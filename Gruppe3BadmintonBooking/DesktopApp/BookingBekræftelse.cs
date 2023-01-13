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
        private IInvoiceService _invoiceService;

        public BookingBekræftelse(Invoice invoice)
        {
            InitializeComponent();

            _invoiceService = new InvoiceService();

            // Tildele nogle properties til nemmere/kortere variable navne for nemmere adgang
            Reservation reservation = invoice.reservation;
            Customer customer = reservation.customer;

            // Sæt tekst i winformen
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

            // Lav en invoice i databasen
            _invoiceService.Create(invoice);
        }

        private void btnAfslut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
            // Luk vinduet så der ikke pludselig er mange usynlige vinduer der æder (dog meget lidt) hukommelse
            this.Close();
        }
    }
}
