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
    public class TblVehicleNumbersController : Controller
    {
        private readonly AppDbContext _context;

        public TblVehicleNumbersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TblVehicleNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblVehicleNumbers.ToListAsync());
        }

        // GET: TblVehicleNumbers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicleNumber = await _context.TblVehicleNumbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblVehicleNumber == null)
            {
                return NotFound();
            }

            return View(tblVehicleNumber);
        }

        // GET: TblVehicleNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblVehicleNumbers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyVehicleNumber,DriverNameOptional,WeightCapacity")] TblVehicleNumber tblVehicleNumber)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblVehicleNumber);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblVehicleNumber);
        }

        // GET: TblVehicleNumbers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicleNumber = await _context.TblVehicleNumbers.FindAsync(id);
            if (tblVehicleNumber == null)
            {
                return NotFound();
            }
            return View(tblVehicleNumber);
        }

        // POST: TblVehicleNumbers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyVehicleNumber,DriverNameOptional,WeightCapacity")] TblVehicleNumber tblVehicleNumber)
        {
            if (id != tblVehicleNumber.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblVehicleNumber);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblVehicleNumberExists(tblVehicleNumber.Id))
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
            return View(tblVehicleNumber);
        }

        // GET: TblVehicleNumbers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblVehicleNumber = await _context.TblVehicleNumbers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblVehicleNumber == null)
            {
                return NotFound();
            }

            return View(tblVehicleNumber);
        }

        // POST: TblVehicleNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblVehicleNumber = await _context.TblVehicleNumbers.FindAsync(id);
            if (tblVehicleNumber != null)
            {
                _context.TblVehicleNumbers.Remove(tblVehicleNumber);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblVehicleNumberExists(int id)
        {
            return _context.TblVehicleNumbers.Any(e => e.Id == id);
        }
    }
}
