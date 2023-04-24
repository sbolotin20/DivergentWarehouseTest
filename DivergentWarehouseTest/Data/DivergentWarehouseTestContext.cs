using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DivergentWarehouseTest.Models;

namespace DivergentWarehouseTest.Data
{
    public class DivergentWarehouseTestContext : DbContext
    {
        public DivergentWarehouseTestContext (DbContextOptions<DivergentWarehouseTestContext> options)
            : base(options)
        {
        }

        public DbSet<DivergentWarehouseTest.Models.Warehouse> Warehouse { get; set; } = default!;
        public DbSet<DivergentWarehouseTest.Models.Zone> Zone { get; set; } = default!;
        public DbSet<DivergentWarehouseTest.Models.Shelf> Shelf { get; set; } = default!;
    }
}
