using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NewsEngine2A.Startup))]

namespace NewsEngine2A
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
