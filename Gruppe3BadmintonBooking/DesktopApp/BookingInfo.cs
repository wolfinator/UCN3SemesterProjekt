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
        List<string> customerInformation = new();

        public BookingInfo(DateTime dateCalender)
        {
            InitializeComponent();
            txtDato.Text = DateOnly.FromDateTime(dateCalender).ToString();
            txtKlok.Text = TimeOnly.FromDateTime(dateCalender).ToString();
        }

        private void btnBekraeft_Click(object sender, EventArgs e)
        {
            customerInformation.Add(txtFornavn.Text);
            customerInformation.Add(txtEfternavn.Text);
            customerInformation.Add(txtMobil.Text);
            customerInformation.Add(txtEmail.Text);
            customerInformation.Add(txtDato.Text);
            customerInformation.Add(txtKlok.Text);
            customerInformation.Add(txtSted.Text);
            customerInformation.Add(txtPris.Text);

            this.Hide();
            BookingBekræftelse bookingBekræftelse = new(customerInformation);
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
