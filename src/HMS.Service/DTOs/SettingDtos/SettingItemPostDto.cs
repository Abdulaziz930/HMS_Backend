using FluentValidation;
using HMS.Service.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.DTOs.SettingDtos
{
    public class SettingItemPostDto
    {
        public string Value { get; set; }

        public IFormFile File { get; set; }

        public FileType FileType { get; set; }
    }

    public class SettingItemPostDtoValidator : AbstractValidator<SettingItemPostDto>
    {
        public SettingItemPostDtoValidator()
        {
            RuleFor(x => x.Value).MaximumLength(500).NotNull().NotEmpty();
        }
    }
}
