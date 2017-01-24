using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChatardApp.Startup))]
namespace ChatardApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
