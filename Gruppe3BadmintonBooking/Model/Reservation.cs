using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime dateTime { get; set; }
        public TimeSpan fromTime { get; set; }
        public int courtNo { get; set; }
        public bool isEquipment { get; set; }
        public Person customer { get; set; }
        public Employee employee { get; set; }
        public Court court { get; set; }
    }


