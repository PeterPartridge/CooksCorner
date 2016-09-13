using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CooksCorner1._0.Startup))]
namespace CooksCorner1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
