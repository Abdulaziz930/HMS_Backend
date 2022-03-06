using HMS.Core;
using HMS.Core.Entities;
using HMS.Service.DTOs.SettingDtos;
using HMS.Service.Enums;
using HMS.Service.Exceptions;
using HMS.Service.Services.Interfaces;
using HMS.Service.Utils;
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

            if (settingDto.File != null)
            {
                if (settingDto.FileType == FileType.Image && !settingDto.File.IsImage())
                    throw new FileFormatException("File type must be image");

                if (settingDto.FileType == FileType.Image && settingDto.File.IsSizeAllowed(3000))
                    throw new FileSizeException("The size of the image you uploaded can't be higher 3 MB.");

                if (settingDto.FileType == FileType.Video && !settingDto.File.IsVideo())
                    throw new FileFormatException("File type must be video");

                var fileName = await FileUtil.UpdateFileAsync(setting.Value, Constants.ImageFolderPath, settingDto.File, settingDto.FileType);
                setting.Value = fileName;
            }
            else
            {
                setting.Value = settingDto.Value;
            }

            await _unitOfWork.CommitAsync();
        }

        public async Task<Dictionary<string, string>> GetSettingsAsync()
        {
            return await _unitOfWork.SettingRepository.GetKeyValueSettingsAsync();
        }
    }
}
