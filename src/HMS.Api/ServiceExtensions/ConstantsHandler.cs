using HMS.Service.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.ServiceExtensions
{
    public static class ConstantsHandler
    {
        public static void RegisterAllConstants(IConfiguration configuration)
        {
            #region FireBase

            Constants.FireBaseApiKey = configuration["FireBase:ApiKey"];
            Constants.FireBaseBucket = configuration["FireBase:Bucket"];
            Constants.FireBaseAuthEmail = configuration["FireBase:AuthEmail"];
            Constants.FireBaseAuthPassword = configuration["FireBase:AuthPassword"];

            #endregion
        }
    }
}
