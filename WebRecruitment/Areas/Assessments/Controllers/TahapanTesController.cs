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
            HttpContext.Session.SetInt32("NavigateId", 11);
            HttpContext.Session.SetInt32("OrderId", 5);
            return View();
        }

        [HttpGet("[action]", Name = "Tahap1")]
        public ActionResult Tahap1()
        {
            HttpContext.Session.SetInt32("NavigateId", 12);
            HttpContext.Session.SetInt32("OrderId", 6);
            return View();
        }

        [HttpGet("Tahap1/{nomer}", Name = "Tahap1Soal")]
        public ActionResult Soal(int nomer)
        {
            HttpContext.Session.SetInt32("NavigateId", 13);
            HttpContext.Session.SetInt32("OrderId", 7);
            return View($"Soal{nomer}");
        }
    }
}