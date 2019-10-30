using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Areas.Assessments.Models.AssessmentViewModels;
using Assessment.Data;
using Assessment.Models;
using Assessment.Models.AssessmentViewModels;
using Assessment.Services.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    [Route("[area]/[action]")]
    //[Authorize(Roles = "Peserta")]
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

        [HttpGet(Name = "TahapanTes")]
        public async Task<IActionResult> TahapanTes()
        {
            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var pegawai_id = HttpContext.Session.GetString("pelamar_id");
            var ujian_id = HttpContext.Session.GetString("ujian_id");
            var tanggal_awal = HttpContext.Session.GetString("pegawai_tanggal_awal");
            var tanggal_akhir = HttpContext.Session.GetString("pegawai_tanggal_akhir");

            var sb = new StringBuilder();
            sb.Append(" SELECT");
            sb.Append(" 			A.UJIAN_ID, A.UJIAN_PEGAWAI_DAFTAR_ID, B.UJIAN_TAHAP_ID");
            sb.Append(" 			, C.TIPE, D.TIPE_INFO");
            sb.Append(" 			, B.MENIT_SOAL, C.TIPE_UJIAN_ID, LENGTH(C.PARENT_ID) LENGTH_PARENT, C.PARENT_ID");
            sb.Append(" 			, (");
            sb.Append(" SELECT 1");
            sb.Append(" FROM cat_rekrutmen.UJIAN_TAHAP_STATUS_UJIAN X");
            sb.Append(" WHERE 1=1 AND X.UJIAN_ID = A.UJIAN_ID AND X.UJIAN_TAHAP_ID = B.UJIAN_TAHAP_ID AND X.PEGAWAI_ID = A.PEGAWAI_ID) TIPE_STATUS");
            sb.Append(" 			, CASE C.TIPE_UJIAN_ID WHEN 16 THEN 50 ELSE B.JUMLAH_SOAL END JUMLAH_SOAL");
            sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb.Append(" INNER JOIN ");
            sb.Append(" 		(");
            sb.Append(" SELECT A.*, JUMLAH_SOAL");
            sb.Append(" FROM cat_rekrutmen.ujian_tahap A");
            sb.Append(" LEFT JOIN ");
            sb.Append(" 			(");
            sb.Append(" SELECT UJIAN_TAHAP_ID ROWID, COUNT(1) JUMLAH_SOAL");
            sb.Append(" FROM cat_rekrutmen.ujian_bank_soal");
            sb.Append(" GROUP BY UJIAN_TAHAP_ID");
            sb.Append(" 			) B ON UJIAN_TAHAP_ID = ROWID");
            sb.Append(" 		) B ON A.UJIAN_ID = B.UJIAN_ID");
            sb.Append(" LEFT JOIN cat_rekrutmen.TIPE_UJIAN C ON B.TIPE_UJIAN_ID = C.TIPE_UJIAN_ID");
            sb.Append(" LEFT JOIN");
            sb.Append(" 		(");
            sb.Append(" SELECT");
            sb.Append(" 			A.ID ID_ROW, A.TIPE TIPE_INFO");
            sb.Append(" FROM cat_rekrutmen.TIPE_UJIAN A");
            sb.Append(" WHERE 1=1 AND PARENT_ID = '0'");
            sb.Append(" 		) D ON C.PARENT_ID = D.ID_ROW");
            sb.Append(" WHERE 1=1 AND COALESCE(B.MENIT_SOAL,0) > 0 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id);
            sb.Append(" ORDER BY ID ASC");

            var dt = new DataTable();
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var tahapanTests = new List<TahapanTesViewModel>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var menit_soal = Convert.ToDouble(dt.Rows[i]["menit_soal"].ToString());
                    var duration = TimeSpan.FromMinutes(menit_soal);
                    var tahapanTes = new TahapanTesViewModel
                    {
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        TipeUjianId = Convert.ToInt32(dt.Rows[i]["tipe_ujian_id"].ToString()),
                        Tipe = (dt.Rows[i]["tipe_info"].ToString() ?? "") + " " + dt.Rows[i]["tipe"].ToString(),
                        Duration = duration
                    };
                    tahapanTests.Add(tahapanTes);
                }

                return View(tahapanTests);
            }
            else
            {
                return NotFound();
            }

            //var user = await _userManager.GetUserAsync(User);

            //var tahapanTesViews = _context.ExamSections
            //    .Include(m => m.Exam).ThenInclude(m => m.ExamSchedules).ThenInclude(m => m.ExamEmployees).ThenInclude(m => m.Employee)
            //    .Where(m => m.Exam.ExamSchedules.Any(n => n.DateExam.Date == DateTime.Now.Date))
            //    .Where(m => m.Exam.ExamSchedules.Any(n => n.ExamEmployees.Any(o => o.Employee.UserForeignKey == user.Id)))
            //    .OrderBy(m => m.Id)
            //    .Select(m => new TahapanTesViewModel { SectionId = m.Id, SectionName = m.Name, Duration = m.Duration });

            //return View(tahapanTesViews);
        }

        [HttpGet(Name = "Instruction")]
        public async Task<ActionResult> Instruction(int UjianTahapId)
        {
            var instructionView = new InstructionViewModel
            {
                UjianTahapId = UjianTahapId
            };
            //var examSection = await _context.ExamSections.Include(m => m.ExamQuestions).FirstOrDefaultAsync(m => m.Id == SectionId);
            //var instructionView = new InstructionViewModel
            //{
            //    SectionId = examSection.Id,
            //    QuestionId = examSection.ExamQuestions.FirstOrDefault(m => m.Number == 1).QuestionId,
            //    SectionName = examSection.Name,
            //    Notes = examSection.Notes,
            //    Duration = examSection.Duration
            //};
            return View(instructionView);
        }

        [HttpGet(Name = "Exam")]
        public async Task<ActionResult> Exam(int UjianTahapId, int BankSoalId) //int SectionId, int QuestionId
        {
            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var pegawai_id = HttpContext.Session.GetString("pelamar_id");
            var ujian_id = HttpContext.Session.GetString("ujian_id");
            var tanggal_awal = HttpContext.Session.GetString("pegawai_tanggal_awal");
            var tanggal_akhir = HttpContext.Session.GetString("pegawai_tanggal_akhir");

            var dt = new DataTable();

            var sb2 = new StringBuilder();
            sb2.Append(" SELECT");
            sb2.Append(" 			A.UJIAN_ID, A.UJIAN_PEGAWAI_DAFTAR_ID, B.UJIAN_TAHAP_ID");
            sb2.Append(" 			, C.TIPE, D.TIPE_INFO");
            sb2.Append(" 			, B.MENIT_SOAL, C.TIPE_UJIAN_ID, LENGTH(C.PARENT_ID) LENGTH_PARENT, C.PARENT_ID");
            sb2.Append(" 			, (");
            sb2.Append(" SELECT 1");
            sb2.Append(" FROM cat_rekrutmen.UJIAN_TAHAP_STATUS_UJIAN X");
            sb2.Append(" WHERE 1=1 AND X.UJIAN_ID = A.UJIAN_ID AND X.UJIAN_TAHAP_ID = B.UJIAN_TAHAP_ID AND X.PEGAWAI_ID = A.PEGAWAI_ID) TIPE_STATUS");
            sb2.Append(" 			, CASE C.TIPE_UJIAN_ID WHEN 16 THEN 50 ELSE B.JUMLAH_SOAL END JUMLAH_SOAL");
            sb2.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb2.Append(" INNER JOIN ");
            sb2.Append(" 		(");
            sb2.Append(" SELECT A.*, JUMLAH_SOAL");
            sb2.Append(" FROM cat_rekrutmen.ujian_tahap A");
            sb2.Append(" LEFT JOIN ");
            sb2.Append(" 			(");
            sb2.Append(" SELECT UJIAN_TAHAP_ID ROWID, COUNT(1) JUMLAH_SOAL");
            sb2.Append(" FROM cat_rekrutmen.ujian_bank_soal");
            sb2.Append(" GROUP BY UJIAN_TAHAP_ID");
            sb2.Append(" 			) B ON UJIAN_TAHAP_ID = ROWID");
            sb2.Append(" 		) B ON A.UJIAN_ID = B.UJIAN_ID");
            sb2.Append(" LEFT JOIN cat_rekrutmen.TIPE_UJIAN C ON B.TIPE_UJIAN_ID = C.TIPE_UJIAN_ID");
            sb2.Append(" LEFT JOIN");
            sb2.Append(" 		(");
            sb2.Append(" SELECT");
            sb2.Append(" 			A.ID ID_ROW, A.TIPE TIPE_INFO");
            sb2.Append(" FROM cat_rekrutmen.TIPE_UJIAN A");
            sb2.Append(" WHERE 1=1 AND PARENT_ID = '0'");
            sb2.Append(" 		) D ON C.PARENT_ID = D.ID_ROW");
            sb2.Append(" WHERE 1=1 AND COALESCE(B.MENIT_SOAL,0) > 0 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId);
            sb2.Append(" ORDER BY ID ASC");

            var tipe = string.Empty;

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb2.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                tipe = "UJIAN " + dt.Rows[0]["tipe"].ToString().ToUpper();
            }

            var sb = new StringBuilder();
            sb.Append(" SELECT");
            sb.Append(" 	A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, D.BANK_SOAL_PILIHAN_ID, D.JAWABAN");
            sb.Append(" 	, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID, TIPE_SOAL,");
            sb.Append(" REPLACE(C.PATH_GAMBAR, '../', '../../angkasapura-admin/') PATH_GAMBAR1");
            sb.Append(" 	, C.PATH_GAMBAR");
            sb.Append(" 	, D.PATH_GAMBAR PATH_SOAL");
            sb.Append(" 	, C.PATH_SOAL PATH_SOAL1");
            sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
            sb.Append(" INNER JOIN cat_rekrutmen.bank_soal C ON B.BANK_SOAL_ID = C.BANK_SOAL_ID");
            sb.Append(" INNER JOIN cat_rekrutmen.bank_soal_pilihan D ON B.BANK_SOAL_ID = D.BANK_SOAL_ID");
            sb.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId + " AND COALESCE(NULLIF(D.JAWABAN, ''), NULL) IS NOT NULL AND A.UJIAN_ID = " + ujian_id + " AND B.BANK_SOAl_ID = " + BankSoalId);
            sb.Append(" ORDER BY LENGTH(C.PATH_SOAL), C.PATH_SOAL");

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var examViewModels = new List<ExamViewModel>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var examViewModel = new ExamViewModel
                    {
                        UjianBankSoalId = Convert.ToInt32(dt.Rows[i]["ujian_bank_soal_id"].ToString()),
                        BankSoalId = Convert.ToInt32(dt.Rows[i]["bank_soal_id"].ToString()),
                        TipeSoal = Convert.ToInt32(dt.Rows[i]["tipe_soal"].ToString()),
                        Judul = tipe,
                        PathGambar = dt.Rows[i]["path_gambar"].ToString(),
                        PathSoal = dt.Rows[i]["path_soal1"].ToString(),
                        PathJawaban = dt.Rows[i]["jawaban"].ToString()
                    };
                    examViewModels.Add(examViewModel);
                }

                return View(examViewModels);
            }
            else
            {
                return NotFound();
            }

            ////HttpContext.Session.SetInt32("NavigateId", 12);
            ////HttpContext.Session.SetInt32("OrderId", 6);
            //var user = await _userManager.GetUserAsync(User);
            //var examQuestions = await _context.ExamQuestions
            //    .Include(m => m.ExamSection).ThenInclude(m => m.Exam).ThenInclude(m => m.ExamSchedules).ThenInclude(m => m.ExamEmployees).ThenInclude(m => m.Employee)
            //    .Include(m => m.Question).ThenInclude(m => m.QuestionDetails)
            //    .Include(m => m.Question).ThenInclude(m => m.Answers).ThenInclude(m => m.AnswerDetails)
            //    .Where(m => m.ExamSectionId == SectionId)
            //    .OrderBy(m => m.Number)
            //    .ToListAsync();
            //var examQuestion = examQuestions.FirstOrDefault(m => m.QuestionId == QuestionId);
            //if (examQuestion == null)
            //{
            //    return NotFound();
            //}
            //var examSchedule = examQuestion.ExamSection.Exam.ExamSchedules.FirstOrDefault(m => m.DateExam.Date == DateTime.Now.Date);
            //if (examSchedule == null)
            //{
            //    return StatusCode(501);
            //}
            //var examEmployee = examSchedule.ExamEmployees.FirstOrDefault(m => m.Employee.UserForeignKey == user.Id);
            //var examEmployeeId = examEmployee.Id;
            //var answers = examEmployee.Answers?.ToList() ?? new List<Answer>();
            //var examView = new ExamViewModel
            //{
            //    ExamEmployeeId = examEmployeeId,
            //    SectionId = examQuestion.ExamSectionId,
            //    QuestionId = examQuestion.QuestionId,
            //    QuestionDetailId = 0,
            //    Number = examQuestion.Number,
            //    Duration = examQuestion.Duration,
            //    IsNext = false,
            //    SectionName = examQuestion.ExamSection.Name,
            //    Question = examQuestion.Question,
            //    QuestionDetails = examQuestion.Question.QuestionDetails.ToList(),
            //    ExamQuestions = examQuestions,
            //    Answers = answers,
            //};
            //return View(examView);
        }

        [HttpPost(Name = "Answer")]
        public async Task<ActionResult> Answer(AnswerModel answerModel)
        {
            var user = await _userManager.GetUserAsync(User);
            var question = await _context.Questions.FindAsync(answerModel.QuestionId);
            var questionDetail = await _context.QuestionDetails.FindAsync(answerModel.QuestionDetailId);

            if (questionDetail != null)
            {
                //answer question
                var answer = await _context.Answers.Include(m => m.AnswerDetails).Where(m => m.ExamEmployeeId == answerModel.ExamEmployeeId).FirstOrDefaultAsync(m => m.QuestionId == answerModel.QuestionId);
                if (answer == null)
                {
                    var newAnswer = new Answer
                    {
                        ExamEmployeeId = answerModel.ExamEmployeeId,
                        ExamSectionId = answerModel.SectionId,
                        QuestionId = answerModel.QuestionId,
                        CreatedId = user.Id,
                        Item = question.Item
                    };
                    _context.Add(newAnswer);

                    var newAnswerDetail = new AnswerDetail
                    {
                        AnswerId = newAnswer.Id,
                        QuestionDetailId = answerModel.QuestionDetailId,
                        CreatedId = user.Id,
                        Item = questionDetail?.Item
                    };
                    _context.Add(newAnswerDetail);

                    await _context.SaveChangesAsync();
                }
                else
                {
                    answer.ExamEmployeeId = answerModel.ExamEmployeeId;
                    answer.ExamSectionId = answerModel.SectionId;
                    answer.QuestionId = answerModel.QuestionId;
                    answer.CreatedId = user.Id;
                    answer.Item = question.Item;
                    answer.AnswerDetails.FirstOrDefault().QuestionDetailId = answerModel.QuestionDetailId;
                    answer.AnswerDetails.FirstOrDefault().CreatedId = user.Id;
                    answer.AnswerDetails.FirstOrDefault().Item = questionDetail?.Item;
                    answer.AnswerDetails.FirstOrDefault().CreatedDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }

            //navigation
            var examQuestions = await _context.ExamQuestions.Where(m => m.ExamSectionId == answerModel.SectionId).ToListAsync();
            var examQuestion = examQuestions.FirstOrDefault(m => m.QuestionId == answerModel.QuestionId);
            var newNumber = examQuestion.Number;
            if (answerModel.IsNext.HasValue)
            {
                if (answerModel.IsNext.Value) newNumber++;
                else newNumber--;
                examQuestion = examQuestions.FirstOrDefault(m => m.Number == newNumber);
            }
            if (examQuestion == null)
            {
                return RedirectToAction(nameof(TahapanTes));
            }
            else
            {
                return RedirectToAction(nameof(Exam), new { SectionId = answerModel.SectionId, QuestionId = examQuestion.QuestionId });
            }
        }

        [HttpGet("Tahap1/{nomer}", Name = "Tahap1Soal")]
        public ActionResult Soal(int nomer)
        {
            //HttpContext.Session.SetInt32("NavigateId", 13);
            //HttpContext.Session.SetInt32("OrderId", 7);
            return View($"Soal{nomer}");
        }
    }
}