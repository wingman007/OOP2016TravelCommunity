using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelCommunity.Startup))]
namespace TravelCommunity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
