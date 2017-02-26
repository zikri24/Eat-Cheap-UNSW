
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext context;

        public Repository()
        {
            context = new DataContext();
        }
        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> filter)
        {
            return context.Set<T>().Where(filter);
        }

        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Save()
        {
            context.SaveChanges();
        }
        /*public T FindByUserNmae(String email)
        {
            return context.Set<T>().Find(id); ;
        }*/
    }
}
