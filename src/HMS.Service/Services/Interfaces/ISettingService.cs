using HMS.Service.DTOs.SettingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Services.Interfaces
{
    public interface ISettingService
    {
        Task EditAsync(int id, SettingItemPostDto settingDto);
        Task<Dictionary<string, string>> GetSettingsAsync();
    }
}
