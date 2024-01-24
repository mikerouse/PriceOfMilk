namespace PriceOfMilk.Models
{
    public class MilkType
    {
        public long Id { get; set; }
        public string? Name { get; set; }
    }
    public class Milk
    {
        public long Id { get; set; }
        public MilkType? Type { get; set; }
        public string? Supermarket { get; set; }
        public DateTime Date { get; set; }
        public decimal PricePerLitre { get; set; }
        public decimal PricePerPint { get; set; }
    }
}
