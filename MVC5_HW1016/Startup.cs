using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_HW1016.Startup))]
namespace MVC5_HW1016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
