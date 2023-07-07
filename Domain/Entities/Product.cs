namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            ProduceDate = DateTime.Now;
            IsAvailable = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public int ManufacturePhone { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufactureEmail { get; set; }
    }
}