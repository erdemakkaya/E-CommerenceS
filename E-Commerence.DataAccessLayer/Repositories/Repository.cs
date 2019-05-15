using E_Commerence.DataAccessLayer;
using E_Commerence.DataAccessLayer.Infastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerence.DataAccessLayer.Repositories
{
    public class Repository<T> : BaseRepository, IRepository<T> where T : class 
    {
        

        private DbSet<T> _objectSet;
        public Repository()
        {

            _objectSet = db.Set<T>();

        }
        
        public IEnumerable<T> List()
        {
            return _objectSet.ToList();


        }

        public void Save()
        {

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        string s=("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

        public T Insert(T obj)
        {

            var result= _objectSet.Add(obj);
            Save();
            return result;
        }
        public void Update(T obj)
        {

            Save();
        }





        public void Delete(T obj)
        {
            _objectSet.Remove(obj);
            Save();

        }
        public IQueryable<T> List(Expression<Func<T, bool>> where)
        {


            return _objectSet.Where(where) ;



        }

        public IQueryable<T> Include(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = null;

            if (includes.Length > 0)
            {
                query = _objectSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? _objectSet : (IQueryable<T>)query;
        }

      

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }



        public int Count()
        {
            return _objectSet.Count();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _objectSet.Any(expression);
            
        }

    }

}
