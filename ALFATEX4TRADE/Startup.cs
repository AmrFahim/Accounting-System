using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ALFATEX4TRADE.Startup))]
namespace ALFATEX4TRADE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
