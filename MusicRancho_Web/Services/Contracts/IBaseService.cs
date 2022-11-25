using MusicRancho_Web.Models;

namespace MusicRancho_Web.Services.Contracts
{
    public interface IBaseService
    {
        APIResponse ResponseModel { get; set; }
        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
