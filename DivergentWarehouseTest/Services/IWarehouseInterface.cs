using DivergentWarehouseTest.Models;

namespace DivergentWarehouseTest.Services
{
    public interface IWarehouseService
    {
        Task CreateWarehouse(Warehouse warehouse);
    }
}
