using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class DeliveryAction
	{
		[JsonProperty("contact")]
		public Contact Contact { get; set; }

		[JsonProperty("eta")]
		public int? Eta { get; set; }

		[JsonProperty("location")]
		public Location Location { get; set; }

		[JsonProperty("special_instructions", NullValueHandling = NullValueHandling.Ignore)]
		public string SpecialInstructions { get; set; }

		[JsonProperty("signature_required", NullValueHandling = NullValueHandling.Ignore)]
		public string SignatureRequired { get; set; }

		[JsonProperty("signature_image", NullValueHandling = NullValueHandling.Ignore)]
		public SignatureImage SignatureImage { get; set; }

		[JsonProperty("courier_notes", NullValueHandling = NullValueHandling.Ignore)]
		public CourierNotes CourierNotes { get; set; }
	}
}