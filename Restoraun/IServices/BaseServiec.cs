using Restoraun.Models;
using System.Text.Json.Serialization;
using Newtonsoft;
using Newtonsoft.Json;
using System.Text;

namespace Restoraun.IServices
{
    public class BaseServiec : IBaseServies
    {
        public ResponseDTO ResponseModel { get; set; }

        public IHttpClientFactory HttpClient{ get; set; }

        public BaseServiec(IHttpClientFactory HttpClient) {
            this.HttpClient = HttpClient;
            this.ResponseModel = new ResponseDTO();
        
        }


        public void Dispose()
        {
           GC.SuppressFinalize(true);
        }

        public async Task<T> sendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MangoApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if(apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (apiRequest.apiType)
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
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDTO;

            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO
                {
                    DisplayMassage = "Error",
                    ErrorMassages = new List<string> { ex.Message },
                    IsSuccess = false,

                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }
    }
}
