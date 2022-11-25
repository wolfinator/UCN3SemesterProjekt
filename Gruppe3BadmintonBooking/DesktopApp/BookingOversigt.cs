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
        public BookingOversigt()
        {
            InitializeComponent();
        }

        private void btnTilbage_Click(object sender, EventArgs e)
        {
            this.Hide();
            Startside startside = new();
            startside.ShowDialog();
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
            dataGridViewOverview.Rows.Clear();
            dataGridViewOverview.ColumnCount = 5;
            dataGridViewOverview.Columns[0].Name = "Navn:";
            dataGridViewOverview.Columns[1].Name = "Mobil nr.:";
            dataGridViewOverview.Columns[2].Name = "Tidspunkt:";
            dataGridViewOverview.Columns[3].Name = "Hal:";
            dataGridViewOverview.Columns[4].Name = "Bane:";
            string[] rowOverview = new string[] { "Anna Falgren", "88888888", "10.00-11.00", "1", "3" };
            dataGridViewOverview.Rows.Add(rowOverview);
        }

        private void dataGridViewNu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
