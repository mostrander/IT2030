using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MOstrander_Lab03.Startup))]
namespace MOstrander_Lab03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
