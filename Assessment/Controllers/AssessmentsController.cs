using System;
using System.Text;
using System.Data;
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
using Npgsql;
using GeneralClass;

namespace Assessment.Controllers
{
    //[Authorize(Roles = "Peserta")]
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
            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var pegawai_id = HttpContext.Session.GetString("pelamar_id");
            var lowongan_id = HttpContext.Session.GetString("lowongan_id");

            var sb = new StringBuilder();
            sb.Append(" SELECT A.NAMA PEGAWAI_NAMA, A.NIP_BARU PEGAWAI_NIP, A.PEGAWAI_ID ID, A.EMAIL");
            sb.Append(" FROM simpeg.pegawai A");
            sb.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND EXISTS (");
            sb.Append(" SELECT 1");
            sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar X");
            sb.Append(" WHERE 1=1 AND X.LOWONGAN_ID = " + lowongan_id + " AND X.PEGAWAI_ID = A.PEGAWAI_ID)");

            var dt = new DataTable();
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                var dataPribadi = new Models.AssessmentViewModels.DataPribadiViewModel
                {
                    Email = dt.Rows[0]["email"].ToString(),
                    Name = dt.Rows[0]["pegawai_nama"].ToString()
                };
                return View(dataPribadi);
            }
            else
            {
                return NotFound();
            }

            //var user = await _userManager.GetUserAsync(User);
            //var employee = await _context.Employees.Where(m => m.UserForeignKey == user.Id).SingleOrDefaultAsync();
            //var dataPribadi = new Models.AssessmentViewModels.DataPribadiViewModel { Email = user.Email, Name = employee.Name };
            //return View(dataPribadi);
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

            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var ujian_id = HttpContext.Session.GetString("ujian_id");
            var tanggal_awal = HttpContext.Session.GetString("pegawai_tanggal_awal");
            var tanggal_akhir = HttpContext.Session.GetString("pegawai_tanggal_akhir");

            var sb = new StringBuilder();
            sb.Append(" SELECT UJIAN_ID, TGL_MULAI, TGL_SELESAI, CASE WHEN STATUS='0' THEN 'Belum Selesai' WHEN STATUS='1' THEN 'Sudah Selesai' END STATUS_UJIAN, STATUS, NILAI_LULUS, BATAS_WAKTU_MENIT, LAST_CREATE_DATE, LAST_CREATE_USER, LAST_UPDATE_DATE, LAST_UPDATE_USER");
            sb.Append(" FROM cat_rekrutmen.UJIAN A");
            sb.Append(" WHERE 1=1 AND A.UJIAN_ID = " + ujian_id);

            var dt = new DataTable();
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var batas_waktu = Convert.ToDouble(dt.Rows[0]["batas_waktu_menit"].ToString());
                var duration = TimeSpan.FromSeconds(batas_waktu);
                var persiapan = new Models.AssessmentViewModels.PersiapanViewModel
                {
                    TanggalAwal = Convert.ToDateTime(tanggal_awal),
                    TanggalAkhir = Convert.ToDateTime(tanggal_akhir),
                    Duration = duration
                };
                return View(persiapan);
            }
            else
            {
                return NotFound();
            }



            //var user = await _userManager.GetUserAsync(User);
            //var examEmployees = await _context.ExamEmployees
            //    .Include(m => m.Employee)
            //    .Include(m => m.ExamSchedule).ThenInclude(m => m.Exam)
            //    .Where(m => m.ExamSchedule.DateExam.Date == DateTime.Now.Date)
            //    .Where(m => m.Employee.UserForeignKey == user.Id)
            //    .LastOrDefaultAsync();
            //if (examEmployees == null)
            //{
            //    return View();
            //}
            //else
            //{
            //    var persiapan = new Models.AssessmentViewModels.PersiapanViewModel
            //    {
            //        DateExam = examEmployees.ExamSchedule.DateExam,
            //        Duration = examEmployees.ExamSchedule.Exam.Duration
            //    };
            //    return View(persiapan);
            //}
        }
    }
}