using Newtonsoft.Json;
using Uber.SDK.Models.Helpers;

namespace Uber.SDK.Models
{
	public class Meta
	{
		[JsonProperty(PropertyName = "status")]
		[JsonConverter(typeof(StatusEnumConverter))]
		public StatusEnum Status { get; set; }

		[JsonProperty(PropertyName = "user_id")]
		public string UserID { get; set; }

		[JsonProperty(PropertyName = "resource_id")]
		public string ResourceID { get; set; }
	}
}