using HMS.Service.DTOs;
using HMS.Service.DTOs.RoomTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Services.Interfaces
{
    public interface IRoomTypeService
    {
        Task CreateAsync(RoomTypePostDto roomTypeDto);
        Task<RoomTypeDetailDto> GetByIdAsync(int id);
        Task<PagenatedListDto<RoomTypeListItemDto>> GetAllFiltered(int page, string search = null);
        Task EditAsync(int id, RoomTypePostDto roomTypeDto);
        void Delete(int id);
        Task SoftDeleteByIdAsync(int id);
        Task<bool> IsExistsByIdAsync(int id);
    }
}
