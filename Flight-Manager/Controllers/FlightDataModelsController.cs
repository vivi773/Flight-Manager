using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flight_Manager.Data;
using Flight_Manager.Models;
using Microsoft.AspNetCore.Authorization;

namespace Flight_Manager.Controllers
{
    public class FlightDataModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FlightDataModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FlightDataModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Flights.ToListAsync());
        }

        // GET: FlightDataModels/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDataModel = await _context.Flights
                .FirstOrDefaultAsync(m => m.AirlineID == id);
            if (flightDataModel == null)
            {
                return NotFound();
            }

            return View(flightDataModel);
        }

        // GET: FlightDataModels/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightDataModels/Create
        [HttpPost]
        public async Task<IActionResult> Create( FlightDataModel flightDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightDataModel);
        }

        // GET: FlightDataModels/Edit
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDataModel = await _context.Flights.FindAsync(id);
            if (flightDataModel == null)
            {
                return NotFound();
            }
            return View(flightDataModel);
        }

        // POST: FlightDataModels/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, FlightDataModel flightDataModel)
        {
            if (id != flightDataModel.AirlineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightDataModelExists(flightDataModel.AirlineID))
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
            return View(flightDataModel);
        }

        // GET: FlightDataModels/Delete
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightDataModel = await _context.Flights
                .FirstOrDefaultAsync(m => m.AirlineID == id);
            if (flightDataModel == null)
            {
                return NotFound();
            }

            return View(flightDataModel);
        }

        // POST: FlightDataModels/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightDataModel = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(flightDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightDataModelExists(int id)
        {
            return _context.Flights.Any(e => e.AirlineID == id);
        }
    }
}
