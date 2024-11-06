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
    public class OpeningbalancesController : Controller
    {
        private readonly AppDbContext _context;

        public OpeningbalancesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Openingbalances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Openingbalances.ToListAsync());
        }

        // GET: Openingbalances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingbalance = await _context.Openingbalances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (openingbalance == null)
            {
                return NotFound();
            }

            return View(openingbalance);
        }

        // GET: Openingbalances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Openingbalances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datex,Partyname,Openingbal")] Openingbalance openingbalance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(openingbalance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openingbalance);
        }

        // GET: Openingbalances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingbalance = await _context.Openingbalances.FindAsync(id);
            if (openingbalance == null)
            {
                return NotFound();
            }
            return View(openingbalance);
        }

        // POST: Openingbalances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datex,Partyname,Openingbal")] Openingbalance openingbalance)
        {
            if (id != openingbalance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(openingbalance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpeningbalanceExists(openingbalance.Id))
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
            return View(openingbalance);
        }

        // GET: Openingbalances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var openingbalance = await _context.Openingbalances
                .FirstOrDefaultAsync(m => m.Id == id);
            if (openingbalance == null)
            {
                return NotFound();
            }

            return View(openingbalance);
        }

        // POST: Openingbalances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var openingbalance = await _context.Openingbalances.FindAsync(id);
            if (openingbalance != null)
            {
                _context.Openingbalances.Remove(openingbalance);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpeningbalanceExists(int id)
        {
            return _context.Openingbalances.Any(e => e.Id == id);
        }
    }
}
