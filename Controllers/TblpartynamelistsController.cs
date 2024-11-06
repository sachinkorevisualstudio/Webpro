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
    public class TblpartynamelistsController : Controller
    {
        private readonly AppDbContext _context;

        public TblpartynamelistsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tblpartynamelists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tblpartynamelists.ToListAsync());
        }

        // GET: Tblpartynamelists/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblpartynamelist = await _context.Tblpartynamelists
                .FirstOrDefaultAsync(m => m.Partyname == id);
            if (tblpartynamelist == null)
            {
                return NotFound();
            }

            return View(tblpartynamelist);
        }

        // GET: Tblpartynamelists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tblpartynamelists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Partyname,GstCustomer,Transcharge,Discount")] Tblpartynamelist tblpartynamelist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblpartynamelist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblpartynamelist);
        }

        // GET: Tblpartynamelists/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblpartynamelist = await _context.Tblpartynamelists.FindAsync(id);
            if (tblpartynamelist == null)
            {
                return NotFound();
            }
            return View(tblpartynamelist);
        }

        // POST: Tblpartynamelists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Partyname,GstCustomer,Transcharge,Discount")] Tblpartynamelist tblpartynamelist)
        {
            if (id != tblpartynamelist.Partyname)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblpartynamelist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblpartynamelistExists(tblpartynamelist.Partyname))
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
            return View(tblpartynamelist);
        }

        // GET: Tblpartynamelists/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblpartynamelist = await _context.Tblpartynamelists
                .FirstOrDefaultAsync(m => m.Partyname == id);
            if (tblpartynamelist == null)
            {
                return NotFound();
            }

            return View(tblpartynamelist);
        }

        // POST: Tblpartynamelists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblpartynamelist = await _context.Tblpartynamelists.FindAsync(id);
            if (tblpartynamelist != null)
            {
                _context.Tblpartynamelists.Remove(tblpartynamelist);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblpartynamelistExists(string id)
        {
            return _context.Tblpartynamelists.Any(e => e.Partyname == id);
        }
    }
}
