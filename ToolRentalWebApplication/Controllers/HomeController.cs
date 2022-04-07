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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            CategoryDetailsModel categoryDetailsModel = new CategoryDetailsModel();
            var categories = await GetCategories();
            categoryDetailsModel.Categories = categories;
                     
            return View(categoryDetailsModel);
        }
        private async Task<List<Category>> GetCategories()
        {
            var getCategories = await (from category in _context.Categories
                                    join tool in _context.Tools
                                    on category.Id equals tool.CategoryId
                                    select new Category
                                    {
                                        Id = category.Id,
                                        Title = category.Title,
                                        ThumbnailImagePath = category.ThumbnailImagePath
                                    }).Distinct().ToListAsync();
            return getCategories;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
