using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VOMO.Web.Models.Posts
{
    public class PostsCreateViewModel
    {
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AttachmentMimeType { get; set; }
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}