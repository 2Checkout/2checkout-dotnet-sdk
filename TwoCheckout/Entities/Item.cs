namespace TwoCheckout.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public bool IsDynamic { get; set; }
        public bool Tangible { get; set; }
        public string PurchaseType { get; set; }
        public CrossSell CrossSell { get; set; }
        public Price Price { get; set; }
        public Item(string name, string description, int quantity, bool isDynamic, bool tangible, string purchaseType, CrossSell crossSell, Price price)
        {
            this.Name = name;
            this.Description = description;
            this.Quantity = quantity;
            this.IsDynamic = isDynamic;
            this.Tangible = tangible;
            this.PurchaseType = purchaseType;
            this.CrossSell = crossSell;
            this.Price = price;
        }
    }
}
