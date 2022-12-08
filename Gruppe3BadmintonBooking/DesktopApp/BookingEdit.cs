using Model;
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
    public partial class BookingEdit : Form
    {
        public Reservation editedReservation;
        public BookingEdit(Reservation reservation)
        {
            editedReservation = reservation;
            InitializeComponent();

            var customer = reservation.customer;

            txtFornavn.Text = customer.firstName;
            txtEfternavn.Text = customer.lastName;
            txtMobil.Text = customer.phoneNo;
            txtEmail.Text = customer.email;
            txtBane.Text = reservation.courtNo.ToString();
            txtBold.Text = reservation.shuttleReserved ? "Ja" : "Nej";
            txtDato.Text = reservation.startTime.ToShortDateString();
            txtTid.Text = $"{reservation.startTime.ToShortTimeString()}-{reservation.endTime.ToShortTimeString()}";
            txtKetsjer.Text = reservation.numberOfRackets.ToString();
        }

        private void btnSlet_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Customer editedCustomer = new()
            {
                id = editedReservation.id,
                firstName = txtFornavn.Text,
                lastName = txtEfternavn.Text,
                phoneNo = txtMobil.Text,
                email = txtEmail.Text,
                street = editedReservation.customer.street,
                houseNo = editedReservation.customer.houseNo,
                zipcode = editedReservation.customer.zipcode,
            };
            editedReservation.customer = editedCustomer;

            int newNumberOfRackets = editedReservation.numberOfRackets;
            if (int.TryParse(txtKetsjer.Text, out newNumberOfRackets))
            {
                editedReservation.numberOfRackets = newNumberOfRackets;
            }
        }
    }
}
