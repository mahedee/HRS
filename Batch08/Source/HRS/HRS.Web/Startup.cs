using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRS.Web.Startup))]
namespace HRS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
