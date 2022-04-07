using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToolRentalWebApplication.Data;
using ToolRentalWebApplication.Entities;

namespace ToolRentalWebApplication.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class RentalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee/Rental
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rentals.Include(r => r.Branch).Include(r => r.Customer).Include(r => r.Reservation).Include(r => r.Tool);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employee/Rental/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Branch)
                .Include(r => r.Customer)
                .Include(r => r.Reservation)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Employee/Rental/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id");
            ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Description");
            return View();
        }

        // POST: Employee/Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BranchId,ToolId,CustomerId,ReservationId")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName", rental.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", rental.CustomerId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", rental.ReservationId);
            ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Description", rental.ToolId);
            return View(rental);
        }

        // GET: Employee/Rental/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName", rental.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", rental.CustomerId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", rental.ReservationId);
            ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Description", rental.ToolId);
            return View(rental);
        }

        // POST: Employee/Rental/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BranchId,ToolId,CustomerId,ReservationId")] Rental rental)
        {
            if (id != rental.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.Id))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName", rental.BranchId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", rental.CustomerId);
            ViewData["ReservationId"] = new SelectList(_context.Reservations, "Id", "Id", rental.ReservationId);
            ViewData["ToolId"] = new SelectList(_context.Tools, "Id", "Description", rental.ToolId);
            return View(rental);
        }

        // GET: Employee/Rental/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.Branch)
                .Include(r => r.Customer)
                .Include(r => r.Reservation)
                .Include(r => r.Tool)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Employee/Rental/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _context.Rentals.Any(e => e.Id == id);
        }
    }
}
