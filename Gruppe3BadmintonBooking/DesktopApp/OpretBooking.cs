using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using Model;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RestSharpClient;
using RestSharpClient.Interfaces;
using System.Globalization;

namespace DesktopApp
{
    public partial class OpretBooking : Form
    {
        private IReservationService _reservationService;
        private Reservation currentReservation;
        private List<object[]> availableTimesData;

        private int selectedCourt;
        private TimeSpan selectedTime;
        private DateTime selectedDate;

        public OpretBooking()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
            currentReservation = new();
        }

        private void btnBookBane_Click_2(object sender, EventArgs e)
        {
            // Hvis der er vaglt en bane
            if (selectedCourt != 0)
            {
                this.Hide();

                // Sæt data på den nuværende reservation før den sendes videre til næste winform
                currentReservation.courtNo = selectedCourt;
                currentReservation.startTime = selectedDate + selectedTime;
                currentReservation.endTime = selectedDate + selectedTime.Add(TimeSpan.FromHours(1));

                BookingInfo bookingInfo = new BookingInfo(currentReservation);
                bookingInfo.ShowDialog();
                this.Close();
            }
            // Ellers oplys fejl til brugeren
            else
            {
                string message = "Mangler tidspunkt og/eller bane/hal";
                string title = "Information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
            this.Close();
        }

        private void monthCalendarOverview_DateSelectedRestService(object sender, DateRangeEventArgs e)
        {
            // Slå den fra så man ikke kan starte flere på samme tid
            monthCalendarOverview.Enabled = false;

            DateTime selected = monthCalendarOverview.SelectionStart;
            string selectedToString = selected.Date.ToString("yyyy-MM-dd");
            var availableTimes = Task.Run(()=>_reservationService.GetAvailableTimes(selectedToString));

            ResetDataGrid();

            availableTimesData = availableTimes.Result;

            foreach (var available in availableTimesData)
            {
                // InvariantCulture skal med ellers tror nogle computere at de kan skrive HH:mm som HH.mm,
                // men det kan TimeSpan.Parse ikke klare
                available[1] = ((DateTime)available[1]).ToString("HH:mm", CultureInfo.InvariantCulture);
                dataGridViewCourts.Rows.Add(available);
            }
            selectedDate = selected.Date;
            dataGridViewCourts.Rows[0].Cells[0].Selected = false;

            // Slå til så man kan se en anden dato
            monthCalendarOverview.Enabled = true;
        }

        private void dataGridViewCourts_CellClickV2(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridViewCourts.SelectedRows;
            // Tjekker at der er værdier i den række man har valgt
            if(selectedRow.Count != 0)
            {
                selectedCourt = int.Parse(selectedRow[0].Cells[0].Value.ToString());
                selectedTime = TimeSpan.Parse(selectedRow[0].Cells[1].Value.ToString());
            }      
        }

        // Metoden der filterer efter tidspunkt. Henter ikke noget fra Databasen,
        // men sortere blot i de eksisterende data der er hentet fra datoen
        private void comboKlok_SelectedIndexChangedV2(object sender, EventArgs e)
        {
            var selectedTimeFilter = DateTime.Parse((string) comboKlok.SelectedItem).TimeOfDay;

            ResetDataGrid();
            foreach (var data in availableTimesData)
            {
                if (TimeSpan.Parse(data[1].ToString()) == selectedTimeFilter) dataGridViewCourts.Rows.Add(data);
            }
        }

        private void ResetDataGrid()
        {
            dataGridViewCourts.Rows.Clear();

            dataGridViewCourts.ColumnCount = 2;
            dataGridViewCourts.Columns[0].Name = "Bane";
            dataGridViewCourts.Columns[1].Name = "Tidspunkt";
        }
    }
}
