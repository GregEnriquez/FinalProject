namespace FinalProject.Models
{
    public class AddInventoryViewModel
    {
        public string ItemName { get; set; }
        public int AmountSold { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateSold { get; set; }
        public string ItemType { get; set; }
    }
}
