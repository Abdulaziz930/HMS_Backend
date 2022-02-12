using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.DTOs.RoomTypeDtos
{
    public class RoomTypePostDto
    {
        public string Name { get; set; }
    }

    public class RoomTypePostDtoValidator : AbstractValidator<RoomTypePostDto>
    {
        public RoomTypePostDtoValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).MinimumLength(3).NotNull().NotEmpty();
        }
    }
}
