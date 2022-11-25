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
    public partial class BookingBekræftelse : Form
    {
        private List<string> customerInformation;

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

        private void btnAfslut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();

        }
    }
}
