using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Member : Person
    {
        public List<Reservation> reservations { get; set; }
    }
}
