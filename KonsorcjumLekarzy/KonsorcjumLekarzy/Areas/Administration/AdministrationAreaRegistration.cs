using System.Web.Mvc;

namespace KonsorcjumLekarzy.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administration_default",
                "Administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Administration_admin",
                "Administration/",
                new { action = "Index", controller=  "Admin", id = UrlParameter.Optional }
            );
        }
    }
}