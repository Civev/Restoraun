using static Restoraun.SD;

namespace Restoraun.Models
{
    public class ApiRequest
    {
        public ApiType apiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }

        public string AccesToken { get; set; }
    }
}
