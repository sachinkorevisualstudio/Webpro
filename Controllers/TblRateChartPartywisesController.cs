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
    public class TblRateChartPartywisesController : Controller
    {
        private readonly AppDbContext _context;

        public TblRateChartPartywisesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TblRateChartPartywises
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblRateChartPartywises.ToListAsync());
        }

        // GET: TblRateChartPartywises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRateChartPartywise = await _context.TblRateChartPartywises
                .FirstOrDefaultAsync(m => m.Indexnum == id);
            if (tblRateChartPartywise == null)
            {
                return NotFound();
            }

            return View(tblRateChartPartywise);
        }

        // GET: TblRateChartPartywises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblRateChartPartywises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Indexnum,Partyname,RateGsb,RateWmm,Rate60mm,Rate40mm,Rate26mm,Rate20mm,Rate10mm,Rate8by6,RateMsand,RateDust,RateWsand,RateWpsand,RateStone,RateRoboSand,RateSander")] TblRateChartPartywise tblRateChartPartywise)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tblRateChartPartywise);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tblRateChartPartywise);
        //}
        // POST: TblDispatches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblRateChartPartywise ttblRateChartPartywise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ttblRateChartPartywise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ttblRateChartPartywise);
        }

        // GET: TblRateChartPartywises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRateChartPartywise = await _context.TblRateChartPartywises.FindAsync(id);
            if (tblRateChartPartywise == null)
            {
                return NotFound();
            }
            return View(tblRateChartPartywise);
        }

        // POST: TblRateChartPartywises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Indexnum,Partyname,RateGsb,RateWmm,Rate60mm,Rate40mm,Rate26mm,Rate20mm,Rate10mm,Rate8by6,RateMsand,RateDust,RateWsand,RateWpsand,RateStone,RateRoboSand,RateSander")] TblRateChartPartywise tblRateChartPartywise)
        {
            if (id != tblRateChartPartywise.Indexnum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRateChartPartywise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRateChartPartywiseExists(tblRateChartPartywise.Indexnum))
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
            return View(tblRateChartPartywise);
        }

        // GET: TblRateChartPartywises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRateChartPartywise = await _context.TblRateChartPartywises
                .FirstOrDefaultAsync(m => m.Indexnum == id);
            if (tblRateChartPartywise == null)
            {
                return NotFound();
            }

            return View(tblRateChartPartywise);
        }

        // POST: TblRateChartPartywises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRateChartPartywise = await _context.TblRateChartPartywises.FindAsync(id);
            if (tblRateChartPartywise != null)
            {
                _context.TblRateChartPartywises.Remove(tblRateChartPartywise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRateChartPartywiseExists(int id)
        {
            return _context.TblRateChartPartywises.Any(e => e.Indexnum == id);
        }
    }
}
