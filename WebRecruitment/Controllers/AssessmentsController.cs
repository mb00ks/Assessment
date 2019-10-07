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
            HttpContext.Session.SetInt32("NavigateId", 2);
            HttpContext.Session.SetInt32("OrderId", 2);
            return View();
        }

        [HttpGet(Name = "FormPersetujuan")]
        public ActionResult FormPersetujuan()
        {
            HttpContext.Session.SetInt32("NavigateId", 3);
            HttpContext.Session.SetInt32("OrderId", 2);
            return View();
        }

        [HttpGet(Name = "Persiapan")]
        public ActionResult Persiapan()
        {
            HttpContext.Session.SetInt32("NavigateId", 5);
            HttpContext.Session.SetInt32("OrderId", 2);
            return View();
        }
    }
}