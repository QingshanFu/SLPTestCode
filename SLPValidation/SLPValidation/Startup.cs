using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SLPValidation.Startup))]
namespace SLPValidation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
