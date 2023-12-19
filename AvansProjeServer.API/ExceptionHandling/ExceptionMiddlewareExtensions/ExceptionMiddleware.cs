using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AvansProjeServer.API.ExceptionHandling.ErrorModel;
using AvansProjeServer.Log.Methods;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AvansProjeServer.API.ExceptionHandling.ExceptionMiddlewareExtensions
{
    public static class ExceptionMiddleware
    {
        //public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerManager logger)
        //{
        //    app.UseExceptionHandler(appError =>
        //    {
        //        appError.Run(async context =>
        //        {
        //            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        //            context.Response.ContentType = "application/json";
        //            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
        //            if (contextFeature != null)
        //            {
        //                logger.LogError("Hata oluştu: "+ contextFeature.Error);
        //                await context.Response.WriteAsync(new ErrorDetails
        //                {
        //                    StatusCode = context.Response.StatusCode,
        //                    Message = "Hata"
        //                }.ToString());
        //            }

        //        });
        //    });
        //}
    }
}
