using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Uber.SDK.Models;

namespace Uber.SDK
{
    public class UberSandboxClient : UberClient
    {
        public UberSandboxClient(AccessTokenType tokenType, string token)
            : base(tokenType, token, "https://sandbox-api.uber.com")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<UberResponse<bool>> UpdateRequestStatus(string requestId, string status = null)
        {
            var formData = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(status))
            {
                formData.Add("status", status);
            }

            var x = new StringContent(JsonConvert.SerializeObject(formData));

            var response = await _httpClient
                .PutAsync(string.Format("https://sandbox-api.uber.com/v1/sandbox/requests/{0}", requestId), x)
                .ConfigureAwait(false);

            return new UberResponse<bool>
            {
                Data = response.IsSuccessStatusCode
            };
        }

		public async Task<UberResponse<string>> DeliveryStatusAsync(string deliveryId, StatusEnum status)
		{
			string url = "/v1/sandbox/deliveries/" + deliveryId;

			var postData = new Dictionary<string, string>
			{
				{ "status" , status.GetDescription()}
			};

			var content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
			return await PutAsync<string>(url, content);
		}
    }
}