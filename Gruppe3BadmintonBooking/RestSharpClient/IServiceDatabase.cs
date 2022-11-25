using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpClient
{
    public interface IServiceDatabase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        bool Update(T entity);
        bool DeleteById(int id);
        bool Create(T entity);
    }
}
