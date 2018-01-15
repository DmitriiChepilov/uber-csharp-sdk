using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class Item
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("quantity")]
		public int Quantity { get; set; }

		[JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
		public float Width { get; set; }

		[JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
		public float Height { get; set; }

		[JsonProperty("length", NullValueHandling = NullValueHandling.Ignore)]
		public float Length { get; set; }

		[JsonProperty("weight", NullValueHandling = NullValueHandling.Ignore)]
		public float Weight { get; set; }

		[JsonProperty("price")]
		public float Price { get; set; }

		[JsonProperty("currency_code")]
		public string CurrencyCode { get; set; }

		[JsonProperty("is_fragile", NullValueHandling = NullValueHandling.Ignore)]
		public bool IsFragile { get; set; }
	}
}