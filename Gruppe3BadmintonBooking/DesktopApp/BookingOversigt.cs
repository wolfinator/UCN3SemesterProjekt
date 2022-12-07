using RestSharpClient;
using RestSharpClient.Interfaces;
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
    public partial class BookingOversigt : Form
    {
        private IReservationService _reservationService;
        public BookingOversigt()
        {
            InitializeComponent();

            _reservationService = new ReservationService();
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewNu.Rows.Clear();
            dataGridViewNu.ColumnCount = 4;
            dataGridViewNu.Columns[0].Name = "Dato:";
            dataGridViewNu.Columns[1].Name = "Tidspunkt:";
            dataGridViewNu.Columns[2].Name = "Hal:";
            dataGridViewNu.Columns[3].Name = "Bane:";
            string[] rowNu = new string[] { "12-12-2022", "11.00-12.00", "1", "3" };
            dataGridViewNu.Rows.Add(rowNu);
            //row = new string[] { "24-11-2022", "14.00-15.00", "2", "1" };
            //dataGridViewNu.Rows.Add(row);
            //row = new string[] { "24-12-2022", "09.00-10.00", "3", "2" };
            //dataGridViewNu.Rows.Add(row);

            dataGridViewHistorik.Rows.Clear();
            dataGridViewHistorik.ColumnCount = 4;
            dataGridViewHistorik.Columns[0].Name = "Dato:";
            dataGridViewHistorik.Columns[1].Name = "Tidspunkt:";
            dataGridViewHistorik.Columns[2].Name = "Hal:";
            dataGridViewHistorik.Columns[3].Name = "Bane:";
            string[] rowHistorik = new string[] { "13-11-2022", "09.00-10.00", "2", "1" };
            dataGridViewHistorik.Rows.Add(rowHistorik);
        }

        private void btnSearch_ClickV2(object sender, EventArgs e)
        {
            var phoneNo = textBoxMobil.Text;
            var currentBookings = Task.Run(()=>_reservationService.GetAllByPhoneNo(phoneNo));
            ClearDataGridNuHistorik();

            currentBookings.Result.ToList()
                .ForEach(reservation =>
                {
                    var today = DateTime.Now;
                    var row = new string[]
                    {
                        reservation.id.ToString(),
                        reservation.startTime.Date.ToString(),
                        $"{reservation.startTime.ToShortTimeString()}-{reservation.endTime.ToShortTimeString()}",
                        reservation.courtNo.ToString()
                    };
                    if(reservation.endTime < today)
                    {
                        dataGridViewHistorik.Rows.Add(row);
                    }
                    else
                    {
                        dataGridViewNu.Rows.Add(row);
                    }
                    
                });
        }

        //private void monthCalendarOverview_DateChanged(object sender, DateRangeEventArgs e)
        //{
        //    dataGridViewOverview.ColumnCount = 5;
        //    dataGridViewOverview.Columns[0].Name = "Navn:";
        //    dataGridViewOverview.Columns[1].Name = "Mobil nr.:";
        //    dataGridViewOverview.Columns[2].Name = "Tidspunkt:";
        //    dataGridViewOverview.Columns[3].Name = "Hal:";
        //    dataGridViewOverview.Columns[4].Name = "Bane:";
        //    string[] rowOverview = new string[] { "Anna Falgren", "88888888", "10.00-11.00", "1", "3" };
        //    dataGridViewOverview.Rows.Add(rowOverview);
        //}

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            ClearDataGridOverview();

            string[] rowOverview = new string[] { "Anna Falgren", "88888888", "10.00-11.00", "3" };
            dataGridViewOverview.Rows.Add(rowOverview);
        }

        private void monthCalendar1_DateSelectedV2(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Enabled = false;
            Task.Run(() =>
            {
                var reservations = Task.Run(_reservationService.GetAll); // Should probably be by date in the future
                var selectedDate = monthCalendar1.SelectionStart;

                ClearDataGridOverview();

                reservations.Result.ToList()
                    .Where((reservation) => reservation.startTime.Date == selectedDate.Date).ToList()
                    .ForEach((reservation) =>
                    {

                        string[] row = new string[]
                    {
                    $"{reservation.customer.firstName} {reservation.customer.lastName}",
                    reservation.customer.phoneNo,
                    $"{reservation.startTime.ToShortTimeString()}-{reservation.endTime.ToShortTimeString()}",
                    reservation.courtNo.ToString()
                    };
                        Invoke(()=>dataGridViewOverview.Rows.Add(row));
                    });
                Invoke(()=>monthCalendar1.Enabled = true);
            });         
        }

        private void dataGridViewNu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearDataGridOverview()
        {
            if (InvokeRequired)
            {
                Invoke(ClearDataGridOverview);
            }
            else
            {
                dataGridViewOverview.Rows.Clear();
                dataGridViewOverview.ColumnCount = 4;
                dataGridViewOverview.Columns[0].Name = "Navn:";
                dataGridViewOverview.Columns[1].Name = "Mobil nr.:";
                dataGridViewOverview.Columns[2].Name = "Tidspunkt:";
                dataGridViewOverview.Columns[3].Name = "Bane:";
            }      
        }

        private void ClearDataGridNuHistorik()
        {
            if (InvokeRequired)
            {
                Invoke(ClearDataGridNuHistorik);
            }
            else
            {
                dataGridViewNu.Rows.Clear();
                dataGridViewNu.ColumnCount = 4;
                dataGridViewNu.Columns[0].Name = "Id:";
                dataGridViewNu.Columns[1].Name = "Dato:";
                dataGridViewNu.Columns[2].Name = "Tidspunkt:";
                dataGridViewNu.Columns[3].Name = "Bane:";

                dataGridViewHistorik.Rows.Clear();
                dataGridViewHistorik.ColumnCount = 4;
                dataGridViewHistorik.Columns[0].Name = "Id:";
                dataGridViewHistorik.Columns[1].Name = "Dato:";
                dataGridViewHistorik.Columns[2].Name = "Tidspunkt:";
                dataGridViewHistorik.Columns[3].Name = "Bane:";
            }
        }

        private void btnSlet_Click(object sender, EventArgs e)
        {
            string message = "Er du sikker på at du vil slette denne booking?";
            string title = "Slet booking";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

            var selectedRow = dataGridViewNu.SelectedRows[0];

            if(res == DialogResult.Yes)
            {
                _reservationService.DeleteById(Convert.ToInt32(selectedRow.Cells[0].Value));
                btnSearch_ClickV2(sender, e);
            }
        }
    }
}
