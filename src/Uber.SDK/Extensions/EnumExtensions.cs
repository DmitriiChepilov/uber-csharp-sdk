using System.ComponentModel;

namespace Uber.SDK.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDescription<T>(this T source)
		{
			var fi = source.GetType().GetField(source.ToString());

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
				typeof(DescriptionAttribute), false);

			if (attributes.Length > 0)
				return attributes[0].Description;

			return source.ToString();
		}
	}
}