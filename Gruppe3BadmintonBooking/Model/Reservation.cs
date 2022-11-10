using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        public DateTime dateTime { get; set; }
        public int courtNo { get; set; }
        public bool isEquipment { get; set; }
        public Person customer { get; set; }
        public Employee employee { get; set; }
        public Court court { get; set; }

        public Reservation(DateTime dateTime, int courtNo, bool isEquipment, Person customer)
        {
            this.dateTime = dateTime;
            this.courtNo = courtNo;
            this.isEquipment = isEquipment;
            this.customer = customer;
        }
    }
}
