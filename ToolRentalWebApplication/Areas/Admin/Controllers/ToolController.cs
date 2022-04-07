using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToolRentalWebApplication.Data;
using ToolRentalWebApplication.Entities;
using ToolRentalWebApplication.Extentions;

namespace ToolRentalWebApplication.Areas.Admin.Models
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ToolController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToolController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Tool
        public async Task<IActionResult> Index(int categoryId)
        {

            List<Tool> list = await (from tool in _context.Tools
                                     where tool.CategoryId == categoryId
                                     select new Tool
                                     {
                                         Id = tool.Id,
                                         Title = tool.Title,
                                         Description = tool.Description,
                                         Status = tool.Status,
                                         PricePerHour = tool.PricePerHour,
                                         PricePerDay = tool.PricePerDay,
                                         ThumbnailImagePath = tool.ThumbnailImagePath,
                                         CategoryId = categoryId,
                                         BranchId = tool.BranchId
                                         
                                     }).ToListAsync();


            ViewBag.CategoryId = categoryId;
            var applicationDbContext = _context.Tools.Include(t => t.Branch).Include(t => t.Category);
            return View(list);
        }

        // GET: Admin/Tool/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools
                .Include(t => t.Branch)
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // GET: Admin/Tool/Create
        public async Task<IActionResult> Create(int categoryId)
        {
            List<Branch> branches = await _context.Branches.ToListAsync();
            Tool tool = new Tool
            {
                CategoryId = categoryId,
                Branches = branches.ConvertToSelectList(0)
        };
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "ThumbnailImagePath");
            return View(tool);
        }

        // POST: Admin/Tool/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Status,PricePerHour,PricePerDayMaxFiveDays,PricePerDayMaxTenDays,PricePerDayOverTenDays,ThumbnailImagePath,CategoryId,BranchId")] Tool tool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { categoryId = tool.CategoryId });
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName", tool.BranchId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "ThumbnailImagePath", tool.CategoryId);

            List<Branch> branches = await _context.Branches.ToListAsync();
            tool.Branches = branches.ConvertToSelectList(tool.BranchId);
            return View(tool);
        }

        // GET: Admin/Tool/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            List<Branch> branches = await _context.Branches.ToListAsync();
            var tool = await _context.Tools.FindAsync(id);
            if (tool == null)
            {
                return NotFound();
            }

            tool.Branches = branches.ConvertToSelectList(tool.BranchId);
            
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName", tool.BranchId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "ThumbnailImagePath", tool.CategoryId);
            
            
            return View(tool);
        }

        // POST: Admin/Tool/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,PricePerHour,PricePerDayMaxFiveDays,PricePerDayMaxTenDays,PricePerDayOverTenDays,ThumbnailImagePath,CategoryId,BranchId")] Tool tool)
        {
            if (id != tool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToolExists(tool.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new {categoryId = tool.CategoryId });
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "Id", "BranchName", tool.BranchId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "ThumbnailImagePath", tool.CategoryId);
            return View(tool);
        }

        // GET: Admin/Tool/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tool = await _context.Tools
                .Include(t => t.Branch)
                .Include(t => t.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tool == null)
            {
                return NotFound();
            }

            return View(tool);
        }

        // POST: Admin/Tool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tool = await _context.Tools.FindAsync(id);
            _context.Tools.Remove(tool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { categoryId = tool.CategoryId });
        }

        private bool ToolExists(int id)
        {
            return _context.Tools.Any(e => e.Id == id);
        }
    }
}
