using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DM.DZ1.Startup))]
namespace DM.DZ1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
