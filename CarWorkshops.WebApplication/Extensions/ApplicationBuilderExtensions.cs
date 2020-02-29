using CarWorkshops.Data.Exceptions;
using CarWorkshops.WebApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CarWorkshops.WebApplication.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    Exception error = contextFeature.Error;
                    ModelNotFoundException modelNotFoundError = error as ModelNotFoundException;
                    if (modelNotFoundError != null)
                    {
                        await ErrorHandler(context, logger, HttpStatusCode.NotFound, modelNotFoundError);
                        return;
                    }
                    UnknownModelException unknownModelError = error as UnknownModelException;
                    if (unknownModelError != null)
                    {
                        await ErrorHandler(context, logger, HttpStatusCode.BadRequest, unknownModelError);
                        return;
                    }
                    DuplicateModelException duplicateModelError = error as DuplicateModelException;
                    if (duplicateModelError != null)
                    {
                        await ErrorHandler(context, logger, HttpStatusCode.Conflict, duplicateModelError);
                        return;
                    }
                    if (error != null)
                    {
                        await ErrorHandler(context, logger, HttpStatusCode.InternalServerError, "Internal Server Error.", error);
                    }
                });
            });
        }

        private static async Task ErrorHandler(HttpContext context, ILogger logger, HttpStatusCode httpStatusCode, Exception exception)
        {
            await ErrorHandler(context, logger, httpStatusCode, exception.Message, exception);
        }

        private static async Task ErrorHandler(HttpContext context, ILogger logger, HttpStatusCode httpStatusCode, string responseMessage, Exception exception)
        {
            logger.LogError(exception, exception.Message);

            context.Response.StatusCode = (int)httpStatusCode;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = responseMessage
            }.ToString());
        }
    }
}
