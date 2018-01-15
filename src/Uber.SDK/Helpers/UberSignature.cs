using System;
using System.Security.Cryptography;
using System.Text;

namespace Uber.SDK.Helpers
{
	public class UberSignature
	{
		public static bool IsSendedByUber(string clientSecret, string webhookBody, string signature)
		{
			//digester = hmac.new(client_secret, webhook_body, hashlib.sha256)
			var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(clientSecret));
			
			//return digester.hexdigest()
			var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(webhookBody));
			string hashString = BitConverter.ToString(hash).Replace("-", "");

			return hashString.Equals(signature, StringComparison.InvariantCultureIgnoreCase);
		}
	}
}