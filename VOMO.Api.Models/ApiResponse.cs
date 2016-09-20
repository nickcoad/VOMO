using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VOMO.Api.Common;

namespace VOMO.Api.Models
{
    public class ApiResponse<TApiResource>
    {
        [JsonProperty(PropertyName = "data")]
        public TApiResource Data { get; set; }

        [JsonProperty(PropertyName = "status")]
        public Constants.ResponseStatus Status { get; set; }

        [JsonProperty(PropertyName = "status_message")]
        public string StatusMessage { get; set; }
    }
}
