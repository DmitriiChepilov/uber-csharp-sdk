using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Uber.SDK.Helpers
{
	public class UnixTimeStampConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime);
		}

		private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.Value == null)
				return null;

			return Epoch.AddSeconds((long)reader.Value);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			writer.WriteRawValue(((DateTime)value - Epoch).TotalSeconds.ToString(CultureInfo.InvariantCulture));
		}
	}
}