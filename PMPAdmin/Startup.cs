using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMPAdmin.Startup))]
namespace PMPAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
