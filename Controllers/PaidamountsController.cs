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
    public class PaidamountsController : Controller
    {
        private readonly AppDbContext _context;

        public PaidamountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Paidamounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paidamounts.ToListAsync());
        }

        // GET: Paidamounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paidamount = await _context.Paidamounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paidamount == null)
            {
                return NotFound();
            }

            return View(paidamount);
        }

        // GET: Paidamounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paidamounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datex,Partyname,Paid,Otherdetail")] Paidamount paidamount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paidamount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paidamount);
        }

        // GET: Paidamounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paidamount = await _context.Paidamounts.FindAsync(id);
            if (paidamount == null)
            {
                return NotFound();
            }
            return View(paidamount);
        }

        // POST: Paidamounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datex,Partyname,Paid,Otherdetail")] Paidamount paidamount)
        {
            if (id != paidamount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paidamount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaidamountExists(paidamount.Id))
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
            return View(paidamount);
        }

        // GET: Paidamounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paidamount = await _context.Paidamounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paidamount == null)
            {
                return NotFound();
            }

            return View(paidamount);
        }

        // POST: Paidamounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paidamount = await _context.Paidamounts.FindAsync(id);
            if (paidamount != null)
            {
                _context.Paidamounts.Remove(paidamount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaidamountExists(int id)
        {
            return _context.Paidamounts.Any(e => e.Id == id);
        }
    }
}
