using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOMO.Context.Entities;
using VOMO.Web.Models;

namespace VOMO.Web.Mappers
{
    public static class PostToPostViewModelMapping
    {
        public static PostViewModel Map(Post src)
        {
            return new PostViewModel
            {
                Title = src.Title,
                Content = src.Content,
                UpdatedAt = src.UpdatedAt,
                CreatedAt = src.CreatedAt
            };
        }
        
        public static IEnumerable<PostViewModel> Map(IEnumerable<Post> src)
        {
            return src.Select(Map);
        } 
    }
}
