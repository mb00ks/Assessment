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
                    int tipeStatus = 0;
                    Int32.TryParse(dt.Rows[i]["tipe_status"].ToString(), out tipeStatus);
                    int jumlahSoal = 0;
                    Int32.TryParse(dt.Rows[i]["jumlah_soal"].ToString(), out jumlahSoal);
                    var tahapanTes = new TahapanTesViewModel
                    {
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        TipeUjianId = Convert.ToInt32(dt.Rows[i]["tipe_ujian_id"].ToString()),
                        Tipe = (dt.Rows[i]["tipe_info"].ToString() ?? "") + " " + dt.Rows[i]["tipe"].ToString(),
                        //MenitSoal = Convert.ToInt32(dt.Rows[i]["menit_soal"].ToString()),
                        //LengthParent = Convert.ToInt32(dt.Rows[i]["length_parent"].ToString()),
                        //ParentId = Convert.ToInt32(dt.Rows[i]["parent_id"].ToString()),
                        TipeStatus = tipeStatus,
                        JumlahSoal = jumlahSoal,
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
        public async Task<ActionResult> Instruction(int UjianTahapId, int TipeUjianId)
        {
            var instructionView = new InstructionViewModel
            {
                UjianTahapId = UjianTahapId,
                TipeUjianId = TipeUjianId
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
        public async Task<ActionResult> Exam(int UjianTahapId, int Nomer) //int SectionId, int QuestionId
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
            sb2.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId);

            var tipe = string.Empty;
            var length_parent = 0;
            var tipe_ujian_id = 0;

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb2.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                tipe = "UJIAN " + dt.Rows[0]["tipe"].ToString().ToUpper();
                length_parent = Convert.ToInt32(dt.Rows[0]["length_parent"].ToString());
                tipe_ujian_id = Convert.ToInt32(dt.Rows[0]["tipe_ujian_id"].ToString());
            }

            var sb3 = new StringBuilder();
            if (tipe_ujian_id == 7)
            {
                sb3.Append(" SELECT ");
                sb3.Append(" 	A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, '' KEMAMPUAN, '' KATEGORI, C.PERTANYAAN ");
                sb3.Append(" 	, A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID ");
                sb3.Append(" 	, '' TIPE_SOAL, '' PATH_GAMBAR, '' PATH_SOAL ");
                sb3.Append(" 	, B.UJIAN_TAHAP_ID ");
                sb3.Append(" 	, URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID ");
                sb3.Append(" 	, CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
                sb3.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb3.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
                sb3.Append(" INNER JOIN cat_rekrutmen.soal_papi C ON B.BANK_SOAL_ID = C.SOAL_PAPI_ID");
                sb3.Append(" LEFT JOIN ");
                sb3.Append(" (");
                sb3.Append(" SELECT ");
                sb3.Append(" 	UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
                sb3.Append($" FROM cat_rekrutmen_pegawai.ujian_pegawai_{ujian_id} A");
                sb3.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {pegawai_id} AND A.UJIAN_ID = {ujian_id} AND A.UJIAN_TAHAP_ID = {UjianTahapId} ");
                sb3.Append(" ) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
                sb3.Append(" LEFT JOIN ");
                sb3.Append(" (");
                sb3.Append(" SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append($" FROM cat_rekrutmen_pegawai.ujian_pegawai_{ujian_id}");
                sb3.Append(" WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
                sb3.Append(" GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID ");
                sb3.Append(" ) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
                sb3.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {pegawai_id} AND B.UJIAN_TAHAP_ID = {UjianTahapId} AND A.UJIAN_ID = {ujian_id}");
                sb3.Append(" ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID, UP.UJIAN_PEGAWAI_ID");
            }
            else if (tipe_ujian_id == 17)
            {
                sb3.Append(" SELECT");
                sb3.Append(" 	A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, '' KEMAMPUAN, '' KATEGORI, C.PERTANYAAN");
                sb3.Append(" 	, A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID");
                sb3.Append(" 	, '' TIPE_SOAL, '' PATH_GAMBAR, '' PATH_SOAL");
                sb3.Append(" 	, B.UJIAN_TAHAP_ID");
                sb3.Append(" 	, URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID");
                sb3.Append(" 	, CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
                sb3.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb3.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
                sb3.Append(" INNER JOIN cat_rekrutmen.soal_epps C ON B.BANK_SOAL_ID = C.SOAL_EPPS_ID");
                sb3.Append(" LEFT JOIN");
                sb3.Append(" (");
                sb3.Append(" SELECT");
                sb3.Append(" 	UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
                sb3.Append($" FROM cat_rekrutmen_pegawai.ujian_pegawai_{ujian_id} A");
                sb3.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {pegawai_id} AND A.UJIAN_ID = {ujian_id} AND A.UJIAN_TAHAP_ID = {UjianTahapId}");
                sb3.Append(" ) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
                sb3.Append(" LEFT JOIN");
                sb3.Append(" (");
                sb3.Append(" SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append($" FROM cat_rekrutmen_pegawai.ujian_pegawai_{ujian_id}");
                sb3.Append(" WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
                sb3.Append(" GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append(" ) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
                sb3.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {pegawai_id} AND B.UJIAN_TAHAP_ID = {UjianTahapId} AND A.UJIAN_ID = {ujian_id}");
                sb3.Append(" ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID, UP.UJIAN_PEGAWAI_ID");
            }
            else if (tipe_ujian_id == 41)
            {

            }
            else if (tipe_ujian_id == 42)
            {

            }
            else
            {
                sb3.Append(" SELECT");
                sb3.Append(" A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, C.KEMAMPUAN, C.KATEGORI, C.PERTANYAAN");
                sb3.Append(" , A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID");
                sb3.Append(" , C.TIPE_SOAL, C.PATH_GAMBAR, C.PATH_SOAL");
                sb3.Append(" , B.UJIAN_TAHAP_ID");
                sb3.Append(" , URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID");
                sb3.Append(" , CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
                sb3.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb3.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
                sb3.Append(" INNER JOIN cat_rekrutmen.bank_soal C ON B.BANK_SOAL_ID = C.BANK_SOAL_ID");
                sb3.Append(" LEFT JOIN");
                sb3.Append(" (");
                sb3.Append(" SELECT");
                sb3.Append(" UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
                sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + ujian_id + " A");
                sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id + " AND A.UJIAN_TAHAP_ID = " + UjianTahapId);
                sb3.Append(" ) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
                sb3.Append(" LEFT JOIN");
                sb3.Append(" (");
                sb3.Append(" SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + ujian_id);
                sb3.Append(" WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
                sb3.Append(" GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append(" ) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
                sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId + " AND A.UJIAN_ID = " + ujian_id);

                var orderBy = " ORDER BY URUT, RANDOM()";
                if (length_parent == 2)
                {
                    orderBy = " ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID, UP.UJIAN_PEGAWAI_ID";
                }

                sb3.Append(orderBy);
            }

            var jawabans = new List<Jawaban>();

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb3.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var nomer = 0;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    int Urut = 0;
                    Int32.TryParse(dt.Rows[i]["urut"].ToString(), out Urut);
                    int BankSoalPilihanId = 0;
                    Int32.TryParse(dt.Rows[i]["bank_soal_pilihan_id"].ToString(), out BankSoalPilihanId);
                    int UjianPegawaiId = 0;
                    Int32.TryParse(dt.Rows[i]["ujian_pegawai_id"].ToString(), out UjianPegawaiId);
                    int JumlahData = 0;
                    Int32.TryParse(dt.Rows[i]["jumlah_data"].ToString(), out JumlahData);
                    int TipeSoal = 0;
                    Int32.TryParse(dt.Rows[i]["tipe_soal"].ToString(), out TipeSoal);

                    var jawaban = new Jawaban
                    {
                        Nomer = ++nomer,
                        UjianId = Convert.ToInt32(dt.Rows[i]["ujian_id"].ToString()),
                        UjianBankSoalId = Convert.ToInt32(dt.Rows[i]["ujian_bank_soal_id"].ToString()),
                        BankSoalId = Convert.ToInt32(dt.Rows[i]["bank_soal_id"].ToString()),
                        Pertanyaan = Convert.ToString(dt.Rows[i]["pertanyaan"].ToString()),
                        PegawaiId = Convert.ToInt32(dt.Rows[i]["pegawai_id"].ToString()),
                        UjianPegawaiDaftarId = Convert.ToInt32(dt.Rows[i]["ujian_pegawai_daftar_id"].ToString()),
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        TipeSoal = TipeSoal,
                        Urut = Urut,
                        BankSoalPilihanId = BankSoalPilihanId,
                        UjianPegawaiId = UjianPegawaiId,
                        JumlahData = JumlahData,
                    };
                    jawabans.Add(jawaban);
                }
            }

            var SoalDanJawaban = jawabans.FirstOrDefault(m => m.Nomer == Nomer);
            var BankSoalId = SoalDanJawaban.BankSoalId;

            var sb = new StringBuilder();
            if (tipe_ujian_id == 7)
            {
                sb.Append(" SELECT");
                sb.Append(" 	A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, D.PAPI_PILIHAN_ID BANK_SOAL_PILIHAN_ID, D.JAWABAN");
                sb.Append(" 	, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID, C.TIPE_UJIAN_ID TIPE_SOAL, ");
                sb.Append(" 	'' PATH_GAMBAR1");
                sb.Append(" 	, '' PATH_GAMBAR");
                sb.Append(" 	, '' PATH_SOAL");
                sb.Append(" 	, '' PATH_SOAL1");
                sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
                sb.Append(" INNER JOIN cat_rekrutmen.soal_papi C ON B.BANK_SOAL_ID = C.SOAL_PAPI_ID");
                sb.Append(" INNER JOIN cat_rekrutmen.papi_pilihan D ON B.BANK_SOAL_ID = D.SOAL_PAPI_ID");
                sb.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {pegawai_id} AND B.UJIAN_TAHAP_ID = {UjianTahapId} AND COALESCE(NULLIF(D.JAWABAN, ''), NULL) IS NOT NULL AND A.UJIAN_ID = {ujian_id} AND B.BANK_SOAl_ID = {BankSoalId}");
                sb.Append(" ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID");
            }
            else if (tipe_ujian_id == 17)
            {
                sb.Append(" SELECT");
                sb.Append(" 	A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, D.EPPS_PILIHAN_ID BANK_SOAL_PILIHAN_ID, D.JAWABAN");
                sb.Append(" 	, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID, C.TIPE_UJIAN_ID TIPE_SOAL, ");
                sb.Append(" 	'' PATH_GAMBAR1");
                sb.Append(" 	, '' PATH_GAMBAR");
                sb.Append(" 	, '' PATH_SOAL");
                sb.Append(" 	, '' PATH_SOAL1");
                sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
                sb.Append(" INNER JOIN cat_rekrutmen.soal_epps C ON B.BANK_SOAL_ID = C.SOAL_EPPS_ID");
                sb.Append(" INNER JOIN cat_rekrutmen.epps_pilihan D ON B.BANK_SOAL_ID = D.SOAL_EPPS_ID");
                sb.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {pegawai_id} AND B.UJIAN_TAHAP_ID = {UjianTahapId} AND COALESCE(NULLIF(D.JAWABAN, ''), NULL) IS NOT NULL AND A.UJIAN_ID = {ujian_id} AND B.BANK_SOAL_ID = {BankSoalId}");
                sb.Append(" ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID");
            }
            else if (tipe_ujian_id == 41)
            {

            }
            else if (tipe_ujian_id == 42)
            {

            }
            else
            {
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
                sb.Append(" ORDER BY D.BANK_SOAL_PILIHAN_ID"); //LENGTH(C.PATH_SOAL), C.PATH_SOAL}
            }

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var pilihanSoals = new List<PilihanSoal>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var pilihanSoal = new PilihanSoal
                    {
                        BankSoalPilihanId = Convert.ToInt32(dt.Rows[i]["bank_soal_pilihan_id"].ToString()),
                        Jawaban = dt.Rows[i]["jawaban"].ToString(),
                        PathGambar = dt.Rows[i]["path_gambar"].ToString(),
                        PathJawaban = dt.Rows[i]["jawaban"].ToString()
                    };
                    pilihanSoals.Add(pilihanSoal);
                }

                var examViewModel = new ExamViewModel
                {
                    Nomer = Nomer,
                    UjianBankSoalId = Convert.ToInt32(dt.Rows[0]["ujian_bank_soal_id"].ToString()),
                    BankSoalId = Convert.ToInt32(dt.Rows[0]["bank_soal_id"].ToString()),
                    TipeSoal = Convert.ToInt32(dt.Rows[0]["tipe_soal"].ToString()),
                    Judul = tipe,
                    PathGambar = dt.Rows[0]["path_gambar"].ToString(),
                    PathSoal = dt.Rows[0]["path_soal1"].ToString(),
                    SoalDanJawaban = SoalDanJawaban,
                    PilihanSoals = pilihanSoals,
                    Jawabans = jawabans
                };

                return View(examViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet(Name = "ExamMulti")]
        public async Task<ActionResult> ExamMulti(int UjianTahapId, int Nomer)
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
            sb2.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId);

            var tipe = string.Empty;
            var length_parent = 0;
            var tipe_ujian_id = 0;

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb2.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                tipe = "UJIAN " + dt.Rows[0]["tipe"].ToString().ToUpper();
                length_parent = Convert.ToInt32(dt.Rows[0]["length_parent"].ToString());
                tipe_ujian_id = Convert.ToInt32(dt.Rows[0]["tipe_ujian_id"].ToString());
            }

            var sb3 = new StringBuilder();
            if (tipe_ujian_id == 7)
            {

            }
            else if (tipe_ujian_id == 17)
            {

            }
            else if (tipe_ujian_id == 41)
            {

            }
            else if (tipe_ujian_id == 42)
            {

            }
            else
            {
                sb3.Append(" SELECT");
                sb3.Append(" A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, C.KEMAMPUAN, C.KATEGORI, C.PERTANYAAN");
                sb3.Append(" , A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID");
                sb3.Append(" , C.TIPE_SOAL, C.PATH_GAMBAR, C.PATH_SOAL");
                sb3.Append(" , B.UJIAN_TAHAP_ID");
                sb3.Append(" , URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID");
                sb3.Append(" , CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
                sb3.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb3.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
                sb3.Append(" INNER JOIN cat_rekrutmen.bank_soal C ON B.BANK_SOAL_ID = C.BANK_SOAL_ID");
                sb3.Append(" LEFT JOIN");
                sb3.Append(" (");
                sb3.Append(" SELECT");
                sb3.Append(" UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
                sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + ujian_id + " A");
                sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id + " AND A.UJIAN_TAHAP_ID = " + UjianTahapId);
                sb3.Append(" ) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
                sb3.Append(" LEFT JOIN");
                sb3.Append(" (");
                sb3.Append(" SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + ujian_id);
                sb3.Append(" WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
                sb3.Append(" GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
                sb3.Append(" ) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
                sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId + " AND A.UJIAN_ID = " + ujian_id);

                var orderBy = " ORDER BY URUT, RANDOM()";
                if (length_parent == 2)
                {
                    orderBy = " ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID, UP.UJIAN_PEGAWAI_ID";
                }

                sb3.Append(orderBy);
            }

            var jawabans = new List<Jawaban>();

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb3.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var nomer = 0;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    int Urut = 0;
                    Int32.TryParse(dt.Rows[i]["urut"].ToString(), out Urut);
                    int BankSoalPilihanId = 0;
                    Int32.TryParse(dt.Rows[i]["bank_soal_pilihan_id"].ToString(), out BankSoalPilihanId);
                    int UjianPegawaiId = 0;
                    Int32.TryParse(dt.Rows[i]["ujian_pegawai_id"].ToString(), out UjianPegawaiId);
                    int JumlahData = 0;
                    Int32.TryParse(dt.Rows[i]["jumlah_data"].ToString(), out JumlahData);

                    var jawaban = new Jawaban
                    {
                        Nomer = BankSoalPilihanId == 0 ? ++nomer : nomer,
                        UjianId = Convert.ToInt32(dt.Rows[i]["ujian_id"].ToString()),
                        UjianBankSoalId = Convert.ToInt32(dt.Rows[i]["ujian_bank_soal_id"].ToString()),
                        BankSoalId = Convert.ToInt32(dt.Rows[i]["bank_soal_id"].ToString()),
                        Pertanyaan = Convert.ToString(dt.Rows[i]["pertanyaan"].ToString()),
                        PegawaiId = Convert.ToInt32(dt.Rows[i]["pegawai_id"].ToString()),
                        UjianPegawaiDaftarId = Convert.ToInt32(dt.Rows[i]["ujian_pegawai_daftar_id"].ToString()),
                        TipeSoal = Convert.ToInt32(dt.Rows[i]["tipe_soal"].ToString()),
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        Urut = Urut,
                        BankSoalPilihanId = BankSoalPilihanId,
                        UjianPegawaiId = UjianPegawaiId,
                        JumlahData = JumlahData,
                    };
                    jawabans.Add(jawaban);
                }
            }

            var SoalDanJawaban = jawabans.FirstOrDefault(m => m.Nomer == Nomer);
            var SoalDanJawabans = jawabans.Where(m => m.Nomer == Nomer);
            var BankSoalId = SoalDanJawabans.FirstOrDefault().BankSoalId;

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
            sb.Append(" ORDER BY D.BANK_SOAL_PILIHAN_ID");

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var pilihanSoals = new List<PilihanSoal>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var pilihanSoal = new PilihanSoal
                    {
                        BankSoalPilihanId = Convert.ToInt32(dt.Rows[i]["bank_soal_pilihan_id"].ToString()),
                        Jawaban = dt.Rows[i]["jawaban"].ToString(),
                        PathGambar = dt.Rows[i]["path_gambar"].ToString(),
                        PathJawaban = dt.Rows[i]["jawaban"].ToString()
                    };
                    pilihanSoals.Add(pilihanSoal);
                }

                var examViewModel = new ExamViewModel
                {
                    Nomer = Nomer,
                    UjianBankSoalId = Convert.ToInt32(dt.Rows[0]["ujian_bank_soal_id"].ToString()),
                    BankSoalId = Convert.ToInt32(dt.Rows[0]["bank_soal_id"].ToString()),
                    TipeSoal = Convert.ToInt32(dt.Rows[0]["tipe_soal"].ToString()),
                    Judul = tipe,
                    PathGambar = dt.Rows[0]["path_gambar"].ToString(),
                    PathSoal = dt.Rows[0]["path_soal1"].ToString(),
                    SoalDanJawaban = SoalDanJawaban,
                    SoalDanJawabans = SoalDanJawabans,
                    PilihanSoals = pilihanSoals,
                    Jawabans = jawabans
                };
                if (!System.IO.File.Exists(dt.Rows[0]["path_gambar"].ToString() + dt.Rows[0]["path_soal1"].ToString()))
                {
                    examViewModel.PathSoal = string.Empty;
                }

                return View(examViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet(Name = "ExamKraepelin")]
        public async Task<ActionResult> ExamKraepelin(int UjianTahapId, int Nomer)
        {
            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var pegawai_id = HttpContext.Session.GetString("pelamar_id");
            var ujian_id = HttpContext.Session.GetString("ujian_id");
            var lowongan_id = HttpContext.Session.GetString("lowongan_id");
            var tanggal_awal = HttpContext.Session.GetString("pegawai_tanggal_awal");
            var tanggal_akhir = HttpContext.Session.GetString("pegawai_tanggal_akhir");

            KraepelinViewModel kraepelinViewModel = new KraepelinViewModel();

            var dt = new DataTable();

            var sb2 = new StringBuilder();
            sb2.Append(" SELECT ");
            sb2.Append(" 	A.UJIAN_ID, A.UJIAN_PEGAWAI_DAFTAR_ID, B.UJIAN_TAHAP_ID");
            sb2.Append(" 	, C.TIPE, D.TIPE_INFO");
            sb2.Append(" 	, B.MENIT_SOAL, C.TIPE_UJIAN_ID, LENGTH(C.PARENT_ID) LENGTH_PARENT, C.PARENT_ID");
            sb2.Append(" 	, (");
            sb2.Append(" SELECT 1");
            sb2.Append(" FROM cat_rekrutmen.UJIAN_TAHAP_STATUS_UJIAN_LATIHAN X");
            sb2.Append(" WHERE 1=1 AND X.UJIAN_ID = A.UJIAN_ID AND X.UJIAN_TAHAP_ID = B.UJIAN_TAHAP_ID AND X.PEGAWAI_ID = A.PEGAWAI_ID) TIPE_STATUS");
            sb2.Append(" 	, CASE C.TIPE_UJIAN_ID WHEN 16 THEN 50 ELSE B.JUMLAH_SOAL END JUMLAH_SOAL");
            sb2.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb2.Append(" INNER JOIN ");
            sb2.Append(" (");
            sb2.Append(" SELECT A.*, JUMLAH_SOAL");
            sb2.Append(" FROM cat_rekrutmen.ujian_tahap_latihan A");
            sb2.Append(" LEFT JOIN ");
            sb2.Append(" 	(");
            sb2.Append(" SELECT UJIAN_TAHAP_ID ROWID, COUNT(1) JUMLAH_SOAL");
            sb2.Append(" FROM cat_rekrutmen.ujian_bank_soal_latihan");
            sb2.Append(" GROUP BY UJIAN_TAHAP_ID");
            sb2.Append(" 	) B ON UJIAN_TAHAP_ID = ROWID");
            sb2.Append(" ) B ON A.UJIAN_ID = B.UJIAN_ID");
            sb2.Append(" LEFT JOIN cat_rekrutmen.TIPE_UJIAN C ON B.TIPE_UJIAN_ID = C.TIPE_UJIAN_ID");
            sb2.Append(" LEFT JOIN");
            sb2.Append(" (");
            sb2.Append(" SELECT");
            sb2.Append(" 	A.ID ID_ROW, A.TIPE TIPE_INFO");
            sb2.Append(" FROM cat_rekrutmen.TIPE_UJIAN A");
            sb2.Append(" WHERE 1=1 AND PARENT_ID = '0'");
            sb2.Append(" ) D ON C.PARENT_ID = D.ID_ROW");
            sb2.Append($" WHERE 1=1 AND COALESCE(B.MENIT_SOAL,0) > 0 AND A.PEGAWAI_ID = {pegawai_id} AND A.UJIAN_ID = {ujian_id} AND B.UJIAN_TAHAP_ID = {UjianTahapId}");

            var tipe = string.Empty;
            var length_parent = 0;
            var tipe_ujian_id = 0;

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb2.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                tipe = "UJIAN " + dt.Rows[0]["tipe"].ToString().ToUpper();
                length_parent = Convert.ToInt32(dt.Rows[0]["length_parent"].ToString());
                tipe_ujian_id = Convert.ToInt32(dt.Rows[0]["tipe_ujian_id"].ToString());
            }

            var sb3 = new StringBuilder();
            sb3.Append(" SELECT A.PAKAI_KRAEPELIN_ID, MAX(A.X_DATA) X_DATA, MAX(A.Y_DATA) Y_DATA");
            sb3.Append(" 	, MIN(A.X_DATA) MIN_X_DATA, MAX(A.X_DATA) - MIN(A.X_DATA) CHECK_MIN_X_DATA");
            sb3.Append(" FROM cat_rekrutmen.KRAEPELIN_SOAL_LATIHAN A");
            sb3.Append(" WHERE 1=1 AND EXISTS");
            sb3.Append(" (");
            sb3.Append(" SELECT 1");
            sb3.Append(" FROM cat_rekrutmen.KRAEPELIN_PAKAI X");
            sb3.Append(" WHERE COALESCE(NULLIF(X.STATUS, ''), NULL) IS NULL AND A.PAKAI_KRAEPELIN_ID = X.PAKAI_KRAEPELIN_ID");
            sb3.Append(" ) AND NOT EXISTS");
            sb3.Append(" (");
            sb3.Append(" SELECT 1");
            sb3.Append(" FROM");
            sb3.Append(" (");
            sb3.Append(" SELECT");
            sb3.Append(" LOWONGAN_ID, UJIAN_ID, UJIAN_TAHAP_ID, PEGAWAI_ID, X_DATA");
            sb3.Append($" FROM cat_rekrutmen_pegawai.UJIAN_KRAEPELIN_LATIHAN_{ujian_id}");
            sb3.Append(" GROUP BY LOWONGAN_ID, UJIAN_ID, UJIAN_TAHAP_ID, PEGAWAI_ID, X_DATA");
            sb3.Append(" ) X");
            sb3.Append($" WHERE 1=1 AND X.PEGAWAI_ID = {pegawai_id} AND X.UJIAN_TAHAP_ID = {UjianTahapId} AND X.LOWONGAN_ID = {lowongan_id} AND A.X_DATA = X.X_DATA");
            sb3.Append(" )");
            sb3.Append(" GROUP BY A.PAKAI_KRAEPELIN_ID");

            var pakai_kraepelin_id = 0;
            var x_data = 0;
            var y_data = 0;
            var min_x_data = 0;
            var check_min_x_data = 0;

            var batas_soal = 0;

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb3.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                pakai_kraepelin_id = Convert.ToInt32(dt.Rows[0]["pakai_kraepelin_id"].ToString());
                x_data = Convert.ToInt32(dt.Rows[0]["x_data"].ToString());
                y_data = Convert.ToInt32(dt.Rows[0]["y_data"].ToString());
                min_x_data = Convert.ToInt32(dt.Rows[0]["min_x_data"].ToString());
                check_min_x_data = Convert.ToInt32(dt.Rows[0]["check_min_x_data"].ToString());

                kraepelinViewModel.PakaiKraepelinId = pakai_kraepelin_id;
                kraepelinViewModel.Xdata = x_data;
                kraepelinViewModel.Ydata = y_data;
                kraepelinViewModel.MinXdata = min_x_data;
                kraepelinViewModel.CheckMinXdata = check_min_x_data;

                if(kraepelinViewModel.CheckMinXdata == 1)
                {
                    batas_soal = kraepelinViewModel.Xdata = 1;
                }
                else
                {
                    batas_soal = kraepelinViewModel.Xdata = 2;
                }
                kraepelinViewModel.BatasSoal = batas_soal;

                kraepelinViewModel.Xdata = kraepelinViewModel.Xdata + kraepelinViewModel.MinXdata;
            }

            var sb4 = new StringBuilder();
            sb4.Append(" SELECT A.PAKAI_KRAEPELIN_ID, A.X_DATA, A.Y_DATA, A.NILAI");
            sb4.Append(" FROM cat_rekrutmen.KRAEPELIN_SOAL_LATIHAN A");
            sb4.Append($" WHERE 1=1 AND A.PAKAI_KRAEPELIN_ID = {pakai_kraepelin_id} AND NOT EXISTS");
            sb4.Append(" (");
            sb4.Append(" SELECT 1");
            sb4.Append(" FROM");
            sb4.Append(" (");
            sb4.Append(" SELECT");
            sb4.Append(" LOWONGAN_ID, UJIAN_ID, UJIAN_TAHAP_ID, PEGAWAI_ID, X_DATA");
            sb4.Append($" FROM cat_rekrutmen_pegawai.UJIAN_KRAEPELIN_LATIHAN_{ujian_id}");
            sb4.Append(" GROUP BY LOWONGAN_ID, UJIAN_ID, UJIAN_TAHAP_ID, PEGAWAI_ID, X_DATA");
            sb4.Append(" ) X");
            sb4.Append($" WHERE 1=1 AND X.PEGAWAI_ID = {pegawai_id} AND X.UJIAN_TAHAP_ID = {UjianTahapId} AND X.LOWONGAN_ID = {lowongan_id} AND A.X_DATA = X.X_DATA");
            sb4.Append(" )");
            sb4.Append(" ORDER BY X_DATA, Y_DATA DESC");

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb4.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                kraepelinViewModel.KraepelinViewModelSoals = new List<KraepelinViewModelSoal>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    KraepelinViewModelSoal kraepelinViewModelSoal = new KraepelinViewModelSoal();
                    kraepelinViewModelSoal.PakaiKraepelinId = Convert.ToInt32(dt.Rows[i]["pakai_kraepelin_id"].ToString());
                    kraepelinViewModelSoal.Xdata = Convert.ToInt32(dt.Rows[i]["x_data"].ToString());
                    kraepelinViewModelSoal.Ydata = Convert.ToInt32(dt.Rows[i]["y_data"].ToString());
                    kraepelinViewModelSoal.Koordinat = $"{kraepelinViewModelSoal.Xdata}-{kraepelinViewModelSoal.Ydata}";
                    kraepelinViewModelSoal.Nilai = Convert.ToInt32(dt.Rows[i]["nilai"].ToString());
                    kraepelinViewModel.KraepelinViewModelSoals.Add(kraepelinViewModelSoal);
                }
            }

            var sb5 = new StringBuilder();
            sb5.Append(" SELECT A.PAKAI_KRAEPELIN_ID, A.X_DATA, A.Y_DATA, A.NILAI");
            sb5.Append(" FROM cat_rekrutmen.KRAEPELIN_JAWAB_LATIHAN A");
            sb5.Append($" WHERE 1=1 AND A.PAKAI_KRAEPELIN_ID = {pakai_kraepelin_id} AND NOT EXISTS");
            sb5.Append(" (");
            sb5.Append(" SELECT 1");
            sb5.Append(" FROM");
            sb5.Append(" (");
            sb5.Append(" SELECT");
            sb5.Append(" LOWONGAN_ID, UJIAN_ID, UJIAN_TAHAP_ID, PEGAWAI_ID, X_DATA");
            sb5.Append($" FROM cat_rekrutmen_pegawai.UJIAN_KRAEPELIN_LATIHAN_{ujian_id}");
            sb5.Append(" GROUP BY LOWONGAN_ID, UJIAN_ID, UJIAN_TAHAP_ID, PEGAWAI_ID, X_DATA");
            sb5.Append(" ) X");
            sb5.Append($" WHERE 1=1 AND X.PEGAWAI_ID = {pegawai_id} AND X.UJIAN_TAHAP_ID = {UjianTahapId} AND X.LOWONGAN_ID = {lowongan_id} AND A.X_DATA = X.X_DATA");
            sb5.Append(" )");
            sb5.Append(" ORDER BY X_DATA, Y_DATA DESC");

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb5.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                kraepelinViewModel.KraepelinViewModelJawabans = new List<KraepelinViewModelJawaban>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    KraepelinViewModelJawaban kraepelinViewModelJawaban = new KraepelinViewModelJawaban();
                    kraepelinViewModelJawaban.PakaiKraepelinId = Convert.ToInt32(dt.Rows[i]["pakai_kraepelin_id"].ToString());
                    kraepelinViewModelJawaban.Xdata = Convert.ToInt32(dt.Rows[i]["x_data"].ToString());
                    kraepelinViewModelJawaban.Ydata = Convert.ToInt32(dt.Rows[i]["y_data"].ToString());
                    kraepelinViewModelJawaban.Koordinat = $"{kraepelinViewModelJawaban.Xdata}-{kraepelinViewModelJawaban.Ydata}";
                    kraepelinViewModelJawaban.Nilai = Convert.ToInt32(dt.Rows[i]["nilai"].ToString());
                    kraepelinViewModel.KraepelinViewModelJawabans.Add(kraepelinViewModelJawaban);
                }
            }

            return View(kraepelinViewModel);
        }

        [HttpPost(Name = "Answer")]
        public async Task<ActionResult> Answer(AnswerModel answerModel)
        {
            var sb = new StringBuilder();
            sb.Append(" SELECT");
            sb.Append(" 	A.UJIAN_PEGAWAI_DAFTAR_ID, A.LOWONGAN_ID");
            sb.Append(" 	, A.UJIAN_PEGAWAI_ID, A.UJIAN_ID, A.UJIAN_BANK_SOAL_ID, A.BANK_SOAL_ID");
            sb.Append(" 	, A.UJIAN_TAHAP_ID, A.TIPE_UJIAN_ID, A.PEGAWAI_ID, A.BANK_SOAL_PILIHAN_ID");
            sb.Append(" 	, A.TANGGAL, A.URUT");
            sb.Append($" FROM cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId} A");
            sb.Append(" WHERE 1=1 AND A.UJIAN_ID = " + answerModel.UjianId + " AND A.UJIAN_BANK_SOAL_ID = " + answerModel.UjianBankSoalId + " AND A.BANK_SOAL_ID = " + answerModel.BankSoalId + " AND A.PEGAWAI_ID = " + answerModel.PegawaiId + " AND A.UJIAN_TAHAP_ID = " + answerModel.UjianTahapId);

            var dt = new DataTable();
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var errMessage = string.Empty;
                var sb2 = new StringBuilder();
                sb2.Append($" UPDATE cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId}");
                sb2.Append(" SET UJIAN_ID= " + answerModel.UjianId + ", UJIAN_BANK_SOAL_ID= " + answerModel.UjianBankSoalId + ", PEGAWAI_ID= " + answerModel.PegawaiId + ", TANGGAL= NOW(), URUT= " + answerModel.Urut + ", BANK_SOAL_ID= " + answerModel.BankSoalId + ", BANK_SOAL_PILIHAN_ID= " + answerModel.BankSoalPilihanId + ", LAST_UPDATE_DATE= NOW(), LAST_UPDATE_USER= ''");
                sb2.Append(" WHERE UJIAN_PEGAWAI_ID= " + answerModel.UjianPegawaiId);
                var result = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery2(sb2.ToString(), "", null, ref errMessage);
                if (!result)
                {
                    return NotFound();
                }
            }

            var sb3 = new StringBuilder();
            sb3.Append(" SELECT");
            sb3.Append(" 			A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, C.KEMAMPUAN, C.KATEGORI, C.PERTANYAAN");
            sb3.Append(" 			, A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID");
            sb3.Append(" 			, C.TIPE_SOAL, C.PATH_GAMBAR, C.PATH_SOAL");
            sb3.Append(" 			, B.UJIAN_TAHAP_ID");
            sb3.Append(" 			, URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID");
            sb3.Append(" 			, CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
            sb3.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb3.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
            sb3.Append(" INNER JOIN cat_rekrutmen.bank_soal C ON B.BANK_SOAL_ID = C.BANK_SOAL_ID");
            sb3.Append(" LEFT JOIN");
            sb3.Append(" 		(");
            sb3.Append(" SELECT");
            sb3.Append(" 			UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
            sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + answerModel.UjianId + " A");
            sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + answerModel.PegawaiId + " AND A.UJIAN_ID = " + answerModel.UjianId + " AND A.UJIAN_TAHAP_ID = " + answerModel.UjianTahapId);
            sb3.Append(" 		) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
            sb3.Append(" LEFT JOIN");
            sb3.Append(" 		(");
            sb3.Append(" SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
            sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + answerModel.UjianId);
            sb3.Append(" WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
            sb3.Append(" GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
            sb3.Append(" 		) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
            sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + answerModel.PegawaiId + " AND B.UJIAN_TAHAP_ID = " + answerModel.UjianTahapId + " AND A.UJIAN_ID = " + answerModel.UjianId);
            sb3.Append(" ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID, UP.UJIAN_PEGAWAI_ID");

            var jawabans = new List<Jawaban>();

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb3.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var nomer = 0;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    int Urut = 0;
                    Int32.TryParse(dt.Rows[i]["urut"].ToString(), out Urut);
                    int BankSoalPilihanId = 0;
                    Int32.TryParse(dt.Rows[i]["bank_soal_pilihan_id"].ToString(), out BankSoalPilihanId);
                    int UjianPegawaiId = 0;
                    Int32.TryParse(dt.Rows[i]["ujian_pegawai_id"].ToString(), out UjianPegawaiId);
                    int JumlahData = 0;
                    Int32.TryParse(dt.Rows[i]["jumlah_data"].ToString(), out JumlahData);

                    var jawaban = new Jawaban
                    {
                        Nomer = ++nomer,
                        UjianId = Convert.ToInt32(dt.Rows[i]["ujian_id"].ToString()),
                        UjianBankSoalId = Convert.ToInt32(dt.Rows[i]["ujian_bank_soal_id"].ToString()),
                        BankSoalId = Convert.ToInt32(dt.Rows[i]["bank_soal_id"].ToString()),
                        Pertanyaan = Convert.ToString(dt.Rows[i]["pertanyaan"].ToString()),
                        PegawaiId = Convert.ToInt32(dt.Rows[i]["pegawai_id"].ToString()),
                        UjianPegawaiDaftarId = Convert.ToInt32(dt.Rows[i]["ujian_pegawai_daftar_id"].ToString()),
                        TipeSoal = Convert.ToInt32(dt.Rows[i]["tipe_soal"].ToString()),
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        Urut = Urut,
                        BankSoalPilihanId = BankSoalPilihanId,
                        UjianPegawaiId = UjianPegawaiId,
                        JumlahData = JumlahData,
                    };
                    jawabans.Add(jawaban);
                }
            }

            //navigation
            Jawaban jawabanFind = null;
            var newNumber = answerModel.Nomer;
            if (answerModel.IsNext.HasValue)
            {
                if (answerModel.IsNext.Value) newNumber++;
                else newNumber--;
                jawabanFind = jawabans.FirstOrDefault(m => m.Nomer == newNumber);
            }
            if (jawabanFind == null)
            {
                return RedirectToAction(nameof(TahapanTes));
            }
            else
            {
                return RedirectToAction(nameof(Exam), new { UjianTahapId = jawabanFind.UjianTahapId, Nomer = jawabanFind.Nomer });
            }

            //var user = await _userManager.GetUserAsync(User);
            //var question = await _context.Questions.FindAsync(answerModel.QuestionId);
            //var questionDetail = await _context.QuestionDetails.FindAsync(answerModel.QuestionDetailId);

            //if (questionDetail != null)
            //{
            //    //answer question
            //    var answer = await _context.Answers.Include(m => m.AnswerDetails).Where(m => m.ExamEmployeeId == answerModel.ExamEmployeeId).FirstOrDefaultAsync(m => m.QuestionId == answerModel.QuestionId);
            //    if (answer == null)
            //    {
            //        var newAnswer = new Answer
            //        {
            //            ExamEmployeeId = answerModel.ExamEmployeeId,
            //            ExamSectionId = answerModel.SectionId,
            //            QuestionId = answerModel.QuestionId,
            //            CreatedId = user.Id,
            //            Item = question.Item
            //        };
            //        _context.Add(newAnswer);

            //        var newAnswerDetail = new AnswerDetail
            //        {
            //            AnswerId = newAnswer.Id,
            //            QuestionDetailId = answerModel.QuestionDetailId,
            //            CreatedId = user.Id,
            //            Item = questionDetail?.Item
            //        };
            //        _context.Add(newAnswerDetail);

            //        await _context.SaveChangesAsync();
            //    }
            //    else
            //    {
            //        answer.ExamEmployeeId = answerModel.ExamEmployeeId;
            //        answer.ExamSectionId = answerModel.SectionId;
            //        answer.QuestionId = answerModel.QuestionId;
            //        answer.CreatedId = user.Id;
            //        answer.Item = question.Item;
            //        answer.AnswerDetails.FirstOrDefault().QuestionDetailId = answerModel.QuestionDetailId;
            //        answer.AnswerDetails.FirstOrDefault().CreatedId = user.Id;
            //        answer.AnswerDetails.FirstOrDefault().Item = questionDetail?.Item;
            //        answer.AnswerDetails.FirstOrDefault().CreatedDate = DateTime.Now;
            //        await _context.SaveChangesAsync();
            //    }
            //}

            ////navigation
            //var examQuestions = await _context.ExamQuestions.Where(m => m.ExamSectionId == answerModel.SectionId).ToListAsync();
            //var examQuestion = examQuestions.FirstOrDefault(m => m.QuestionId == answerModel.QuestionId);
            //var newNumber = examQuestion.Number;
            //if (answerModel.IsNext.HasValue)
            //{
            //    if (answerModel.IsNext.Value) newNumber++;
            //    else newNumber--;
            //    examQuestion = examQuestions.FirstOrDefault(m => m.Number == newNumber);
            //}
            //if (examQuestion == null)
            //{
            //    return RedirectToAction(nameof(TahapanTes));
            //}
            //else
            //{
            //    return RedirectToAction(nameof(Exam), new { SectionId = answerModel.SectionId, QuestionId = examQuestion.QuestionId });
            //}
        }

        [HttpPost(Name = "AnswerMulti")]
        public async Task<ActionResult> AnswerMulti(AnswerModel answerModel)
        {
            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var pegawai_id = HttpContext.Session.GetString("pelamar_id");
            var ujian_id = HttpContext.Session.GetString("ujian_id");
            var lowongan_id = HttpContext.Session.GetString("lowongan_id");
            var ujian_pegawai_daftar_id = HttpContext.Session.GetString("ujian_pegawai_daftar_id");

            var sb = new StringBuilder();
            sb.Append(" SELECT A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, C.KEMAMPUAN, C.KATEGORI, C.PERTANYAAN, A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID, C.TIPE_SOAL, C.PATH_GAMBAR, C.PATH_SOAL, B.UJIAN_TAHAP_ID, URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID, CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
            sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
            sb.Append(" INNER JOIN cat_rekrutmen.bank_soal C ON B.BANK_SOAL_ID = C.BANK_SOAL_ID");
            sb.Append(" LEFT JOIN (");
            sb.Append(" 	SELECT UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
            sb.Append($" 	FROM cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId} A");
            sb.Append($" 	WHERE 1=1 AND A.PEGAWAI_ID = {answerModel.PegawaiId} AND A.UJIAN_ID = {answerModel.UjianId} AND A.UJIAN_TAHAP_ID = {answerModel.UjianTahapId} AND A.BANK_SOAL_PILIHAN_ID = {answerModel.BankSoalPilihanId}) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
            sb.Append(" LEFT JOIN (");
            sb.Append(" 	SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
            sb.Append($" 	FROM cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId}");
            sb.Append(" 	WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
            sb.Append(" 	GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
            sb.Append($" WHERE 1=1 AND A.PEGAWAI_ID = {answerModel.PegawaiId} AND B.UJIAN_BANK_SOAL_ID = {answerModel.UjianBankSoalId} AND A.UJIAN_ID = {answerModel.UjianId} AND UP.BANK_SOAL_PILIHAN_ID = {answerModel.BankSoalPilihanId}");

            var dt = new DataTable();
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count == 0)
            {
                var ujian_pegawai_id = 0;
                var sb4 = new StringBuilder();
                sb4.Append($"(select MAX(UJIAN_PEGAWAI_ID) as maxvaluedata from cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId})");
                dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb4.ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    ujian_pegawai_id = Convert.ToInt32(dt.Rows[0]["maxvaluedata"].ToString()) + 1;
                }

                var errMessage = string.Empty;
                var sb2 = new StringBuilder();
                sb2.Append($" INSERT INTO cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId} (UJIAN_PEGAWAI_DAFTAR_ID, LOWONGAN_ID, TIPE_UJIAN_ID, UJIAN_PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID, PEGAWAI_ID, TANGGAL, URUT, BANK_SOAL_ID, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID, LAST_CREATE_DATE, LAST_CREATE_USER) VALUES (");
                sb2.Append(" (  SELECT UJIAN_PEGAWAI_DAFTAR_ID");
                sb2.Append("    FROM cat_rekrutmen.ujian_pegawai_daftar");
                sb2.Append($"   WHERE UJIAN_ID = {answerModel.UjianId} AND PEGAWAI_ID = {answerModel.PegawaiId})");
                sb2.Append($", {lowongan_id}, (SELECT TIPE_UJIAN_ID FROM cat_rekrutmen.bank_soal WHERE BANK_SOAL_ID = {answerModel.BankSoalId})");
                sb2.Append($" , {ujian_pegawai_id}, {answerModel.UjianId}, {answerModel.UjianBankSoalId}, {answerModel.PegawaiId}, NOW(), {answerModel.Urut}, {answerModel.BankSoalId}, {answerModel.BankSoalPilihanId}, {answerModel.UjianTahapId}, NOW(), '')");
                var result = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery2(sb2.ToString(), "", null, ref errMessage);
                if (!result)
                {
                    return NotFound();
                }
            }
            else
            {
                var ujian_pegawai_id = Convert.ToInt32(dt.Rows[0]["ujian_pegawai_id"].ToString());

                var errMessage = string.Empty;
                var sb2 = new StringBuilder();
                sb2.Append($"DELETE FROM cat_rekrutmen_pegawai.ujian_pegawai_{answerModel.UjianId} WHERE UJIAN_PEGAWAI_ID = {ujian_pegawai_id}");
                var result = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery2(sb2.ToString(), "", null, ref errMessage);
                if (!result)
                {
                    return NotFound();
                }
            }

            var sb3 = new StringBuilder();
            sb3.Append(" SELECT");
            sb3.Append(" 			A.UJIAN_ID, B.UJIAN_BANK_SOAL_ID, B.BANK_SOAL_ID, C.KEMAMPUAN, C.KATEGORI, C.PERTANYAAN");
            sb3.Append(" 			, A.PEGAWAI_ID, A.STATUS_SETUJU, A.UJIAN_PEGAWAI_DAFTAR_ID");
            sb3.Append(" 			, C.TIPE_SOAL, C.PATH_GAMBAR, C.PATH_SOAL");
            sb3.Append(" 			, B.UJIAN_TAHAP_ID");
            sb3.Append(" 			, URUT, UP.BANK_SOAL_PILIHAN_ID, UP.UJIAN_PEGAWAI_ID");
            sb3.Append(" 			, CASE WHEN COALESCE(UPX.JUMLAH_DATA,0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
            sb3.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb3.Append(" INNER JOIN cat_rekrutmen.ujian_bank_soal B ON A.LOWONGAN_ID = B.LOWONGAN_ID AND A.UJIAN_ID = B.UJIAN_ID");
            sb3.Append(" INNER JOIN cat_rekrutmen.bank_soal C ON B.BANK_SOAL_ID = C.BANK_SOAL_ID");
            sb3.Append(" LEFT JOIN");
            sb3.Append(" 		(");
            sb3.Append(" SELECT");
            sb3.Append(" 			UJIAN_ID, UJIAN_BANK_SOAL_ID, UJIAN_PEGAWAI_DAFTAR_ID, UJIAN_PEGAWAI_ID, URUT, BANK_SOAL_PILIHAN_ID, UJIAN_TAHAP_ID");
            sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + answerModel.UjianId + " A");
            sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + answerModel.PegawaiId + " AND A.UJIAN_ID = " + answerModel.UjianId + " AND A.UJIAN_TAHAP_ID = " + answerModel.UjianTahapId);
            sb3.Append(" 		) UP ON B.UJIAN_BANK_SOAL_ID = UP.UJIAN_BANK_SOAL_ID");
            sb3.Append(" LEFT JOIN");
            sb3.Append(" 		(");
            sb3.Append(" SELECT COUNT(1) JUMLAH_DATA, PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
            sb3.Append(" FROM cat_rekrutmen_pegawai.ujian_pegawai_" + answerModel.UjianId);
            sb3.Append(" WHERE BANK_SOAL_PILIHAN_ID IS NOT NULL");
            sb3.Append(" GROUP BY PEGAWAI_ID, UJIAN_ID, UJIAN_BANK_SOAL_ID");
            sb3.Append(" 		) UPX ON UPX.PEGAWAI_ID = A.PEGAWAI_ID AND A.UJIAN_ID = UPX.UJIAN_ID AND UPX.UJIAN_BANK_SOAL_ID = B.UJIAN_BANK_SOAL_ID");
            sb3.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + answerModel.PegawaiId + " AND B.UJIAN_TAHAP_ID = " + answerModel.UjianTahapId + " AND A.UJIAN_ID = " + answerModel.UjianId);
            sb3.Append(" ORDER BY A.UJIAN_ID, B.BANK_SOAL_ID, UP.UJIAN_PEGAWAI_ID");

            var jawabans = new List<Jawaban>();

            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb3.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var nomer = 0;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    int Urut = 0;
                    Int32.TryParse(dt.Rows[i]["urut"].ToString(), out Urut);
                    int BankSoalPilihanId = 0;
                    Int32.TryParse(dt.Rows[i]["bank_soal_pilihan_id"].ToString(), out BankSoalPilihanId);
                    int UjianPegawaiId = 0;
                    Int32.TryParse(dt.Rows[i]["ujian_pegawai_id"].ToString(), out UjianPegawaiId);
                    int JumlahData = 0;
                    Int32.TryParse(dt.Rows[i]["jumlah_data"].ToString(), out JumlahData);

                    var jawaban = new Jawaban
                    {
                        Nomer = BankSoalPilihanId == 0 ? ++nomer : nomer,
                        UjianId = Convert.ToInt32(dt.Rows[i]["ujian_id"].ToString()),
                        UjianBankSoalId = Convert.ToInt32(dt.Rows[i]["ujian_bank_soal_id"].ToString()),
                        BankSoalId = Convert.ToInt32(dt.Rows[i]["bank_soal_id"].ToString()),
                        Pertanyaan = Convert.ToString(dt.Rows[i]["pertanyaan"].ToString()),
                        PegawaiId = Convert.ToInt32(dt.Rows[i]["pegawai_id"].ToString()),
                        UjianPegawaiDaftarId = Convert.ToInt32(dt.Rows[i]["ujian_pegawai_daftar_id"].ToString()),
                        TipeSoal = Convert.ToInt32(dt.Rows[i]["tipe_soal"].ToString()),
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        Urut = Urut,
                        BankSoalPilihanId = BankSoalPilihanId,
                        UjianPegawaiId = UjianPegawaiId,
                        JumlahData = JumlahData,
                    };
                    jawabans.Add(jawaban);
                }
            }

            //navigation
            Jawaban jawabanFind = null;
            var newNumber = answerModel.Nomer;
            if (answerModel.IsNext.HasValue)
            {
                if (answerModel.IsNext.Value) newNumber++;
                else newNumber--;
                jawabanFind = jawabans.FirstOrDefault(m => m.Nomer == newNumber);
            }
            if (jawabanFind == null)
            {
                //return RedirectToAction(nameof(TahapanTes));
                return RedirectToAction(nameof(ExamMulti), new { UjianTahapId = answerModel.UjianTahapId, Nomer = answerModel.Nomer });
            }
            else
            {
                return RedirectToAction(nameof(ExamMulti), new { UjianTahapId = jawabanFind.UjianTahapId, Nomer = jawabanFind.Nomer });
            }
        }

        [HttpGet(Name = "Finish")]
        public async Task<ActionResult> Finish(int UjianTahapId)
        {
            if (HttpContext.Session.Keys.Count() == 0) return Forbid();

            var finishModel = new FinishViewModel();
            var pegawai_id = HttpContext.Session.GetString("pelamar_id");
            var ujian_id = HttpContext.Session.GetString("ujian_id");
            var lowongan_id = HttpContext.Session.GetString("lowongan_id");
            var ujian_pegawai_daftar_id = HttpContext.Session.GetString("ujian_pegawai_daftar_id");

            var sb = new StringBuilder();
            sb.Append(" SELECT");
            sb.Append(" 	A.UJIAN_ID, A.UJIAN_PEGAWAI_DAFTAR_ID, B.UJIAN_TAHAP_ID");
            sb.Append(" 	, C.TIPE, D.TIPE_INFO");
            sb.Append(" 	, B.MENIT_SOAL, C.TIPE_UJIAN_ID, LENGTH(C.PARENT_ID) LENGTH_PARENT, C.PARENT_ID");
            sb.Append(" 	, (");
            sb.Append(" SELECT 1");
            sb.Append(" FROM cat_rekrutmen.UJIAN_TAHAP_STATUS_UJIAN X");
            sb.Append(" WHERE 1=1 AND X.UJIAN_ID = A.UJIAN_ID AND X.UJIAN_TAHAP_ID = B.UJIAN_TAHAP_ID AND X.PEGAWAI_ID = A.PEGAWAI_ID) TIPE_STATUS");
            sb.Append(" 	, CASE C.TIPE_UJIAN_ID WHEN 16 THEN 50 ELSE B.JUMLAH_SOAL END JUMLAH_SOAL");
            sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
            sb.Append(" INNER JOIN ");
            sb.Append(" (");
            sb.Append(" SELECT A.*, JUMLAH_SOAL");
            sb.Append(" FROM cat_rekrutmen.ujian_tahap A");
            sb.Append(" LEFT JOIN ");
            sb.Append(" 	(");
            sb.Append(" SELECT UJIAN_TAHAP_ID ROWID, COUNT(1) JUMLAH_SOAL");
            sb.Append(" FROM cat_rekrutmen.ujian_bank_soal");
            sb.Append(" GROUP BY UJIAN_TAHAP_ID");
            sb.Append(" 	) B ON UJIAN_TAHAP_ID = ROWID");
            sb.Append(" ) B ON A.UJIAN_ID = B.UJIAN_ID");
            sb.Append(" LEFT JOIN cat_rekrutmen.TIPE_UJIAN C ON B.TIPE_UJIAN_ID = C.TIPE_UJIAN_ID");
            sb.Append(" LEFT JOIN");
            sb.Append(" (");
            sb.Append(" SELECT");
            sb.Append(" 	A.ID ID_ROW, A.TIPE TIPE_INFO");
            sb.Append(" FROM cat_rekrutmen.TIPE_UJIAN A");
            sb.Append(" WHERE 1=1 AND PARENT_ID = '0'");
            sb.Append(" ) D ON C.PARENT_ID = D.ID_ROW");
            sb.Append(" WHERE 1=1 AND A.PEGAWAI_ID = " + pegawai_id + " AND A.UJIAN_ID = " + ujian_id + " AND B.UJIAN_TAHAP_ID = " + UjianTahapId);

            var dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var tipeStatus = 0;
                Int32.TryParse(dt.Rows[0]["tipe_status"].ToString(), out tipeStatus);
                finishModel.UjianId = Convert.ToInt32(dt.Rows[0]["ujian_id"].ToString());
                finishModel.UjianPegawaiDaftarId = Convert.ToInt32(dt.Rows[0]["ujian_pegawai_daftar_id"].ToString());
                finishModel.UjianTahapId = Convert.ToInt32(dt.Rows[0]["ujian_tahap_id"].ToString());
                finishModel.Tipe = dt.Rows[0]["tipe"].ToString();
                finishModel.TipeInfo = dt.Rows[0]["tipe_info"].ToString();
                finishModel.MenitSoal = Convert.ToInt32(dt.Rows[0]["menit_soal"].ToString());
                finishModel.TipeUjianId = Convert.ToInt32(dt.Rows[0]["tipe_ujian_id"].ToString());
                finishModel.LengthParent = Convert.ToInt32(dt.Rows[0]["length_parent"].ToString());
                finishModel.ParentId = Convert.ToInt32(dt.Rows[0]["parent_id"].ToString());
                finishModel.TipeStatus = tipeStatus;
                finishModel.JumlahSoal = Convert.ToInt32(dt.Rows[0]["jumlah_soal"].ToString());
            }

            var ujianTahapStatusUjianId = 1;
            var sb3 = new StringBuilder();
            sb3.Append("SELECT MAX(UJIAN_TAHAP_STATUS_UJIAN_ID) as maxvaluedata FROM cat_rekrutmen.ujian_tahap_status_ujian");
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb3.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                ujianTahapStatusUjianId = Convert.ToInt32(dt.Rows[0]["maxvaluedata"].ToString()) + 1;
            }

            string sql = "INSERT INTO cat_rekrutmen.ujian_tahap_status_ujian (" +
                "UJIAN_TAHAP_STATUS_UJIAN_ID, " +
                "UJIAN_PEGAWAI_DAFTAR_ID, " +
                "LOWONGAN_ID, " +
                "UJIAN_ID, " +
                "UJIAN_TAHAP_ID, " +
                "TIPE_UJIAN_ID, " +
                "PEGAWAI_ID, " +
                "STATUS, " +
                "LAST_CREATE_DATE, " +
                "LAST_CREATE_USER) " +
                $"VALUES({ujianTahapStatusUjianId}, " +
                $"{finishModel.UjianPegawaiDaftarId}, " +
                $"{lowongan_id}, " +
                $"{finishModel.UjianId}, " +
                $"{finishModel.UjianTahapId}, " +
                $"{finishModel.TipeUjianId}, " +
                $"{pegawai_id}, 1, NOW(), '')";

            string errMessage = string.Empty;
            var result = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery2(sql, "", null, ref errMessage);
            if (!result)
            {
                ModelState.AddModelError(string.Empty, "Error Insert.");
                return View(finishModel);
            }
            else
            {
                finishModel.TipeStatus = 1;
            }

            var sb2 = new StringBuilder();
            sb2.Append(" SELECT");
            sb2.Append(" 	A.URUT NOMOR, A.UJIAN_ID, A.BANK_SOAL_ID, A.UJIAN_TAHAP_ID, CASE WHEN COALESCE(SUM(CASE WHEN BANK_SOAL_PILIHAN_ID IS NULL THEN 0 ELSE 1 END),0) > 0 THEN 1 ELSE 0 END JUMLAH_DATA");
            sb2.Append($" FROM cat_rekrutmen_pegawai.ujian_pegawai_{ujian_id} A");
            sb2.Append(" WHERE 1=1 AND A.UJIAN_TAHAP_ID = " + UjianTahapId + " AND A.UJIAN_ID = " + ujian_id + " AND A.PEGAWAI_ID = " + pegawai_id);
            sb2.Append(" GROUP BY A.URUT, A.UJIAN_ID, A.BANK_SOAL_ID, A.UJIAN_TAHAP_ID");
            sb2.Append(" ORDER BY A.UJIAN_ID, A.BANK_SOAL_ID;");
            dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb2.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                var jawabans = new List<Jawaban>();
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var jawaban = new Jawaban
                    {
                        Nomer = Convert.ToInt32(dt.Rows[i]["nomor"].ToString()),
                        UjianId = Convert.ToInt32(dt.Rows[i]["ujian_id"].ToString()),
                        BankSoalId = Convert.ToInt32(dt.Rows[i]["bank_soal_id"].ToString()),
                        UjianTahapId = Convert.ToInt32(dt.Rows[i]["ujian_tahap_id"].ToString()),
                        JumlahData = Convert.ToInt32(dt.Rows[i]["jumlah_data"].ToString())
                    };
                    jawabans.Add(jawaban);
                }
                finishModel.Jawabans = jawabans;
            }

            return View(finishModel);
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