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
using Assessment.Areas.Assessments.Models.AssessmentViewModels;

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

        ////[HttpGet(Name = "TahapanTes")]
        //public async Task<ActionResult> Index()
        //{
        //    //HttpContext.Session.SetInt32("NavigateId", 11);
        //    //HttpContext.Session.SetInt32("OrderId", 5);
        //    var user = await _userManager.GetUserAsync(User);

        //    var tahapanTesViews = _context.ExamSections
        //        .Include(m => m.Exam).ThenInclude(m => m.ExamSchedules).ThenInclude(m => m.ExamEmployees).ThenInclude(m => m.Employee)
        //        .Include(m => m.Answers)
        //        .Where(m => m.Exam.ExamSchedules.Any(n => n.DateExam.Date == DateTime.Now.Date))
        //        .Where(m => m.Exam.ExamSchedules.Any(n => n.ExamEmployees.Any(o => o.Employee.UserForeignKey == user.Id)))
        //        .OrderBy(m => m.Id)
        //        .Select(m => new TahapanTesViewModel { SectionId = m.Id, SectionName = m.Name, Duration = m.Duration });

        //    return View(tahapanTesViews);
        //}

        ////[HttpGet("[action]", Name = "Instruction")]
        //public async Task<ActionResult> Instruction(int SectionId)
        //{
        //    var examSection = await _context.ExamSections.FirstOrDefaultAsync(m => m.Id == SectionId);
        //    var instructionView = new InstructionViewModel
        //    {
        //        SectionId = examSection.Id,
        //        SectionName = examSection.Name,
        //        Notes = examSection.Notes,
        //        Duration = examSection.Duration
        //    };
        //    return View(instructionView);
        //}

        ////[HttpGet("[action]", Name = "Exam")]
        //public async Task<ActionResult> Exam(int SectionId, int QuestionId)
        //{
        //    //HttpContext.Session.SetInt32("NavigateId", 12);
        //    //HttpContext.Session.SetInt32("OrderId", 6);
        //    var examSection = await _context.ExamSections.FirstOrDefaultAsync(m => m.Id == SectionId);
        //    var instructionView = new InstructionViewModel
        //    {
        //        SectionId = examSection.Id,
        //        SectionName = examSection.Name,
        //        Notes = examSection.Notes,
        //        Duration = examSection.Duration
        //    };
        //    return View(instructionView);
        //}

        ////[HttpGet("Tahap1/{nomer}", Name = "Tahap1Soal")]
        //public ActionResult Soal(int nomer)
        //{
        //    HttpContext.Session.SetInt32("NavigateId", 13);
        //    HttpContext.Session.SetInt32("OrderId", 7);
        //    return View($"Soal{nomer}");
        //}
    }
}