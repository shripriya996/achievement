using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(achievement.Startup))]
namespace achievement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
