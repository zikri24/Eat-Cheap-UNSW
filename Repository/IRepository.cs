using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
        T FindById(int id);       
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
