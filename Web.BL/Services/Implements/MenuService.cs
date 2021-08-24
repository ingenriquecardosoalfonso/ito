using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BL.Models;
using Web.BL.Repositories;
using Web.BL.Repositories.Implements;

namespace Web.BL.Services.Implements
{
    public class MenuService : GenericService<Menu>, IMenuService
    {
        public MenuService(IMenuRepository MenuRepository) : base(MenuRepository)
        {

        }
    }
}
