using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DVDLibrary.WebUI.Startup))]
namespace DVDLibrary.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
