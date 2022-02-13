using HMS.Service.DTOs;
using HMS.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMS.Api.ServiceExtensions
{
    public static class ExceptionHandlerExtention
    {
        public static void AddExceptionHandlerService(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    int statusCode = StatusCodes.Status500InternalServerError;
                    string message = "Inter Server Error. Please Try Again Later!";

                    if(contextFeature != null)
                    {
                        message = contextFeature.Error.Message;

                        if (contextFeature.Error is ItemNotFoundException)
                            statusCode = 404;
                        else if (contextFeature.Error is RecordAlredyExistException)
                            statusCode = StatusCodes.Status409Conflict;
                        else if (contextFeature.Error is PageIndexFormException)
                            statusCode = StatusCodes.Status400BadRequest;
                    }

                    context.Response.StatusCode = statusCode;

                    var errorJsonStr = JsonConvert.SerializeObject(new ResponeDto { Status = statusCode, Message = message });
                    await context.Response.WriteAsync(errorJsonStr);
                });
            });
        }
    }
}
