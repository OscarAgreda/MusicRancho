using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicRancho_Web.Models;
using MusicRancho_Web.Models.Dto;
using MusicRancho_Web.Services.Contracts;
using Newtonsoft.Json;

namespace MusicRancho_Web.Controllers
{
    public class RanchoController : Controller
    {
        private readonly IRanchoService _ranchoService;
        private readonly IMapper _mapper;

        public RanchoController(IRanchoService ranchoService, IMapper mapper)
        {
            _ranchoService = ranchoService;
            _mapper = mapper;
        }

        protected async Task<string> GetAccessToken()
            => await HttpContext.GetTokenAsync("access_token");
        
        public async Task<IActionResult> IndexRancho()
        {
            List<RanchoDTO> list = new();
            var response = await _ranchoService.GetAllAsync<APIResponse>(await GetAccessToken());
            if (response != null && response.IsSuccess)
                list = JsonConvert.DeserializeObject<List<RanchoDTO>>(Convert.ToString(response.Result));

            return View(list);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateRancho()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRancho(RanchoCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _ranchoService.CreateAsync<APIResponse>(model, await GetAccessToken());
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Rancho created successfully";
                    return RedirectToAction(nameof(IndexRancho));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [Authorize(Roles = "admin", Policy = "AtLeast40")]
        public async Task<IActionResult> UpdateRancho(int ranchoId)
        {
            var response = await _ranchoService.GetAsync<APIResponse>(ranchoId, await GetAccessToken());
            if (response != null && response.IsSuccess)
            {
                RanchoDTO model = JsonConvert.DeserializeObject<RanchoDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<RanchoUpdateDTO>(model));
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRancho(RanchoUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Rancho updated successfully";
                var response = await _ranchoService.UpdateAsync<APIResponse>(model, await GetAccessToken());
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexRancho));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteRancho(int ranchoId)
        {
            var response = await _ranchoService.GetAsync<APIResponse>(ranchoId, await GetAccessToken());
            if (response != null && response.IsSuccess)
            {
                RanchoDTO model = JsonConvert.DeserializeObject<RanchoDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRancho(RanchoDTO model)
        {
            var response = await _ranchoService.DeleteAsync<APIResponse>(model.Id, await GetAccessToken());
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Rancho deleted successfully";
                return RedirectToAction(nameof(IndexRancho));
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
