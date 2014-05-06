using Microsoft.Owin;
using Owin;
using Goblin.Model;

[assembly: OwinStartupAttribute(typeof(Goblin.Startup))]
namespace Goblin
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
