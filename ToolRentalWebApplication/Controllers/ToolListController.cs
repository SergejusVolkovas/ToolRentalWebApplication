using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToolRentalWebApplication.Models;
using ToolRentalWebApplication.Data;
using ToolRentalWebApplication.Entities;

namespace ToolRentalWebApplication.Controllers
{
    public class ToolListController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ToolListController(ILogger<HomeController> logger, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id)
        {
            //IEnumerable<ToolDetailsModel> toolDetailsModels = null;
            var toolDetailsModels = await GetToolDetails(id);
            ViewBag.CategoryId = id;

            return View(toolDetailsModels);
        }
            private async Task<IEnumerable<ToolDetailsModel>> GetToolDetails(int id)
            {
            return await (from tool in _context.Tools
                          join category in _context.Categories
                          on tool.CategoryId equals category.Id
                          join branch in _context.Branches
                          on tool.BranchId equals branch.Id
                          where tool.CategoryId == id 
                          select new ToolDetailsModel
                          {
                              CategoryId = id,
                              CategoryTitle = category.Title,
                              ToolTitle = tool.Title,
                              ToolId = tool.Id,
                              ToolDescription = tool.Description,
                              ThumbnailImagePath = tool.ThumbnailImagePath,
                              PricePerDay = tool.PricePerDay,
                              PricePerHour = tool.PricePerHour,
                              BranchName = branch.BranchName,
                             
                          }).ToListAsync();  
            }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
