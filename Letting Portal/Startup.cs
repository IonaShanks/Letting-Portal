using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Letting_Portal.Startup))]
namespace Letting_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
