using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeSalesApp.Startup))]
namespace BikeSalesApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
