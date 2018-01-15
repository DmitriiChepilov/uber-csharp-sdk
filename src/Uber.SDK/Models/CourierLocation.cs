using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class CourierLocation
	{
		[JsonProperty("latitude")]
		public float Latitude { get; set; }

		[JsonProperty("bearing")]
		public int Bearing { get; set; }

		[JsonProperty("longitude")]
		public float Longitude { get; set; }
	}
}