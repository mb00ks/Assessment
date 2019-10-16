using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assessment.Data;
using Assessment.Models;
using Assessment.Models.AssessmentViewModels;

namespace Assessment.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    [Route("[area]/[controller]")]
    [Authorize(Roles = "Peserta")]
    public class TahapanTesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public TahapanTesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet(Name = "TahapanTes")]
        public async Task<ActionResult> Index()
        {
            //HttpContext.Session.SetInt32("NavigateId", 11);
            //HttpContext.Session.SetInt32("OrderId", 5);
            var user = await _userManager.GetUserAsync(User);
            var scheduleDetail = await _context.ExamEmployees
                .Include(m => m.Employee)
                .Include(m => m.ExamSchedule)
                .Where(m => m.ExamSchedule.DateExam.Date == DateTime.Now.Date)
                .Where(m => m.Employee.UserForeignKey == user.Id)
                .LastOrDefaultAsync();

            var tahapanTesViewModels = _context.Questions
                .Include(m => m.QuestionType)
                .Where(m => m.QuestionTypeId == scheduleDetail.ExamScheduleId)
                .Select(m => new TahapanTesViewModel { SectionId = m.QuestionTypeId, SectionName = m.QuestionType.Name })
                .Distinct();

            return View(tahapanTesViewModels);
        }

        [HttpGet("[action]", Name = "Exam")]
        public ActionResult Exam(int QuestionTypeId)
        {
            //HttpContext.Session.SetInt32("NavigateId", 12);
            //HttpContext.Session.SetInt32("OrderId", 6);
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