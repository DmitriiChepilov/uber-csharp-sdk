using System;
using Newtonsoft.Json;
using Uber.SDK.Helpers;

namespace Uber.SDK.Models
{
	public class WebHook
	{
        [JsonProperty(PropertyName = "event_id")]
		public string EventID { get; set; }

        [JsonProperty(PropertyName = "resource_href")]
		public string ResourceHref { get; set; }

        [JsonProperty(PropertyName = "meta")]
		public Meta Meta { get; set; }

        [JsonProperty(PropertyName = "event_type")]
		public string EventType { get; set; }

        [JsonProperty(PropertyName = "event_time")]
		[JsonConverter(typeof(UnixTimeStampConverter))]
		public DateTime  EventTime { get; set; }
	}
}