using Microsoft.Owin;
using Microsoft.Owin.Builder;

[assembly: OwinStartupAttribute(typeof(RexERP_MVC.Startup))]
namespace RexERP_MVC
{
    public partial class Startup
    {
        public void Configuration(AppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
