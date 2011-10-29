using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tournament_Planner.BL
{
    public interface IRepository<T>
    {
        void Add(T item);

        T GetById(int id);
    }
}
