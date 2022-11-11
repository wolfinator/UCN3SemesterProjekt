using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Court
    {
        public int courtNo { get; set; }

        public int id { get; set; }

        public int hallNo { get; set; }
        public bool isAvailable { get; set; }
        public TimeSpan timeInterval { get; set; }

        public Reservation reservation { get; set; }
    }
}
