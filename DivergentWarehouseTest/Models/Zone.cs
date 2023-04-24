namespace DivergentWarehouseTest.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public List<Shelf> Shelves { get; set; }
    }
}
