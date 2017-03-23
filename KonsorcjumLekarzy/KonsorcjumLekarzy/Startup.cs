using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KonsorcjumLekarzy.Startup))]
namespace KonsorcjumLekarzy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
