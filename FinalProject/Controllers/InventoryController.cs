using FinalProject.Models.Entities;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        //Creates dbContext
        public InventoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Goes to Create Page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //Adds form items to inventory once in create page
        [HttpPost]
        public async Task<IActionResult> Create(AddInventoryViewModel viewModel)
        {
            var inventory = new Inventory
            {
                ItemName = viewModel.ItemName,
                AmountSold = viewModel.AmountSold,
                TotalPrice = viewModel.TotalPrice,
                DateSold = viewModel.DateSold,
                ItemType = viewModel.ItemType
            };

            await dbContext.Inventory.AddAsync(inventory);
            await dbContext.SaveChangesAsync();

            return View();
        }

        //Shows database in page
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var inventory = await dbContext.Inventory.ToListAsync();
            
            return View(inventory);
        }
    }
}