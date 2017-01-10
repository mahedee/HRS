using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRS.Startup))]
namespace HRS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
