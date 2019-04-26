using System.Web.Mvc;

namespace TelefonRehberi.Ui.Areas.Admin
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
            context.MapRoute(
                "Admin_default",
                "AdminUI/{controller}/{action}/{id}",
                new {Controller="Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}