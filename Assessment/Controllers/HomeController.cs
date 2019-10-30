using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Assessment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Assessment.Controllers
{
    [Authorize(Roles = "Peserta")]
    public class HomeController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet("AccessDenied")]
        public async Task<IActionResult> LoginAccessDenied()
        {
            if (User.IsInRole("Admin"))
            {
                await _signInManager.SignOutAsync();
                return LocalRedirect("~/admin");
            }
            else
            {
                await _signInManager.SignOutAsync();
                return LocalRedirect("~/");
            }
        }

        //[AllowAnonymous]
        //[HttpGet("Login")]
        //public IActionResult Login()
        //{
        //    return Content("this is Login");
        //}

        //[AllowAnonymous]
        //[HttpGet("Logout")]
        //public IActionResult Logout()
        //{
        //    return Content("this is Logout");
        //}

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
            if (code == 403 || code == 404 || code == 500 || code == 501)
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
