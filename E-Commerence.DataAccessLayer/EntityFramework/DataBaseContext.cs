using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerence.DataAccessLayer.EntityFramwork
{
    public class DataBaseContext :  DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DataBaseContext() : base(@"Data Source = DESKTOP-0CI0TQT\EAKKAYA; Initial Catalog = ECommerence2; Persist Security Info=True;User ID = sa; Password=sa12345;MultipleActiveResultSets=True")
        {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext,E_Commerence.DataAccessLayer.Migrations.Configuration>());

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<AdminInfo> AdminInfo { get; set; }
        public DbSet<CartsProducts> CartsProducts { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<Logs>  Logs { get; set; }

      
    }
}
