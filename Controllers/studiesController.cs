using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using studentModules.Data;
using studentModules.Models;

namespace studentModules.Controllers
{
    public class studiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public studiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: studies
        public async Task<IActionResult> Index()
        {
            return View(await _context.study.ToListAsync());
        }

        // GET: studies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.study
                .FirstOrDefaultAsync(m => m.ModuleCode == id);
            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        // GET: studies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: studies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModuleCode,HoursSpecificModule,TodayDate")] study study)
        {
            if (ModelState.IsValid)
            {
                _context.Add(study);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(study);
        }

        // GET: studies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.study.FindAsync(id);
            if (study == null)
            {
                return NotFound();
            }
            return View(study);
        }

        // POST: studies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModuleCode,HoursSpecificModule,TodayDate")] study study)
        {
            if (id != study.ModuleCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(study);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!studyExists(study.ModuleCode))
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
            return View(study);
        }

        // GET: studies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var study = await _context.study
                .FirstOrDefaultAsync(m => m.ModuleCode == id);
            if (study == null)
            {
                return NotFound();
            }

            return View(study);
        }

        // POST: studies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var study = await _context.study.FindAsync(id);
            _context.study.Remove(study);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool studyExists(string id)
        {
            return _context.study.Any(e => e.ModuleCode == id);
        }
    }
}
