using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Invoice
    {
        public int id { get; set; }
        public decimal totalPrice { get; set; }
        
      //  public Employee employee { get; set; }

       // public Person person { get; set; }
        public Reservation reservation { get; set; }
    }
}
