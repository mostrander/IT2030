using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT2030_Lab8_MeganOstrander_Authorization.Startup))]
namespace IT2030_Lab8_MeganOstrander_Authorization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
