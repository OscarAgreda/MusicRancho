using MusicRancho_Web.Models.Dto;

namespace MusicRancho_Web.Services.Contracts
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO objToCreate);
        Task<T> RegisterAsync<T>(RegisterationRequestDTO objToCreate);
    }
}
