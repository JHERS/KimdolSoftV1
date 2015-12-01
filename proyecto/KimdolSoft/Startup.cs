using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KimdolSoft.Startup))]
namespace KimdolSoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
