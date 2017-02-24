using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhaseChange.Startup))]
namespace PhaseChange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
