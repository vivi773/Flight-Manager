using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flight_Manager.Data;
using Flight_Manager.Models;

namespace Flight_Manager.Controllers
{
    public class ReservationDataModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationDataModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReservationDataModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservations.ToListAsync());
        }

        // GET: ReservationDataModels/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationDataModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }

            return View(reservationDataModel);
        }

        // GET: ReservationDataModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReservationDataModels/Create
        [HttpPost]
        public async Task<IActionResult> Create( ReservationDataModel reservationDataModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationDataModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationDataModel);
        }

        // GET: ReservationDataModels/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationDataModel = await _context.Reservations.FindAsync(id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }
            return View(reservationDataModel);
        }

        // POST: ReservationDataModels/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, ReservationDataModel reservationDataModel)
        {
            if (id != reservationDataModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationDataModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationDataModelExists(reservationDataModel.Id))
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
            return View(reservationDataModel);
        }

        // GET: ReservationDataModels/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservationDataModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservationDataModel == null)
            {
                return NotFound();
            }

            return View(reservationDataModel);
        }

        // POST: ReservationDataModels/Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservationDataModel = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservationDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationDataModelExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }
    }
}
