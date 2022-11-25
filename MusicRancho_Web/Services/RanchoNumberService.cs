using MusicRancho_Utility;
using MusicRancho_Web.Models;
using MusicRancho_Web.Models.Dto;
using MusicRancho_Web.Services.Contracts;

namespace MusicRancho_Web.Services
{
    public class RanchoNumberService : BaseService, IRanchoNumberService
    {
        private readonly string _ranchoUrl;

        public RanchoNumberService(IHttpClientFactory clientFactory, IConfiguration configuration)
            : base(clientFactory)
        {
            _ranchoUrl = configuration.GetValue<string>("ServiceUrls:RanchoAPI");
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_ranchoUrl}/api/v1/ranchoNumberAPI",
                Token = token
            });
        }
        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.GET,
                Url = $"{_ranchoUrl}/api/v1/ranchoNumberAPI/id",
                Token = token
            });
        }

        public Task<T> CreateAsync<T>(RanchoNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.POST,
                Url = $"{_ranchoUrl}/api/v1/ranchoNumberAPI",
                Data = dto,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(RanchoNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.PUT,
                Url = $"{_ranchoUrl}/api/v1/ranchoNumberAPI/dto.RanchoNo",
                Data = dto,
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{_ranchoUrl}/api/v1/ranchoNumberAPI/{id}",
                Token = token
            });
        }
    }
}
