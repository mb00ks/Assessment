using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Middleware;

namespace Assessment.Extensions
{
    public static class PageValidationMiddlewareExtensions
    {
        public static IApplicationBuilder UsePageValidation(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PageValidationMiddleware>();
        }
    }
}
