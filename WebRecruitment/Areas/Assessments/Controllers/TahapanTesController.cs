using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebRecruitment.Areas.Assessments.Controllers
{
    [Area("Assessments")]
    public class TahapanTesController : Controller
    {
        // GET: TahapanTes
        public ActionResult Index()
        {
            if (!TempData.ContainsKey("status"))
            {
                return LocalRedirect("~/Assessments");
            }
            else
            {
                var status = TempData["status"].ToString();
                if (status != "Persiapan" && status != "start")
                {
                    return LocalRedirect("~/Assessments");
                }
            }

            TempData["status"] = "start";
            return View();
        }

        public ActionResult Tahap1(int? soal)
        {
            if (soal == null)
            {
                return View();
            }
            else
            {
                return View($"Soal{soal}");
            }
        }

        // GET: TahapanTes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TahapanTes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TahapanTes/Create
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

        // GET: TahapanTes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TahapanTes/Edit/5
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

        // GET: TahapanTes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TahapanTes/Delete/5
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