using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BL.Data;
using Web.BL.Models;

namespace Web.BL.Repositories.Implements
{
    public class MenuRepository : GenericRepository<Menu>, IMenuRepository
    {
        private readonly ApiContext apiContext;


        public MenuRepository(ApiContext ApiContext) : base(ApiContext)
        {
            this.apiContext = ApiContext;
        }

        
    }
}
