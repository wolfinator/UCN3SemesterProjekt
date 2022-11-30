using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDataAccess<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Update(T entity);
        bool DeleteById(int id);
        int Create(T entity);
      
    }
}
