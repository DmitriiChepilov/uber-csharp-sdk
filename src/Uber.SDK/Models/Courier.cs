using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class Courier
	{
		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("picture_url")]
		public string PictureUrl { get; set; }

		[JsonProperty("vehicle")]
		public RequestDetailsVehicle Vehicle { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("location")]
		public CourierLocation Location { get; set; }
	}
}