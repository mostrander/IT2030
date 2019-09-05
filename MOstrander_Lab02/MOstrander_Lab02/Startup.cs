using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MOstrander_Lab02.Startup))]
namespace MOstrander_Lab02
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
