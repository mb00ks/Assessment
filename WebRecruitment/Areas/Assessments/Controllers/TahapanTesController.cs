using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebRecruitment.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    [Route("[area]/[controller]")]
    [Authorize(Roles = "Peserta")]
    public class TahapanTesController : Controller
    {
        [HttpGet(Name = "TahapanTes")]
        public ActionResult Index()
        {
            var status = HttpContext.Session.GetString("status");
            if (!string.IsNullOrEmpty(status))
            {
                HttpContext.Session.SetString("status", "TahapanTes");
                return View();
            }
            else
            {
                var url = Url.RouteUrl("DataPribadi");
                return LocalRedirect(url);
            }
        }

        [HttpGet("[action]", Name = "Tahap1")]
        public ActionResult Tahap1()
        {
            var status = HttpContext.Session.GetString("status");
            if (!string.IsNullOrEmpty(status))
            {
                HttpContext.Session.SetString("status", "Tahap1");
                return View();
            }
            else
            {
                var url = Url.RouteUrl("DataPribadi");
                return LocalRedirect(url);
            }

        }

        [HttpGet("Tahap1/{nomer}", Name = "Tahap1Soal")]
        public ActionResult Soal(int nomer)
        {
            var status = HttpContext.Session.GetString("status");
            if (!string.IsNullOrEmpty(status))
            {
                HttpContext.Session.SetString("status", "Tahap1Soal");
                return View($"Soal{nomer}");
            }
            else
            {
                var url = Url.RouteUrl("DataPribadi");
                return LocalRedirect(url);
            }
        }
    }
}