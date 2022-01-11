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
    public class modulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public modulesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: modules
        public async Task<IActionResult> Index()
        {
            return View(await _context.modules.ToListAsync());
        }

        // GET: modules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modules = await _context.modules
                .FirstOrDefaultAsync(m => m.ModuleCode == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // GET: modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
 
        
        
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModuleCode,Module,NumberOfCredits,ClassHoursPerWeek,NumberOfWeeks,StartDate,SelfStudyHoursPerWeek,SelfstudyRemainsweek")] modules modules)
        {
            
            if (ModelState.IsValid)
            {
                modules student = new modules
                {
                    NumberOfCredits = modules.NumberOfCredits,
                    ClassHoursPerWeek = modules.ClassHoursPerWeek,
                    NumberOfWeeks = modules.NumberOfWeeks,
                    SelfStudyHoursPerWeek = (modules.NumberOfCredits * 10) / modules.NumberOfWeeks - modules.ClassHoursPerWeek


                };

               

                _context.Add(modules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modules);
        }


        // GET: modules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modules = await _context.modules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }
            return View(modules);
        }

        // POST: modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModuleCode,Module,NumberOfCredits,ClassHoursPerWeek,NumberOfWeeks,StartDate,SelfStudyHoursPerWeek,SelfstudyRemainsweek")] modules modules)
        {
            if (id != modules.ModuleCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!modulesExists(modules.ModuleCode))
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
            return View(modules);
        }

        // GET: modules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modules = await _context.modules
                .FirstOrDefaultAsync(m => m.ModuleCode == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // POST: modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var modules = await _context.modules.FindAsync(id);
            _context.modules.Remove(modules);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool modulesExists(string id)
        {
            return _context.modules.Any(e => e.ModuleCode == id);
        }
    }
}
