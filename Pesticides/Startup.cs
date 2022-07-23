using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pesticides.Startup))]
namespace Pesticides
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
