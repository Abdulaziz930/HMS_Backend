using AutoMapper;
using HMS.Core.Entities;
using HMS.Service.DTOs.RoomTypeDtos;
using HMS.Service.HelperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Profiles
{
    public class AutoMapperProfile : Profile
    {
        private readonly IHelperAccessor _helperAccessor;

        public AutoMapperProfile(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;

            CreateMap<RoomType, RoomTypeDetailDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeListItemDto>().ReverseMap();
            CreateMap<RoomType, RoomTypePostDto>().ReverseMap();
        }
    }
}
