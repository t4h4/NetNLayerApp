using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using NetNLayerApp.API.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetNLayerApp.API.Extensions
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app) //IApplicationBuilder interface yapisina extensions method.(must be static class and method) (public void Configure(IApplicationBuilder app, IWebHostEnvironment env))
        {
            app.UseExceptionHandler(config =>
            {
                //hata firlatildiginda Run method ile calisilacak islemler silsilesi
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500; //internal server error
                    context.Response.ContentType = "application/json";
                    var error = context.Features.Get<IExceptionHandlerFeature>();//catch errors

                    if (error != null)
                    {
                        var ex = error.Error;

                        ErrorDto errorDto = new ErrorDto();
                        errorDto.Status = 500;
                        errorDto.Errors.Add(ex.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDto));//errorDto objesi, json'a donusturulup response ediliyor.
                    }
                });
            });
        }
    }
}
