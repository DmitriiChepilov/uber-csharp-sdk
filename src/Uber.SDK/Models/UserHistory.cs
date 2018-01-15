using Newtonsoft.Json;
using Uber.SDK.Models.Helpers;

namespace Uber.SDK.Models
{
    public class UserHistory
    {
        [JsonProperty(PropertyName = "uuid")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "request_time")]
        public int RequestTime { get; set; }

        [JsonProperty(PropertyName = "product_id")]
        public string ProductId { get; set; }

        [JsonProperty(PropertyName = "status")]
		[JsonConverter(typeof(StatusEnumConverter))]
        public StatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public double Distance { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        public int StartTime { get; set; }

        [JsonProperty(PropertyName = "end_time")]
        public int EndTime { get; set; }
    }
}
