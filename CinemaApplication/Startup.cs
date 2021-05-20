using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaApplication.Startup))]
namespace CinemaApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
