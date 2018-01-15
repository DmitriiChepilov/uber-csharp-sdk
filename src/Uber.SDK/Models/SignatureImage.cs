using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class SignatureImage
	{
		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("expires_at")]
		public string ExpiresAt { get; set; }
	}
}