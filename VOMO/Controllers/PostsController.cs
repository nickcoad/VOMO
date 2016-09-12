﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VOMO.Context.Entities;
using VOMO.Web.Mappers;
using VOMO.Web.Models;
using VOMO.Web.Models.Posts;

namespace VOMO.Web.Controllers
{
    public class PostsController : BaseController
    {
        // GET: Posts
        [HttpGet]
        public ActionResult Index()
        {
            var posts = Vomo.Posts.OrderByDescending(post => post.CreatedAt).ToList();
            var postViewModels = PostToPostViewModelMapping.Map(posts);

            return View(new PostsIndexViewModel { Posts = postViewModels.ToList() });
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new PostsCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PostsCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var newPost = new Post
            {
                UserId = LoggedInUser.Id,
                Title = viewModel.Title,
                Content = viewModel.Content
            };

            Vomo.Posts.Add(newPost);
            Vomo.SaveChanges();

            return RedirectToAction("index", "posts");
        }
    }
}