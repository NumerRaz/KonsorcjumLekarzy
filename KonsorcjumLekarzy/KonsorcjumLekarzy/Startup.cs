using KonsorcjumLekarzy.Infrastucture;
using KonsorcjumLekarzy.Models;
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
            var manageAccount = new ManageAccount();
            var applicationDBContext = new ApplicationDbContext();
            manageAccount.AddRole(applicationDBContext, TypeRole.Admin);
            manageAccount.AddRole(applicationDBContext, TypeRole.Patient);
            manageAccount.AddRole(applicationDBContext,TypeRole.Doctor);
        }
    }
}
