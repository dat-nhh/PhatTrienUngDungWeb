using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_63133655.Startup))]
namespace Project_63133655
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
