using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(appfutebol.Site.Startup))]
namespace appfutebol.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
