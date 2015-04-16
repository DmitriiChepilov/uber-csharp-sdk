﻿using Newtonsoft.Json;

namespace Uber.SDK.Models
{
    public class RequestDetailsDriver
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "picture_url")]
        public string PictureUrl { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public int Rating { get; set; }
    }
}
