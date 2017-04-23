using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    interface IRepository<T> 
    {
        IEnumerable<T> Doctors();
        T GetById(T Id);
        void Insert(T doctor);
        void Update(T doctor);
        void Delete(T doctor);
        void Save();
    }
}
