using System.Collections.Generic;
using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class DeliveriesResponse
	{
		[JsonProperty("count")]
		public int Count { get; set; }

		[JsonProperty("next_page")]
		public string NextPage { get; set; }

		[JsonProperty("previous_page")]
		public string PreviousPage { get; set; }

		[JsonProperty("deliveries")]
		public IList<Delivery> Deliveries { get; set; }
	}
}