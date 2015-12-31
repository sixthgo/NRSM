using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eland.NRSM.Ap.Startup))]
namespace Eland.NRSM.Ap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
