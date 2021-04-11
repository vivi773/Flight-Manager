using Flight_Manager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Manager.Models;

namespace Flight_Manager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserDataModelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserDataModelController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userDataModel = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userDataModel == null)
            {
                return NotFound();
            }

            return View(userDataModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userDataModel = await _context.Flights.FindAsync(id);
            _context.Flights.Remove(userDataModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
