using MusicRancho_Utility;
using MusicRancho_Web.Models;
using MusicRancho_Web.Models.Dto;
using MusicRancho_Web.Services.Contracts;

namespace MusicRancho_Web.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly string _ranchoUrl;

        public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration)
            : base(clientFactory)
        {
            _ranchoUrl = configuration.GetValue<string>("ServiceUrls:RanchoAPI");
        }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Url = $"{_ranchoUrl}/api/v1/UsersAuth/login",
                Data = obj
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO obj)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Url = $"{_ranchoUrl}/api/v1/UsersAuth/register",
                Data = obj
            });
        }
    }
}
