using Restoraun.Models;

namespace Restoraun.IServices
{
    public interface IBaseServies : IDisposable
    {
        ResponseDTO ResponseModel { get; set; }
        Task<T> sendAsync<T>(ApiRequest apiRequest);
    }
}
