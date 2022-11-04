﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal interface IDataAccess<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Update(T entity);
        void DeleteById(int id);
        void Create(T entity);
      
    }
}
