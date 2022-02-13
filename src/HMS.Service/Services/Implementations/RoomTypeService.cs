using AutoMapper;
using HMS.Core;
using HMS.Core.Entities;
using HMS.Service.DTOs;
using HMS.Service.DTOs.RoomTypeDtos;
using HMS.Service.Exceptions;
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
            if (await _unitOfWork.RoomTypeRepository.IsExistsAsync(x => x.Name.ToLower() == roomTypeDto.Name.ToLower()))
                throw new RecordAlredyExistException($"Item already exist with name {roomTypeDto.Name}");

            RoomType roomType = _mapper.Map<RoomType>(roomTypeDto);

            await _unitOfWork.RoomTypeRepository.InsertAsync(roomType);
            await _unitOfWork.CommitAsync();
        }

        public void Delete(int id)
        {
            _unitOfWork.RoomTypeRepository.Remove(new RoomType { Id = id });
        }

        public async Task EditAsync(int id, RoomTypePostDto roomTypeDto)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (roomType is null)
                throw new ItemNotFoundException($"Item not found by id: {id}");

            if (await _unitOfWork.RoomTypeRepository.IsExistsAsync(x => x.Id != id && !x.IsDeleted && x.Name.ToLower() == roomType.Name.ToLower()))
                throw new RecordAlredyExistException($"Item already exist with name {roomTypeDto.Name}");

            roomType.Name = roomTypeDto.Name;
            roomType.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
        }

        public async Task<PagenatedListDto<RoomTypeListItemDto>> GetAllFiltered(int page, string search = null)
        {
            if (page < 0)
                throw new PageIndexFormException($"PageIndex must be greater or equal than 1");

            IEnumerable<RoomType> roomTypes = await _unitOfWork.RoomTypeRepository
                .GetAllPagenatedAsync(page, 5, x => !x.IsDeleted && string.IsNullOrWhiteSpace(search) ? true : x.Name.ToLower().Contains(search));
            int totalCount = await _unitOfWork.RoomTypeRepository
                .GetTotalCountAsync(x => !x.IsDeleted && string.IsNullOrWhiteSpace(search) ? true : x.Name.ToLower().Contains(search));

            IEnumerable<RoomTypeListItemDto> roomTypeDtos = _mapper.Map<IEnumerable<RoomTypeListItemDto>>(roomTypes);

            PagenatedListDto<RoomTypeListItemDto> pagenatedListDto = new PagenatedListDto<RoomTypeListItemDto>(roomTypeDtos, totalCount, page, 5);

            return pagenatedListDto;
        }

        public async Task<RoomTypeDetailDto> GetByIdAsync(int id)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (roomType == null)
                throw new ItemNotFoundException($"Item not found by id: {id}");

            RoomTypeDetailDto roomTypeDto = _mapper.Map<RoomTypeDetailDto>(roomType);

            return roomTypeDto;
        }

        public async Task<bool> IsExistsByIdAsync(int id)
        {
            return await _unitOfWork.RoomTypeRepository.IsExistsAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task SoftDeleteByIdAsync(int id)
        {
            RoomType roomType = await _unitOfWork.RoomTypeRepository.GetAsync(x => x.Id == id && !x.IsDeleted);
            if (roomType is null)
                throw new ItemNotFoundException($"Item not found by id: {id}");

            roomType.IsDeleted = true;

            await _unitOfWork.CommitAsync();
        }
    }
}
