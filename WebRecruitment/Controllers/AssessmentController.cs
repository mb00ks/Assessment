using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebRecruitment.Controllers
{
    [Authorize(Roles = "Peserta")]
    public class AssessmentController : Controller
    {
        [HttpGet("[controller]/{page?}", Name = "LandingPage")]
        [HttpPost("[controller]/{page?}", Name = "LandingPage")]
        public ActionResult Index(string pages)
        {
            if (Request.Method == "GET")
            {
                return View("DataPribadi");
            }
            else
            {
                if (pages == null)
                {
                    return View("DataPribadi");
                }
                else
                {
                    return View(pages);
                }
            }
        }

        [HttpPost("", Name = "Ujian")]
        public ActionResult Ujian()
        {
            return Content("this is ujian");
        }

        // GET: Assessment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Assessment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assessment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Assessment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assessment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Assessment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assessment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}