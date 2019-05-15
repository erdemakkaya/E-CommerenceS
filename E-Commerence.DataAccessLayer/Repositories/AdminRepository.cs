using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using E_Commerence.DataAccessLayer.Infastructure;
using E_Commerence.DataAccessLayer.EntityFramwork;

namespace E_Commerence.DataAccessLayer.Repositories
{
    public class AdminRepository : Repository<AdminInfo>,IAdminInfoRepository
    {
      
    }
}
