using System.Collections.Generic;

namespace VOMO.Web.Models.Posts
{
    public class PostsIndexViewModel
    {
        public List<PostViewModel> Posts { get; set; }

        public PostsIndexViewModel()
        {
            Posts = new List<PostViewModel>();
        }
    }
}