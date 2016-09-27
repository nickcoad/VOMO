using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ExpressMapper;
using ExpressMapper.Extensions;
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
            var posts = Vomo.Posts.Project<Post, PostResource>().ToList();

            var apiResponse = new ApiResponse<List<PostResource>>
            {
                Data = posts
            };

            return Json(apiResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
