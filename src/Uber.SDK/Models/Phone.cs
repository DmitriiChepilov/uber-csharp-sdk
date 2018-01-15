using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class Phone
	{
		[JsonProperty("number")]
		public string Number { get; set; }

		[JsonProperty("sms_enabled", NullValueHandling = NullValueHandling.Ignore)]
		public bool SmsEnabled { get; set; }
	}
}