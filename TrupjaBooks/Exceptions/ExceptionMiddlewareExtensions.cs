using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using System.Net;
using TrupjaBooks.Data.Models.DTOs;

namespace TrupjaBooks.Exceptions
{
    public static class ExceptionMiddlewareExtensions
    {
        // ekstenzion metode svaka klasa koja koristi mora bit static klasa
        public static void ConfigureBuildInExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var contextRequest = context.Features.Get<IHttpRequestFeature>();

                    if (contextFeature is not null)
                    {
                        await context.Response.WriteAsync(new ErrorDTO
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Path = contextFeature.Path
                        }.ToString());
                    }
                });
            });
        }
    }
}
