using E_Commerence.DataAccessLayer.EntityFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerence.DataAccessLayer.Repositories
{ 
   public  class BaseRepository
    {
        protected static DataBaseContext db;
        private static object locker = new object();
        
        protected BaseRepository()
        {
            db = CreateContext();

        }

        public static DataBaseContext CreateContext()
        {
            if(db==null){

                lock (locker)
                {
                    db = new DataBaseContext();
                }
             
            }

            return db;
        }

    }
}
