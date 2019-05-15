using E_Commerence.DataAccessLayer.EntityFramwork;
using E_Commerence.DataAccessLayer.Infastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerence.DataAccessLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork()
        {

            CartProducts = new CartsProductsRepository();
            Carts = new CartRepository();
            Categories = new CategoryRepository();
            Orders = new OrderRepository();
            Sliders = new SliderRepository();
            Admins = new AdminRepository();
            Producsts = new ProductsRepository();
            Users = new UserRepository();
            Logs = new LogsRepository();
        }

        public IAdminInfoRepository Admins { get; private set; }




        public ICartsProductsRepository CartProducts { get; private set; }

        public ICartRepository Carts { get; private set; }


        public ICategoryRepository Categories { get; private set; }


        public IOrderRepository Orders { get; private set; }


        public IProductsRepository Producsts { get; private set; }


        public ISliderRepository Sliders { get; private set; }
        public IUserRepository Users { get; private set; }
        public ILogsRepository Logs { get; set; }


        public int Complete()
        {
            return 1;
        }

        public void Dispose()
        {

        }
    }
}
