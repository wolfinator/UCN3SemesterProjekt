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
        private SqlConnectionStringBuilder conStr;

        DateTime st;
        DateTime et;
        string fromTime;
        private string hal = "";
        private string bane = "";
        private CourtService courtService;
        public IEnumerable<Court> courts;

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

            courtService = new CourtService();
            //courts = courtService.GetAll();
        }

        private void btnBookBane_Click_2(object sender, EventArgs e)
        {
            if (selectedCourt != 0)
            {
                this.Hide();

                // need to change so we only have one of the values
                currentReservation.courtNo = selectedCourt;
                //currentReservation.court = new() { id = selectedCourt };

                currentReservation.startTime = selectedDate + selectedTime;
                currentReservation.endTime = selectedDate + selectedTime.Add(TimeSpan.FromHours(1));

                BookingInfo bookingInfo = new BookingInfo(currentReservation);
                bookingInfo.ShowDialog();
                this.Close();
            }
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
            monthCalendarOverview.Enabled = false;

            DateTime selected = monthCalendarOverview.SelectionStart;
            string selectedToString = selected.Date.ToString("yyyy-MM-dd");
            var availableTimes = Task.Run(()=>_reservationService.GetAvailableTimes(selectedToString));

            ResetDataGrid();

            availableTimesData = availableTimes.Result;

            foreach (var available in availableTimesData)
            {
                available[1] = ((DateTime)available[1]).ToString("HH:mm", CultureInfo.InvariantCulture);
                dataGridViewCourts.Rows.Add(available);
            }
            selectedDate = selected.Date;
            dataGridViewCourts.Rows[0].Cells[0].Selected = false;

            monthCalendarOverview.Enabled = true;
        }

        private void dataGridViewCourts_CellClickV2(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridViewCourts.SelectedRows;
            if(selectedRow.Count != 0)
            {
                selectedCourt = int.Parse(selectedRow[0].Cells[0].Value.ToString());
                selectedTime = TimeSpan.Parse(selectedRow[0].Cells[1].Value.ToString());
            }      
        }

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
