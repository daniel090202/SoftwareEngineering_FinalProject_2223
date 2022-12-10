namespace WholesaleDistribution.Models
{
    public class BillDetail
    {
        public BillDetail() { }
        public BillDetail(int bill_Id, string product_Id, int quantity)
        {
            Bill_Id = bill_Id;
            Product_Id = product_Id;
            Quantity = quantity;
        }

        public int Bill_Id { get; set; }
        public string Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
