using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VOMO.Api.Models.Resources
{
    public class PostResource
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "author")]
        public AuthorBasicResource Author { get; set; } 

        [JsonProperty(PropertyName = "tags")]
        public List<TagResource> Tags { get; set; } 
    }
}
