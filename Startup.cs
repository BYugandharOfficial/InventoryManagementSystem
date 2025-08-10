using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inventory_Mnagement_System.Startup))]
namespace Inventory_Mnagement_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
