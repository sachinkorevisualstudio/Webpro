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
    public class TblDispatchesControllerX : Controller
    {
        private readonly AppDbContext _context;

        public TblDispatchesControllerX(AppDbContext context)
        {
            _context = context;
        }

        //// GET: TblDispatches
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TblDispatches.ToListAsync());
        //}
        // GET: TblDispatches
        public async Task<IActionResult> Index()
        {
            // Equivalent of SELECT * FROM TblDispatches ORDER BY Id DESC LIMIT 60
            var last60Records = await _context.TblDispatches
                                              .OrderByDescending(d => d.Id) // Order by Id in descending order
                                              .Take(60) // Limit to 60 records
                                              .ToListAsync();

            return View(last60Records);
        }

        //public async Task<IActionResult> Index()
        //{
        //    var last60Records = await _context.TblDispatches
        //                                      .FromSqlRaw("SELECT TOP 60 * FROM TblDispatches ORDER BY Id DESC")
        //                                      .ToListAsync();

        //    return View(last60Records);
        //}
        // GET: TblDispatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDispatch = await _context.TblDispatches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDispatch == null)
            {
                return NotFound();
            }

            return View(tblDispatch);
        }

        // GET: TblDispatches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblDispatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Chalanno,RegOrStock,Datex,Timex,Monthnamex,Yearnamex,Partyname,Txtpartynamesearched,Site,Vehicleno,Drivername,Supervisorname,Material,Trip,Ton,Qty,RateFromchart,TransportCharge,RateApplied,Amount1,Gstcustomer,GstAmount,TotalAmountBill,Discountpercent,Royalty,Payablebillwithdiscount,CashPaymentRs,OnlinePaymentRs,Summary,JamaAmt,Monthnumber,DataEntryDatetime")] TblDispatch tblDispatch)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tblDispatch);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tblDispatch);
        //}

        // POST: TblDispatches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblDispatch tblDispatch)
        {
            if (ModelState.IsValid)
            {
                // Set the current date and time for the DataEntryDatetime field
                tblDispatch.DataEntryDatetime = DateTime.Now;


                _context.Add(tblDispatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblDispatch);
        }


        // GET: TblDispatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDispatch = await _context.TblDispatches.FindAsync(id);
            if (tblDispatch == null)
            {
                return NotFound();
            }
            return View(tblDispatch);
        }

        // POST: TblDispatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Chalanno,RegOrStock,Datex,Timex,Monthnamex,Yearnamex,Partyname,Txtpartynamesearched,Site,Vehicleno,Drivername,Supervisorname,Material,Trip,Ton,Qty,RateFromchart,TransportCharge,RateApplied,Amount1,Gstcustomer,GstAmount,TotalAmountBill,Discountpercent,Royalty,Payablebillwithdiscount,CashPaymentRs,OnlinePaymentRs,Summary,JamaAmt,Monthnumber,DataEntryDatetime")] TblDispatch tblDispatch)
        {
            if (id != tblDispatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblDispatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblDispatchExists(tblDispatch.Id))
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
            return View(tblDispatch);
        }

        // GET: TblDispatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblDispatch = await _context.TblDispatches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblDispatch == null)
            {
                return NotFound();
            }

            return View(tblDispatch);
        }

        // POST: TblDispatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblDispatch = await _context.TblDispatches.FindAsync(id);
            if (tblDispatch != null)
            {
                _context.TblDispatches.Remove(tblDispatch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblDispatchExists(int id)
        {
            return _context.TblDispatches.Any(e => e.Id == id);
        }





        // GET: TblDispatches/GetDispatchByChalanno  right section
        [HttpGet]
        public async Task<JsonResult> GetDispatchByChalanno(string chalanno)
        {
            if (string.IsNullOrEmpty(chalanno))
            {
                return Json(new List<TblDispatch>());
            }

            var results = await _context.TblDispatches
                .Where(d => d.Chalanno == chalanno)
                .Select(d => new
                {
                    d.Id,
                    d.Datex,
                    d.Chalanno,
                    d.Partyname,
                    d.Site,
                    d.Material,
                    d.RateFromchart,
                    d.TransportCharge
                })
                .ToListAsync();

            return Json(results);
        }





        [HttpGet]
        public async Task<JsonResult> CheckVehicleNumber(string input)
        {
            Console.WriteLine($"Input received in CheckVehicleNumber: {input}");

            // Ensure the input is at least 4 characters
            if (string.IsNullOrEmpty(input) || input.Length < 4)
            {
                return Json(new { result = "notfound" });
            }

            // Extract the last 4 digits from the input
            var lastFourDigits = input.Trim().Substring(input.Length - 4);
            Console.WriteLine($"Last four digits extracted: {lastFourDigits}");

            // Search for vehicle numbers in the TblVehicleNumber that end with the last 4 digits
            var vehicle = await _context.TblVehicleNumbers
                .Where(v => v.CompanyVehicleNumber.Trim().EndsWith(lastFourDigits))  // Match by last 4 digits
                .Select(v => new { v.DriverNameOptional })  // Select the driver's name if found
                .FirstOrDefaultAsync();

            if (vehicle != null)
            {
                // If found, return the result with the driver's name
                return Json(new { result = "yesfound", driver = vehicle.DriverNameOptional });
            }

            // If not found, return a not found result
            return Json(new { result = "notfound" });
        }





        //   partyname list 
        [HttpGet]
        public async Task<IActionResult> GetPartyNames()
        {
            var partyNames = await _context.Tblpartynamelists
                .Select(p => new { p.Partyname })
                .ToListAsync();

            return Json(partyNames);
        }


        //
        // yes no discount gstcust transport charge

        // GET: /TblDispatches/GetPartyDetails
        [HttpGet]
        public IActionResult GetPartyDetails(string partyname)
        {
            if (string.IsNullOrEmpty(partyname))
            {
                return BadRequest("Party name is required.");
            }

            // Find the party details by partyname
            var partyDetails = _context.Tblpartynamelists
                .Where(p => p.Partyname == partyname)
                .Select(p => new
                {
                    gstCustomer = p.GstCustomer,
                    transcharge = p.Transcharge,
                    discount = p.Discount
                })
                .FirstOrDefault();

            if (partyDetails == null)
            {
                return NotFound("Party details not found.");
            }

            // Return the details as a JSON response
            return Json(partyDetails);
        }



        //



        //   site name list   need separate table for site in future
        [HttpGet]
        public async Task<IActionResult> GetSiteNames()
        {
            var siteNames = await _context.TblDispatches
                .Where(p => p.Site != null)  // Ensure non-null values
                .Select(p => p.Site)         // Directly select the Site property
                .Distinct()                  // Ensure distinct site names
                .ToListAsync();

            return Json(siteNames);
        }

        /////////////////-----ratechart


        [HttpPost]
        public IActionResult GetRate(RateChartViewModel model)
        {
            if (string.IsNullOrEmpty(model.Partyname) || string.IsNullOrEmpty(model.Material))
            {
                return BadRequest("Partyname and material must be provided.");
            }

            // Attempt to find the specified party
            var party = _context.TblRateChartPartywises
                .FirstOrDefault(p => p.Partyname.ToUpper() == model.Partyname.ToUpper());

            // If the party is not found, look for 'ROKH_GENERAL'
            if (party == null)
            {
                party = _context.TblRateChartPartywises
                    .FirstOrDefault(p => p.Partyname.ToUpper() == "ROKH_GENERAL");

                // If ROKH_GENERAL is not found, return an error
                if (party == null)
                {
                    return NotFound("Party not found.");
                }

                // Set the party name to 'ROKH_GENERAL' for the response
                model.Partyname = "ROKH_GENERAL";
            }

            // Map material to the corresponding rate column
            double? rate = model.Material switch
            {
                "GSB" => party.RateGsb,
                "WMM" => party.RateWmm,
                "60MM" => party.Rate60mm,
                "40MM" => party.Rate40mm,
                "26MM" => party.Rate26mm,
                "20MM" => party.Rate20mm,
                "10MM" => party.Rate10mm,
                "8/6MM" => party.Rate8by6,
                "MSAND" => party.RateMsand,
                "DUST" => party.RateDust,
                "Washable_sand" => party.RateWsand,
                "Washable_plaster_sand" => party.RateWpsand,
                "Stone" => party.RateStone,
                "robo_sand" => party.RateRoboSand,
                "sander" => party.RateSander,
                _ => null
            };

            model.RateFromChart = rate;

            // Return the rate and the party name in JSON format for the AJAX call to use
            return Json(new
            {
                rateFromChart = model.RateFromChart,
                partyNameSearched = model.Partyname // Populate the searched party name
            });
        }







        //
    }
}
