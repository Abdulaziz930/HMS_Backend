using HMS.Service.DTOs;
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

            return StatusCode(StatusCodes.Status201Created
                , new ResponeDto { Status = StatusCodes.Status201Created, Message = "Room type succefuly created" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _roomTypeService.GetByIdAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, RoomTypePostDto roomTypeDto)
        {
            await _roomTypeService.EditAsync(id, roomTypeDto);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll(string search = null, int page = 1)
        {
            var roomTypes = await _roomTypeService.GetAllFiltered(page, search);

            return StatusCode(StatusCodes.Status200OK, roomTypes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomTypeService.SoftDeleteByIdAsync(id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
