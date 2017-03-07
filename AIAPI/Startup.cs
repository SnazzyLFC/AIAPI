using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIAPI.Startup))]
namespace AIAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
