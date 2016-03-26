using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDateRoute.Startup))]
namespace MVCDateRoute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
