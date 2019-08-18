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
    public class AssessmentsController : Controller
    {
        [HttpGet("[controller]/{page?}", Name = "LandingPage")]
        //[HttpPost("[controller]/{page?}", Name = "LandingPage")]
        public ActionResult Index(string pages = "")
        {
            if (Request.Method == "GET")
            {
                if (TempData.ContainsKey("status"))
                {
                    var status = TempData["status"].ToString();
                    if (status == "start")
                    {
                        TempData["status"] = "start";
                        return LocalRedirect("~/Assessments/TahapanTes#start");
                    }
                    else
                    {
                        TempData["status"] = pages;
                        if (pages == string.Empty)
                        {
                            return View("DataPribadi");
                        }
                        else
                        {
                            return View(pages);
                        }
                    }
                }
                else
                {
                    TempData["status"] = pages;
                    if (pages == string.Empty)
                    {
                        return View("DataPribadi");
                    }
                    else
                    {
                        return View(pages);
                    }
                }
            }
            else
            {
                if (pages == string.Empty)
                {
                    return View("DataPribadi");
                }
                else
                {
                    return View(pages);
                }
            }
        }

        //[HttpGet("[controller]/[action]", Name = "TahapanTes")]
        //public ActionResult TahapanTes()
        //{
        //    if (!TempData.ContainsKey("status"))
        //    {
        //        return LocalRedirect("~/Assessments");
        //    }
        //    else
        //    {
        //        var status = TempData["status"].ToString();
        //        if(status != "Persiapan" && status != "start")
        //        {
        //            return LocalRedirect("~/Assessments");
        //        }
        //    }

        //    TempData["status"] = "start";
        //    return View();
        //}

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