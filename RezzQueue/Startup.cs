using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RezzQueue.Startup))]
namespace RezzQueue
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
