using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImsForPresentation.Startup))]
namespace ImsForPresentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
