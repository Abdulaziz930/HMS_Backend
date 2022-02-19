using HMS.Service.DTOs.SettingDtos;
using HMS.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettingService _settingService;

        public SettingsController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var settings = await _settingService.GetSettingsAsync();

            return StatusCode(StatusCodes.Status200OK, settings);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SettingItemPostDto settingDto)
        {
            await _settingService.EditAsync(id, settingDto);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
