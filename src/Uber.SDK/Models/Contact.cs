using Newtonsoft.Json;

namespace Uber.SDK.Models
{
	public class Contact
	{
		[JsonProperty("company_name", NullValueHandling = NullValueHandling.Ignore)]
		public string CompanyName { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }

		[JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
		public string FirstName { get; set; }

		[JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
		public string LastName { get; set; }

		[JsonProperty("phone")]
		public Phone Phone { get; set; }

		[JsonProperty("send_email_notifications")]
		public bool SendEmailNotifications { get; set; }

		[JsonProperty("send_sms_notifications")]
		public bool SendSmsNotifications { get; set; }
	}
}