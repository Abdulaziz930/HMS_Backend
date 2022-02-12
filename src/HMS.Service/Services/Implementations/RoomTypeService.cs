using AutoMapper;
using HMS.Core;
using HMS.Core.Entities;
using HMS.Service.DTOs;
using HMS.Service.DTOs.RoomTypeDtos;
using HMS.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Services.Implementations
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(RoomTypePostDto roomTypeDto)
        {
            RoomType roomType = _mapper.Map<RoomType>(roomTypeDto);

            await _unitOfWork.RoomTypeRepository.InsertAsync(roomType);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, RoomTypePostDto roomTypeDto)
        {
            throw new NotImplementedException();
        }

        public Task<PagenatedListDto<RoomTypeListItemDto>> GetAllFiltered(int page, string search)
        {
            throw new NotImplementedException();
        }

        public async Task<RoomTypeDetailDto> GetByIdAsync(int id)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            RoomTypeDetailDto roomTypeDto = _mapper.Map<RoomTypeDetailDto>(roomType);

            return roomTypeDto;
        }

        public Task<bool> IsExistsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
