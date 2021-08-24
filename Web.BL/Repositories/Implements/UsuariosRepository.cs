using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.BL.Data;
using Web.BL.Models;

namespace Web.BL.Repositories.Implements
{
    public class UsuariosRepository:GenericRepository<Usuarios>, IUsuariosRepository
    {
        public UsuariosRepository(ApiContext ApiContext) : base(ApiContext)
        {

        }
    }
}
