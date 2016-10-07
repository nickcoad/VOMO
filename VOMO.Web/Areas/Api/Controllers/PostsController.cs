using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using VOMO.Api.Models;
using VOMO.Api.Models.Resources;
using VOMO.Web.Controllers;

namespace VOMO.Web.Areas.Api.Controllers
{
    public class PostsController : BaseController
    {
        [HttpGet]
        public JsonResult Index()
        {
            // TODO: Reimplement mapping.
            var posts = Vomo.Posts.ToList();

            var apiResponse = new ApiResponse<List<PostResource>>
            {
                //Data = posts
            };

            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
