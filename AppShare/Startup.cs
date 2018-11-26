using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppShare.Startup))]
namespace AppShare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
