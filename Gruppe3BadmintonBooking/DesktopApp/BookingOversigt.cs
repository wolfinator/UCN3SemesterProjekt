using Model;
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
        private ICustomerService _customerService;
        public BookingOversigt()
        {
            InitializeComponent();

            _reservationService = new ReservationService();
            _customerService = new CustomerService();
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            GoBack();
        }

        private void GoBack()
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
            this.Close();
        }

        private void btnSearch_ClickV2(object sender, EventArgs e)
        {
            UpdateSearchOverview();
        }

        private void UpdateSearchOverview()
        {
            var phoneNo = textBoxMobil.Text;
            var currentBookings = Task.Run(() => _reservationService.GetAllByPhoneNo(phoneNo));
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
                    if (reservation.endTime < today)
                    {
                        dataGridViewHistorik.Rows.Add(row);
                    }
                    else
                    {
                        dataGridViewNu.Rows.Add(row);
                    }

                });
        }

        private void monthCalendar1_DateSelectedV2(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.Enabled = false;
            Task.Run(UpdateReservationsOverview);        
        }

        private void UpdateReservationsOverview()
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
                    Invoke(() => dataGridViewOverview.Rows.Add(row));
                });
            Invoke(() => monthCalendar1.Enabled = true);
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
            DeleteBooking();
        }

        private void DeleteBooking()
        {
            string message = "Er du sikker på at du vil slette denne booking?";
            string title = "Slet booking";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult res = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

            var selectedRow = dataGridViewNu.SelectedRows[0];

            if (res == DialogResult.Yes)
            {
                _reservationService.DeleteById(Convert.ToInt32(selectedRow.Cells[0].Value));
                UpdateSearchOverview();
            }
        }

        private void btnRediger_Click(object sender, EventArgs e)
        {
            EditBooking();
        }

        private void EditBooking()
        {
            var selectedRow = dataGridViewNu.SelectedRows[0];
            var reservation = _reservationService.GetById(Convert.ToInt32(selectedRow.Cells[0].Value));

            var BookingEditDialog = new BookingEdit(reservation);
            var res = BookingEditDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                _customerService.Update(BookingEditDialog.editedReservation.customer);
                _reservationService.Update(BookingEditDialog.editedReservation);
            }
            else if (res == DialogResult.Ignore)
            {
                DeleteBooking();
            }
            BookingEditDialog.Dispose();
            UpdateSearchOverview();
        }
    }
}
