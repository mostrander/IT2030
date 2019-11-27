using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT2030_MeganOstrander_FinalProject.Startup))]
namespace IT2030_MeganOstrander_FinalProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
