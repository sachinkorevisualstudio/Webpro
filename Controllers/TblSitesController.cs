using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webpro.Data;
using Webpro.Models;

namespace Webpro.Controllers
{
    public class TblSitesController : Controller
    {
        private readonly AppDbContext _context;

        public TblSitesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TblSites
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblSites.ToListAsync());
        }

        // GET: TblSites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSite = await _context.TblSites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSite == null)
            {
                return NotFound();
            }

            return View(tblSite);
        }

        // GET: TblSites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblSites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Site")] TblSite tblSite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblSite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblSite);
        }

        // GET: TblSites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSite = await _context.TblSites.FindAsync(id);
            if (tblSite == null)
            {
                return NotFound();
            }
            return View(tblSite);
        }

        // POST: TblSites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Site")] TblSite tblSite)
        {
            if (id != tblSite.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblSite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblSiteExists(tblSite.Id))
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
            return View(tblSite);
        }

        // GET: TblSites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblSite = await _context.TblSites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblSite == null)
            {
                return NotFound();
            }

            return View(tblSite);
        }

        // POST: TblSites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblSite = await _context.TblSites.FindAsync(id);
            if (tblSite != null)
            {
                _context.TblSites.Remove(tblSite);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblSiteExists(int id)
        {
            return _context.TblSites.Any(e => e.Id == id);
        }
    }
}
