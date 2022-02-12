using AutoMapper;
using HMS.Core.Entities;
using HMS.Service.DTOs.RoomTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RoomType, RoomTypeDetailDto>().ReverseMap();
            CreateMap<RoomType, RoomTypeListItemDto>().ReverseMap();
            CreateMap<RoomType, RoomTypePostDto>().ReverseMap();
        }
    }
}
