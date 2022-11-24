using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MusicRancho_Web.Models;
using MusicRancho_Web.Models.Dto;
using MusicRancho_Web.Services.Contracts;
using Newtonsoft.Json;

namespace MusicRancho_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRanchoService _ranchoService;
        private readonly IMapper _mapper;

        public HomeController(IRanchoService ranchoService, IMapper mapper)
        {
            _ranchoService = ranchoService;
            _mapper = mapper;
        }

        protected async Task<string> GetAccessToken()
            => await HttpContext.GetTokenAsync("access_token");

        public async Task<IActionResult> Index()
        {
            List<RanchoDTO> list = new();
            var response = await _ranchoService.GetAllAsync<APIResponse>(await GetAccessToken());
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<RanchoDTO>>(Convert.ToString(response.Result));

            return View(list);
        }
    }
}
