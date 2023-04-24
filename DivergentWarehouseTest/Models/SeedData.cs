using DivergentWarehouseTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DivergentWarehouseTest.Data;
using System;
using System.Linq;
using DivergentWarehouseTest.Models;

namespace DivergentWarehouseTest.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DivergentWarehouseTestContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DivergentWarehouseTestContext>>()))
        {
            // Look for any movies.
            if (context.Warehouse.Any())
            {
                return;   // DB has been seeded
            }
            
            context.SaveChanges();
        }
    }
}