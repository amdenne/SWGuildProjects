using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapstoneBlog.Startup))]
namespace CapstoneBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
