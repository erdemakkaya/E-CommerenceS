using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerence.DataAccessLayer.Infastructure
{
   public  interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICartRepository Carts { get; }
        ICartsProductsRepository CartProducts { get; }

        IProductsRepository Producsts { get; }

        ISliderRepository Sliders { get; }
        IOrderRepository Orders { get; }
        IAdminInfoRepository Admins { get; }
        IUserRepository Users { get; }
        ILogsRepository Logs { get; }
        int Complete();


    }
}
