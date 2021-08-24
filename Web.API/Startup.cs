using Microsoft.Owin;
using Owin;
using Web.BL.Data;

[assembly: OwinStartup(typeof(Web.API.Startup))]

namespace Web.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApiContext.Create);    
        }
    }
}
