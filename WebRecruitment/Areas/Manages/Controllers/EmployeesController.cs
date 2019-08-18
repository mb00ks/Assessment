using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRecruitment.Data;
using WebRecruitment.Models;

namespace WebRecruitment.Areas.Manages.Controllers
{
    [Area("Manages")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manages/Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employees.Include(e => e.ApplicationUser).Include(e => e.Gender).Include(e => e.MaritalStatus).Include(e => e.Religion);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manages/Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.Gender)
                .Include(e => e.MaritalStatus)
                .Include(e => e.Religion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Manages/Employees/Create
        public IActionResult Create()
        {
            ViewData["UserForeignKey"] = new SelectList(_context.ApplicationUsers, "Id", "Email");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name");
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Name");
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Name");
            return View();
        }

        // POST: Manages/Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserForeignKey,GenderId,ReligionId,MaritalStatusId,IdentityNumber,Name,BirthDate,BirthDatePlace,Address")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserForeignKey"] = new SelectList(_context.ApplicationUsers, "Id", "Email", employee.UserForeignKey);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", employee.GenderId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Name", employee.MaritalStatusId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Name", employee.ReligionId);
            return View(employee);
        }

        // GET: Manages/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["UserForeignKey"] = new SelectList(_context.ApplicationUsers, "Id", "Email", employee.UserForeignKey);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", employee.GenderId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Name", employee.MaritalStatusId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Name", employee.ReligionId);
            return View(employee);
        }

        // POST: Manages/Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserForeignKey,GenderId,ReligionId,MaritalStatusId,IdentityNumber,Name,BirthDate,BirthDatePlace,Address")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserForeignKey"] = new SelectList(_context.ApplicationUsers, "Id", "Email", employee.UserForeignKey);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "Name", employee.GenderId);
            ViewData["MaritalStatusId"] = new SelectList(_context.MaritalStatuses, "Id", "Name", employee.MaritalStatusId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "Name", employee.ReligionId);
            return View(employee);
        }

        // GET: Manages/Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.Gender)
                .Include(e => e.MaritalStatus)
                .Include(e => e.Religion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Manages/Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
