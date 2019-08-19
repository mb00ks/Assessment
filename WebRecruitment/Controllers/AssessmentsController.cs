using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebRecruitment.Controllers
{
    [Authorize(Roles = "Peserta")]
    [Route("[controller]/[action]")]
    public class AssessmentsController : Controller
    {
        [HttpGet(Name = "DataPribadi")]
        public ActionResult DataPribadi()
        {
            HttpContext.Session.SetString("status", "DataPribadi");
            return View();
        }

        [HttpGet(Name = "FormPersetujuan")]
        public ActionResult FormPersetujuan()
        {
            var status = HttpContext.Session.GetString("status");
            if (!string.IsNullOrEmpty(status))
            {
                HttpContext.Session.SetString("status", "FormPersetujuan");
                return View();
            }
            else
            {
                var url = Url.RouteUrl("DataPribadi");
                return LocalRedirect(url);
            }
        }

        [HttpGet(Name = "Persiapan")]
        public ActionResult Persiapan()
        {
            var status = HttpContext.Session.GetString("status");
            if (!string.IsNullOrEmpty(status))
            {
                HttpContext.Session.SetString("status", "Persiapan");
                return View();
            }
            else
            {
                var url = Url.RouteUrl("DataPribadi");
                return LocalRedirect(url);
            }
        }
    }
}