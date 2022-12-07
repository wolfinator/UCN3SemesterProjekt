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
        public BookingEdit(Reservation reservation)
        {
            InitializeComponent();

            var customer = reservation.customer;

            txtNavn.Text = customer.firstName;
            txtMobil.Text = customer.phoneNo;
            txtEmail.Text = customer.email;
            txtBane.Text = reservation.courtNo.ToString();
            txtBold.Text = reservation.shuttleReserved ? "Ja" : "Nej";
            txtDato.Text = reservation.startTime.ToShortDateString();
            txtTid.Text = $"{reservation.startTime.ToShortTimeString()}-{reservation.endTime.ToShortTimeString()}";
            txtKetsjer.Text = reservation.numberOfRackets.ToString();
            txtHal.Text = "1";
        }

    }
}
