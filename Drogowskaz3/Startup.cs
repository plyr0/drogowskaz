using Microsoft.Owin;
using Owin;
using WebApplication1.Helpers;

[assembly: OwinStartupAttribute(typeof(WebApplication1.Startup))]
namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            System.Data.Entity.Database.SetInitializer<drogowskazEntities>(new SeedEntities());
        }
    }
}
