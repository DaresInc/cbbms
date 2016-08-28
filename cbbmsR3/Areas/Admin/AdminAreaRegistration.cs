using System.Web.Mvc;

namespace cbbmsR3.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute("AppUsers", "Admin/{controller}/{action}/{id}", new { action = "Index", id = UrlParameter.Optional,Controller="Deafult" });
            context.MapRoute("AppRoles", "Admin/{controller}/{action}/{id}", new { action = "Index", id = UrlParameter.Optional, Controller = "Roles" });
            context.MapRoute("AppFiles", "Admin/{controller}/{action}/{id}", new { action = "Index", id = UrlParameter.Optional, Controller = "AppFiles" });




            context.MapRoute("Default_Admin","Admin/{controller}/{action}/{id}",new { action = "Index", id = UrlParameter.Optional,Controller="Default" });
        }
    }
}