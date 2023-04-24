using DivergentWarehouseTest.Data;
using DivergentWarehouseTest.Models;

namespace DivergentWarehouseTest.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly DivergentWarehouseTestContext _context;

        public WarehouseService(DivergentWarehouseTestContext context)
        {
            _context = context;
        }
        public async Task CreateWarehouse(Warehouse warehouse)
        {
            var zones = warehouse.Zones;
            foreach (var zone in zones)
            {
                foreach (var shelf in zone.Shelves)
                {
                    _context.Shelf.Add(shelf);
                }
                _context.Zone.Add(zone);
            }
            _context.Warehouse.Add(warehouse);
            await _context.SaveChangesAsync();
        }
    }
}
