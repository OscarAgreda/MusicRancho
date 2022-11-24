using MusicRancho_Utility;
using MusicRancho_Web.Models;
using MusicRancho_Web.Models.Dto;
using MusicRancho_Web.Services.Contracts;

namespace MusicRancho_Web.Services
{
    public class RanchoService : BaseService, IRanchoService
    {
        private readonly string _ranchoUrl;

        public RanchoService(IHttpClientFactory clientFactory, IConfiguration configuration)
            : base(clientFactory)
        {
            _ranchoUrl = configuration.GetValue<string>("ServiceUrls:RanchoAPI");
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_ranchoUrl}/api/v1/ranchoAPI",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_ranchoUrl}/api/v1/ranchoAPI/{id}",
                Token = token
            });
        }

        public Task<T> CreateAsync<T>(RanchoCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Url = $"{_ranchoUrl}/api/v1/ranchoAPI",
                Data = dto,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(RanchoUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = SD.ApiType.PUT,
                Data = dto,
                Url = $"{_ranchoUrl}/api/v1/ranchoAPI/{dto.Id}",
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{_ranchoUrl}/api/v1/ranchoAPI/{id}",
                Token = token
            });
        }
    }
}
