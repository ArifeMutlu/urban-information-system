using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KentBilgiSistemleri.Startup))]
namespace KentBilgiSistemleri
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
