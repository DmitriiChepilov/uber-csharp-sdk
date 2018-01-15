using System.Collections.Generic;
using Newtonsoft.Json;
using Uber.SDK.Models.Helpers;

namespace Uber.SDK.Models
{
	public class Delivery
	{
		[JsonProperty("quote_id", NullValueHandling = NullValueHandling.Ignore)]
		public string QuoteID { get; set; }

		[JsonProperty("order_reference_id", NullValueHandling = NullValueHandling.Ignore)]
		public string OrderReferenceID { get; set; }

		[JsonProperty("items")]
		public IList<Item> Items { get; set; }

		[JsonProperty("pickup")]
		public DeliveryAction Pickup { get; set; }

		[JsonProperty("dropoff")]
		public DeliveryAction Dropoff { get; set; }

		[JsonProperty("includes_alcohol", NullValueHandling = NullValueHandling.Ignore)]
		public string IncludesAlcohol { get; set; }

		[JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(StatusEnumConverter))]
		public StatusEnum Status { get; set; }

		[JsonProperty("fee", NullValueHandling = NullValueHandling.Ignore)]
		public string Fee { get; set; }

		[JsonProperty("courier", NullValueHandling = NullValueHandling.Ignore)]
		public Courier Courier { get; set; }

		[JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
		public string CreatedAt { get; set; }

		[JsonProperty("delivery_id", NullValueHandling = NullValueHandling.Ignore)]
		public string DeliveryID { get; set; }

		[JsonProperty("tracking_url", NullValueHandling = NullValueHandling.Ignore)]
		public string TrackingUrl { get; set; }

		[JsonProperty("currency_code", NullValueHandling = NullValueHandling.Ignore)]
		public string CurrencyCode { get; set; }
	}
}