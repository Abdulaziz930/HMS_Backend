using HMS.Core;
using HMS.Core.Entities;
using HMS.Service.DTOs.SettingDtos;
using HMS.Service.Exceptions;
using HMS.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Service.Services.Implementations
{
    public class SettingService : ISettingService
    {
        public readonly IUnitOfWork _unitOfWork;

        public SettingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task EditAsync(int id, SettingItemPostDto settingDto)
        {
            Setting setting = await _unitOfWork.SettingRepository.GetAsync(x => x.Id == id);
            if (setting is null)
                throw new ItemNotFoundException($"Item not found by id: {id}");

            setting.Value = settingDto.Value;

            await _unitOfWork.CommitAsync();
        }

        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            return await _unitOfWork.SettingRepository.GetKeyValueSettingsAsync();
        }
    }
}
