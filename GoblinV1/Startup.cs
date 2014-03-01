using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoblinV1.Startup))]
namespace GoblinV1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
