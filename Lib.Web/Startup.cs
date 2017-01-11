using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lib.Web.Startup))]
namespace Lib.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
