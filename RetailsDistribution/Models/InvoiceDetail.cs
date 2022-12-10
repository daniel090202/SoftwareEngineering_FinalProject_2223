namespace RetailsDistribution.Models
{
    public class InvoiceDetail
    {
        public InvoiceDetail() { }
        public InvoiceDetail(int invoice_Id, string product_Id, int quantity)
        {
            Invoice_Id = invoice_Id;
            Product_Id = product_Id;
            Quantity = quantity;
        }

        public int Invoice_Id { get; set; }
        public string Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
