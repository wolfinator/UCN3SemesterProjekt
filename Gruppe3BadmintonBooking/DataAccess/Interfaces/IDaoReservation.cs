using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IDaoReservation : IDaoCrud<Reservation>
    {
        public bool DeleteAllByCustomerId(int customerId);

        public List<object[]> GetAvailableTimes(DateTime date);

        public IEnumerable<Reservation> GetAllByPhoneNo(string phoneNo);
    }
}
