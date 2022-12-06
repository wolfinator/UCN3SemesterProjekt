using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpClient.Interfaces
{
    public interface IReservationService : IServiceCrud<Reservation>
    {
        List<AvailableTime> GetAvailableTimes(string date);
    }
}
