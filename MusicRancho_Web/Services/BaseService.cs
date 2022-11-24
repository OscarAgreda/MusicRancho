using System.Net.Http.Headers;
using System.Text;
using MusicRancho_Utility;
using MusicRancho_Web.Models;
using MusicRancho_Web.Services.Contracts;
using Newtonsoft.Json;

namespace MusicRancho_Web.Services
{
    public class BaseService : IBaseService
    {
        public const string ApplicationJson = "application/json";

        public APIResponse ResponseModel { get; set; }
        public IHttpClientFactory HttpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            ResponseModel = new();
            HttpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MusicAPI");
                var message = new HttpRequestMessage();
                message.Headers.Add("Accept", ApplicationJson);
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.Data != null)
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, ApplicationJson);

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;
                if (!string.IsNullOrEmpty(apiRequest.Token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.Token);

                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();

                try
                {
                    var ApiResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (ApiResponse != null && (apiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest
                        || apiResponse.StatusCode == System.Net.HttpStatusCode.NotFound))
                    {
                        ApiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        ApiResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(ApiResponse);
                        return JsonConvert.DeserializeObject<T>(res);
                    }
                }
                catch (Exception ex)
                {
                    return JsonConvert.DeserializeObject<T>(apiContent);
                }

                return JsonConvert.DeserializeObject<T>(apiContent);
            }
            catch (Exception ex)
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                }));
            }
        }
    }
}
