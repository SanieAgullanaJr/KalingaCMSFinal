using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KalingaCMSFinal.Startup))]
namespace KalingaCMSFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
