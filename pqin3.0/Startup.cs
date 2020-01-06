using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pqin3._0.Startup))]
namespace pqin3._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
