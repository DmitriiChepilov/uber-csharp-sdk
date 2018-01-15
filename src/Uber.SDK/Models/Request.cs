using Newtonsoft.Json;
using Uber.SDK.Models.Helpers;

namespace Uber.SDK.Models
{
    public class Request
    {
        [JsonProperty(PropertyName = "request_id")]
        public string RequestId { get; set; }

        [JsonProperty(PropertyName = "status")]
		[JsonConverter(typeof(StatusEnumConverter))]
        public StatusEnum Status { get; set; }

        [JsonProperty(PropertyName = "vehicle")]
        public RequestDetailsVehicle Vehicle { get; set; }

        [JsonProperty(PropertyName = "driver")]
        public RequestDetailsDriver Driver { get; set; }

        [JsonProperty(PropertyName = "location")]
        public RequestDetailsLocation Location { get; set; }

        [JsonProperty(PropertyName = "eta")]
        public int ETA { get; set; }

        [JsonProperty(PropertyName = "surge_multiplier")]
        public float SurgeMultiplier { get; set; }
    }
}
