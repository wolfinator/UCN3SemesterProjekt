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
            courts = courtService.GetAll();
        }
        


        private void btnBookBane_Click_1(object sender, EventArgs e)
        {
            TimeSpan ts;
            //dt = monthCalendar1.SelectionStart;
            //ts = TimeSpan.Parse((string)comboKlok.SelectedItem);
            //dt = dt.Date + ts;
            if (comboKlok.SelectedIndex > -1 && !hal.Equals("") && !bane.Equals(""))
            {
                st = monthCalendarOverview.SelectionStart;
                ts = TimeSpan.Parse((string)comboKlok.SelectedItem);
                st = st.Date + ts;
                this.Hide();
                BookingInfo bookingInfo = new BookingInfo(st, hal, bane);
                bookingInfo.ShowDialog();

                Reservation reservation = new Reservation();
                reservation.startTime = st;
                reservation.endTime = et;
                
            }
            else
            {
                string message = "Mangler tidspunkt og/eller bane/hal";
                string title = "Information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            //this.Hide();
            //BookingInfo bookingInfo = new BookingInfo(dt);
            //bookingInfo.ShowDialog();

        }

        private void btnBookBane_Click_2(object sender, EventArgs e)
        {
            if (selectedCourt != null && selectedDate != null && selectedTime != null)
            {
                this.Hide();

                // need to change so we only have one of the values
                currentReservation.courtNo = selectedCourt;
                currentReservation.court = new() { id = selectedCourt };

                currentReservation.startTime = selectedDate + selectedTime;
                currentReservation.endTime = selectedDate + selectedTime.Add(TimeSpan.FromHours(1));

                BookingInfo bookingInfo = new BookingInfo(currentReservation);
                bookingInfo.ShowDialog();
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
        }

        //private void btnGetCourts_Click(object sender, EventArgs e)
        //{
        //    dataGridViewCourts.Rows.Clear();
        //    dataGridViewCourts.ColumnCount = 2;
        //    dataGridViewCourts.Columns[0].Name = "Hal nummer:";
        //    dataGridViewCourts.Columns[1].Name = "Ledige baner:";
        //    string[] row = new string[] { "1", "3" };
        //    dataGridViewCourts.Rows.Add(row);
        //    row = new string[] { "2", "1" };
        //    dataGridViewCourts.Rows.Add(row);
        //    row = new string[] { "3", "2" };
        //    dataGridViewCourts.Rows.Add(row);
        //}

        private void monthCalendarOverview_DateSelected(object sender, DateRangeEventArgs e)
        {
            dataGridViewCourts.Rows.Clear();
            
            dataGridViewCourts.ColumnCount = 1;
            //dataGridViewCourts.Columns[0].Name = "Hal nummer:";
            dataGridViewCourts.Columns[0].Name = "Ledige baner:";
            //[] row = new string[] { "1", "3" };

            courts.ToList().ForEach(court => {
                string[] row = new string[] { court.id.ToString()/*, court.hallNo.ToString()*/ };
                dataGridViewCourts.Rows.Add(row);
                }
            );


            string[] row = new string[] { "1", "3" };
            dataGridViewCourts.Rows.Add(row);
            dataGridViewCourts.Rows[0].Cells[0].Selected = false;
        }

        private void monthCalendarOverview_DateSelectedRestService(object sender, DateRangeEventArgs e)
        {
            DateTime selected = monthCalendarOverview.SelectionStart;
            var availableTimes = Task.Run(()=>_reservationService.GetAvailableTimes(selected.Date.ToString()));

            ResetDataGrid();

            availableTimesData = availableTimes.Result;

            foreach (var available in availableTimesData)
            {
                dataGridViewCourts.Rows.Add(available);
            }
            selectedDate = selected.Date;
        }

        private void dataGridViewCourts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewCourts.SelectedRows)
            {
                hal = "1";
                bane = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridViewCourts_CellClickV2(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dataGridViewCourts.SelectedRows;
            selectedCourt = int.Parse(selectedRow[0].Cells[0].Value.ToString());
            selectedTime = TimeSpan.Parse(selectedRow[0].Cells[1].Value.ToString());
        }

        private void comboKlok_SelectedIndexChanged(object sender, EventArgs e)
        {
            fromTime = comboKlok.SelectedText;
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
