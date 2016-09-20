using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VOMO.Api.Models;
using VOMO.Api.Models.Resources;
using VOMO.Common;
using VOMO.Context;
using VOMO.Context.Entities;
using VOMO.Web.Controllers;

namespace VOMO.Web.Areas.Api.Controllers
{
    public class PostsController : BaseController
    {
        [HttpGet]
        public JsonResult Index()
        {
            var posts = Vomo.Posts.ToList();
            var postResources = Mapper.Map<Post, PostResource>(posts);
            
            var apiResponse = new ApiResponse<List<PostResource>>
            {
                Data = postResources
            };

            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
