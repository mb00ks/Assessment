using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Data;
using WebRecruitment.Models;

namespace WebRecruitment.Controllers
{
    [Authorize(Roles = "Peserta")]
    [Route("[controller]/[action]")]
    public class AssessmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AssessmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet(Name = "DataPribadi")]
        public async Task<ActionResult> DataPribadi()
        {
            //HttpContext.Session.SetInt32("NavigateId", 2);
            //HttpContext.Session.SetInt32("OrderId", 2);
            var user = await _userManager.GetUserAsync(User);
            var employee = await _context.Employees.Where(m => m.UserForeignKey == user.Id).SingleOrDefaultAsync();
            var dataPribadi = new Models.AssessmentViewModels.DataPribadiViewModel { Email = user.Email, Name = employee.Name };
            return View(dataPribadi);
        }

        [HttpGet(Name = "FormPersetujuan")]
        public ActionResult FormPersetujuan()
        {
            //HttpContext.Session.SetInt32("NavigateId", 3);
            //HttpContext.Session.SetInt32("OrderId", 2);
            return View();
        }

        [HttpGet(Name = "Persiapan")]
        public async Task<ActionResult> Persiapan()
        {
            //HttpContext.Session.SetInt32("NavigateId", 5);
            //HttpContext.Session.SetInt32("OrderId", 2);
            var user = await _userManager.GetUserAsync(User);
            var scheduleDetail = await _context.ExamEmployees
                .Include(m => m.Employee)
                .Include(m => m.ExamSchedule)
                .Where(m => m.ExamSchedule.DateExam.Date == DateTime.Now.Date)
                .Where(m => m.Employee.UserForeignKey == user.Id)
                .LastOrDefaultAsync();
            var persiapan = new Models.AssessmentViewModels.PersiapanViewModel { DateExam = scheduleDetail.ExamSchedule.DateExam, Duration = new TimeSpan() };
            return View(persiapan);
        }
    }
}