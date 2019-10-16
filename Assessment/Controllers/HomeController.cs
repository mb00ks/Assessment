using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assessment.Models;

namespace Assessment.Controllers
{
    [Authorize(Roles = "Peserta")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        [Route("Error/{code:int}")]
        public IActionResult Error(int code)
        {
            if (code == 403 || code == 404 || code == 500)
            {
                return View($"~/Views/Shared/Error/{code}.cshtml");
            }
            else if (code == 401)
            {
                return Unauthorized();
            }
            else if (code == 400)
            {
                return BadRequest();
            }
            else if (code == 204)
            {
                return NoContent();
            }
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
