using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerence.DataAccessLayer.Infastructure
{
   public interface IRepository<T> where T: class
    {
        IEnumerable<T> List();
        //it return only one object
        
           
        T Find(Expression<Func<T, bool>> expression);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
        IQueryable<T> Include(params Expression<Func<T, object>>[] includes);
        T Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        int Count();
        void Save();

        bool Any(Expression<Func<T, bool>> expression);
    }
}
