using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VOMO.Api.Models.Resources
{
    public class AuthorBasicResource
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "given_name")]
        public string GivenName { get; set; }

        [JsonProperty(PropertyName = "surname")]
        public string Surname { get; set; }
    }

    public class AuthorResource : AuthorBasicResource
    {
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "posts")]
        public List<PostResource> Posts { get; set; } 
    }
}
