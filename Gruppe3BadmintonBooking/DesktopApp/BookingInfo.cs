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

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            OpretBooking opretBooking = new OpretBooking();
            opretBooking.ShowDialog();

        }
    }
}
