using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class Location
	{
		[JsonProperty("address")]
		public string Address { get; set; }

		[JsonProperty("address_2", NullValueHandling = NullValueHandling.Ignore)]
		public string Address2 { get; set; }

		[JsonProperty("city")]
		public string City { get; set; }

		[JsonProperty("country")]
		public string Country { get; set; }

		[JsonProperty("postal_code")]
		public string PostalCode { get; set; }

		[JsonProperty("state")]
		public string State { get; set; }

		[JsonProperty("longitude", NullValueHandling = NullValueHandling.Ignore)]
		public float Longitude { get; set; }

		[JsonProperty("latitude", NullValueHandling = NullValueHandling.Ignore)]
		public float Latitude { get; set; }
	}
}