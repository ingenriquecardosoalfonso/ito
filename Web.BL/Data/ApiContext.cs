using System.Data.Entity;
using Web.BL.Models;

namespace Web.BL.Data
{
    public class ApiContext:DbContext
    {
        private static ApiContext apiContext = null;
        public ApiContext()
            :base("ApiContext")
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Menu> Menu { get; set; }

        public static ApiContext Create()
        {
            if (apiContext == null)
                apiContext = new ApiContext();

            return new ApiContext();
        }
    }
}
