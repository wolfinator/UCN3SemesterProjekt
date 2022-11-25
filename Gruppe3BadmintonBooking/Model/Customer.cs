using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public int id { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String phoneNo { get; set; }
        public String street { get; set; }
        public String houseNo { get; set; }
        public String zipcode { get; set; }
        public String address { get { return $"{street} {houseNo}, {zipcode}"; } }
        public List<Reservation> reservations { get; set; }

    }
}
