using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            List<Inventory> items = new List<Inventory>();
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
