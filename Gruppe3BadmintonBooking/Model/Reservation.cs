using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
    public class Reservation
    {

        public int Id { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; } 
        public int courtNo { get; set; }
        public bool shuttleReserved { get; set; }
        public Customer customer { get; set; }
        public int ?numberOfRackets { get; set; }
    }


