using HMS.Service.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace HMS.Admin.Resources.SettingResources
{
    public class SettingItemPostResource
    {
        [Required, MaxLength(500)]
        public string Value { get; set; }

        public IFormFile File { get; set; }

        public FileType FileType { get; set; }
    }
}
