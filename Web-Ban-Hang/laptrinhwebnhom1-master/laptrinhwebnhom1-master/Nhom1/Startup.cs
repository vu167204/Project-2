using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nhom1.Startup))]
namespace Nhom1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
