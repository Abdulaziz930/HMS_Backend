using HMS.Service.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.ServiceExtensions
{
    public static class ConstantsHandler
    {
        public static void RegisterAllConstants(IConfiguration configuration, IWebHostEnvironment environment)
        {
            #region FireBase

            Constants.FireBaseApiKey = configuration["FireBase:ApiKey"];
            Constants.FireBaseBucket = configuration["FireBase:Bucket"];
            Constants.FireBaseAuthEmail = configuration["FireBase:AuthEmail"];
            Constants.FireBaseAuthPassword = configuration["FireBase:AuthPassword"];

            #endregion

            #region FolderPath

            Constants.ImageFolderPath = Path.Combine(environment.WebRootPath, "Uploads", "Images");
            Constants.ImageFolderPath = Path.Combine(environment.WebRootPath, "Uploads", "Videos");

            #endregion
        }
    }
}
