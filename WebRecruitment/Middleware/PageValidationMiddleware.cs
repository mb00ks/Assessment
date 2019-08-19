using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRecruitment.Middleware
{
    public class PageValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public PageValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var status = context.Session.GetString("status");
            var host = context.Request.Host.Value.ToString();
            var path = context.Request.Path.Value.ToString();
            var area = "Assessments";
            var controller = "TahapanTes";
            //var action = "Index";
            if (!string.IsNullOrEmpty(status) && !path.Contains("Logout"))
            {
                if (!path.Contains("TahapanTes") && status == "TahapanTes")
                {
                    context.Response.Redirect($"https://{context.Request.Host}/{area}/{controller}");
                }
            }
            await _next.Invoke(context);
        }
    }
}
