using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Invoice
    {
        public decimal totalPrice { get; set; }
        public int orderNo { get; set; }
        public String name { get; set; }
        public DateTime dateTime { get; set; }
        public int courtNo { get; set; }
        public String phoneNo { get; set; }
        public Employee employee { get; set; }
        public Reservation reservation { get; set; }
    }
}
