using System;
using System.Collections.Generic;
using KonsorcjumLekarzy.Database.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonsorcjumLekarzy.Database.Repository;
using System.Data.Entity;

namespace KonsorcjumLekarzy.Database.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        private readonly ModelCustomContext dbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository()
        {
            dbContext = new ModelCustomContext();
            dbSet = dbContext.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(object ID)
        {
            return dbSet.Find(ID);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public void Delete(T entity)
        {
            T getObjByID = dbSet.Find(entity);
            dbSet.Remove(getObjByID);
            Save();
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }     
    }
}
