using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var isPagePersistent = await _context.Navigations.AnyAsync(m => m.Path == path && m.Id == navigateId);
            
            if(!isPagePersistent && navigateId > 0 && orderId > 0)
            {
                var nav = await _context.Navigations.FirstOrDefaultAsync(m => m.Id == navigateId);
                var prev = nav.PrevOrderId;
                var next = nav.NextOrderId;

                var prevAllowed = await _context.Navigations.AnyAsync(m => m.OrderId == prev && m.Path == path);
                var nextAllowed = await _context.Navigations.AnyAsync(m => m.OrderId == next && m.Path == path);
                var isAllowed = prevAllowed || nextAllowed;
                if (!isAllowed)
                {
                    context.Response.Redirect($"https://{context.Request.Host}{nav.Path}");
                }
            }

            await _next.Invoke(context);
        }
    }
}
