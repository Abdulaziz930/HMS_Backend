using HMS.Service.DTOs.RoomTypeDtos;
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
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypesController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(RoomTypePostDto roomTypeDto)
        {
            await _roomTypeService.CreateAsync(roomTypeDto);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var roomType = await _roomTypeService.GetByIdAsync(id);

            return StatusCode(StatusCodes.Status200OK, roomType);
        }
    }
}
