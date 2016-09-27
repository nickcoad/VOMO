using System.Web.Mvc;

namespace VOMO.Web.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "api_default",
                "api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "VOMO.Web.Areas.Api.Controllers" }
            );

            
        }
    }
}