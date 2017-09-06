using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Drogowskaz.Startup))]
namespace Drogowskaz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
