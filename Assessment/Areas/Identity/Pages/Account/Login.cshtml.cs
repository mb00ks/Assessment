using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Assessment.Models;
using Assessment.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Npgsql;
using GeneralClass;

namespace Assessment.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [DisplayName("UserName")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {

                var sb = new StringBuilder();
                var dt = new DataTable();

                sb.Append(" SELECT");
                sb.Append(" A.PEGAWAI_ID PELAMAR_ID, B.NIP_BARU, B.LOWONGAN_ID, B.UJIAN_ID");
                sb.Append(" , CAST(TANGGAL_TES || ' 00:00:01' AS TIMESTAMP WITHOUT TIME ZONE) PEGAWAI_TANGGAL_AWAL");
                sb.Append(" , CAST(TANGGAL_TES_SELESAI || ' 23:59:59' AS TIMESTAMP WITHOUT TIME ZONE) PEGAWAI_TANGGAL_AKHIR");
                sb.Append(" , B.UJIAN_PEGAWAI_DAFTAR_ID");
                sb.Append(" FROM cat_rekrutmen.user_app A");
                sb.Append(" INNER JOIN");
                sb.Append(" (");
                sb.Append(" SELECT ");
                sb.Append(" UJIAN_PEGAWAI_DAFTAR_ID, A.PEGAWAI_ID, C.NIP_BARU, A.LOWONGAN_ID, A.UJIAN_ID");
                sb.Append(" , TO_CHAR(TGL_MULAI, 'YYYY-MM-DD') TANGGAL_TES");
                sb.Append(" , TO_CHAR(TGL_SELESAI, 'YYYY-MM-DD') TANGGAL_TES_SELESAI");
                sb.Append(" FROM cat_rekrutmen.ujian_pegawai_daftar A");
                sb.Append(" INNER JOIN cat_rekrutmen.ujian B ON A.UJIAN_ID = B.UJIAN_ID");
                sb.Append(" INNER JOIN simpeg.pegawai C ON A.PEGAWAI_ID = C.PEGAWAI_ID");
                sb.Append(" WHERE 1=1");
                sb.Append(" AND CURRENT_DATE BETWEEN TO_DATE(TO_CHAR(TGL_MULAI, 'YYYY-MM-DD'), 'YYYY-MM-DD')");
                sb.Append(" AND TO_DATE(TO_CHAR(TGL_SELESAI, 'YYYY-MM-DD'), 'YYYY-MM-DD')");
                sb.Append(" ) B ON A.PEGAWAI_ID = B.PEGAWAI_ID");
                sb.Append(" WHERE 1=1");
                sb.Append(" AND USER_LOGIN='" + Input.Email + "' AND USER_PASS= md5('" + Input.Password + "')");

                dt = GeneralClass.POSTGREMYSQL.Instance.ExecuteQuery(sb.ToString());

                if (dt.Rows.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
                else
                {
                    HttpContext.Session.SetString("pelamar_id", dt.Rows[0]["pelamar_id"].ToString());
                    HttpContext.Session.SetString("nip_baru", dt.Rows[0]["nip_baru"].ToString());
                    HttpContext.Session.SetString("lowongan_id", dt.Rows[0]["lowongan_id"].ToString());
                    HttpContext.Session.SetString("ujian_id", dt.Rows[0]["ujian_id"].ToString());
                    HttpContext.Session.SetString("pegawai_tanggal_awal", dt.Rows[0]["pegawai_tanggal_awal"].ToString());
                    HttpContext.Session.SetString("pegawai_tanggal_akhir", dt.Rows[0]["pegawai_tanggal_akhir"].ToString());
                    HttpContext.Session.SetString("ujian_pegawai_daftar_id", dt.Rows[0]["ujian_pegawai_daftar_id"].ToString());
                    return RedirectToLocal("~/Assessments/DataPribadi");
                }

                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    HttpContext.Session.Clear();
                    foreach (var key in HttpContext.Session.Keys)
                    {
                        HttpContext.Session.Remove(key);
                    }

                    HttpContext.Session.SetInt32("NavigateId", 10);
                    HttpContext.Session.SetInt32("OrderId", 1);

                    _logger.LogInformation("User logged in.");
                    return RedirectToLocal(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                returnUrl = Url.Content("~/");
                return LocalRedirect(returnUrl);
            }
        }
    }
}
