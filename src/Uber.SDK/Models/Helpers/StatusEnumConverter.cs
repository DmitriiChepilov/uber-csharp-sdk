using System;
using System.Linq;
using Newtonsoft.Json;
using Uber.SDK.Extensions;

namespace Uber.SDK.Models.Helpers
{

	internal class StatusEnumConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var rideType = (StatusEnum)value;
			writer.WriteValue(rideType.GetDescription());
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
			JsonSerializer serializer)
		{
			var value = (string)reader.Value;

			return Enum.GetValues(typeof(StatusEnum))
				.Cast<StatusEnum>()
				.FirstOrDefault(rideType => rideType.GetDescription() == value);
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string);
		}
	}
}
