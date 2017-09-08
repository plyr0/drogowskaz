using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrogowskazSerwer.Startup))]
namespace DrogowskazSerwer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
