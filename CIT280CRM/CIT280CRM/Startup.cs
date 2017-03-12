using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CIT280CRM.Startup))]
namespace CIT280CRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
