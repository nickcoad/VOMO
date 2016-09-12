using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VOMO.Web.Models
{
    public class PostViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}