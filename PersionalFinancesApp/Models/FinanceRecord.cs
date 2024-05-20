namespace PersionalFinancesApp.Models
{
    public class FinanceRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public string? UserId { get; set; }
    }
}
