using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebRecruitment.Data;

namespace WebRecruitment.Middleware
{
    public class PageValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public PageValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationDbContext _context)
        {
            var navigateId = context.Session.GetInt32("NavigateId");
            var orderId = context.Session.GetInt32("OrderId");
            var host = context.Request.Host.Value.ToString();
            var path = context.Request.Path.Value.ToString();
            var segments = context.Request.Path.Value.Split('/');
            var pathBase = context.Request.PathBase.ToUriComponent();

            //string pattern = "/Assessments/TahapanTes/Tahap1/\d+";
            //Regex re = new Regex(@pattern, RegexOptions.IgnoreCase);
            //var isMatch = re.IsMatch("/Assessments/TahapanTes/Tahap1/123123123");


            var isPagePersistent = await _context.Navigations.AnyAsync(m => new Regex(@m.Path, RegexOptions.IgnoreCase).IsMatch(path) && m.Id == navigateId);
            
            if(!isPagePersistent && navigateId > 0 && orderId > 0)
            {
                var nav = await _context.Navigations.FirstOrDefaultAsync(m => m.Id == navigateId);
                var prev = nav.PrevOrderId;
                var next = nav.NextOrderId;

                var prevAllowed = await _context.Navigations.AnyAsync(m => m.OrderId == prev && new Regex(@m.Path, RegexOptions.IgnoreCase).IsMatch(path));
                var nextAllowed = await _context.Navigations.AnyAsync(m => m.OrderId == next && new Regex(@m.Path, RegexOptions.IgnoreCase).IsMatch(path));
                var isAllowed = prevAllowed || nextAllowed;
                if (!isAllowed)
                {
                    if (!string.IsNullOrEmpty(nav.Route))
                    {
                        nav.Path = nav.Route;
                    }
                    context.Response.Redirect($"https://{context.Request.Host}{nav.Path}");
                }
            }

            await _next.Invoke(context);
        }
    }
}
