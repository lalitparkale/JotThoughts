using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JotThoughts.Startup))]
namespace JotThoughts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
