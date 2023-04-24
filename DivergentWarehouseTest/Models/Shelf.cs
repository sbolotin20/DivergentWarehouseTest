namespace DivergentWarehouseTest.Models
{
    public class Shelf
    {
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public Zone Zone { get; set; }
        public string Name { get; set; }
    }
}
