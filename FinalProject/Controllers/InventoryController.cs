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

            return RedirectToAction("Index");
        }

        //Shows database in page
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var inventory = await dbContext.Inventory.ToListAsync();
            
            return View(inventory);
        }

        //Gets the item with the specific Id and puts them to the Edit page
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var inventory = await dbContext.Inventory.FindAsync(Id);

            return View(inventory);
        }

        //Edits the database with the changes made to the form and shows it in Index
        [HttpPost]
        public async Task<IActionResult> Edit(Inventory viewModel)
        {
            var inventory = await dbContext.Inventory.FindAsync(viewModel.Id);

            if (inventory is not null)
            {
                inventory.ItemName = viewModel.ItemName;
                inventory.AmountSold = viewModel.AmountSold;
                inventory.TotalPrice = viewModel.TotalPrice;
                inventory.DateSold = viewModel.DateSold;
                inventory.ItemType = viewModel.ItemType;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        //Deletes an item with the found Id from the database
        [HttpPost]
        public async Task<IActionResult> Delete(Inventory viewModel)
        {
            var inventory = await dbContext.Inventory.AsNoTracking().FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (inventory is not null)
            {
                dbContext.Inventory.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}