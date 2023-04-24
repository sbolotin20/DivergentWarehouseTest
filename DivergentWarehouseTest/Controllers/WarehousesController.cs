using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DivergentWarehouseTest.Data;
using DivergentWarehouseTest.Models;
using Newtonsoft.Json;
using DivergentWarehouseTest.Services;

namespace DivergentWarehouseTest.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly DivergentWarehouseTestContext _context;
        private readonly IWarehouseService _warehouseService;

        public WarehousesController(DivergentWarehouseTestContext context, IWarehouseService warehouseService)
        {
            _context = context;
            _warehouseService = warehouseService;
        }

        // GET: Warehouses
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CreateWarehouse(string warehouseString)
        {
            var foo = "bar";
            var warehouse = JsonConvert.DeserializeObject<Warehouse>(warehouseString);
            foreach (var zone in warehouse.Zones)
            {
                if (!EnsureUniqueShelfNames(zone.Shelves.Select(s => s.Name).ToList())) 
                    return Json(new {success = false, message = $"Shelf Names are not unique for zone {zone.Id}"});
            }
            await _warehouseService.CreateWarehouse(warehouse);
            return Json(new {success = true});
        }

        public static bool EnsureUniqueShelfNames(List<string> shelfNames)
        {
            var seen = new List<string>();
            foreach (var name in shelfNames)
            {
                if (seen.Contains(name)) return false;
                seen.Add(name);
            }
            return true;
        }
    }
}
