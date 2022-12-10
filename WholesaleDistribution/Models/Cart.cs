namespace WholesaleDistribution.Models
{
    public class Cart
    {
        public Cart() { }

        public Cart(string product_Id, int quantity)
        {
            Product_Id = product_Id;
            Quantity = quantity;
        }

        public string Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
