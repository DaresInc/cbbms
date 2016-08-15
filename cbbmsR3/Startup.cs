using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cbbmsR3.Startup))]
namespace cbbmsR3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
