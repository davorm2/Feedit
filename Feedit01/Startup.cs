using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Feedit01.Startup))]
namespace Feedit01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
