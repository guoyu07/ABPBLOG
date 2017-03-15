using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABPBLOG.Startup))]
namespace ABPBLOG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
