using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonsorcjumLekarzy.Services
{
    public interface IGenericService<T>
    {
        IList<T> EntietiesList();
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
