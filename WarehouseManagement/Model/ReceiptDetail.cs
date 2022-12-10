using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class ReceiptDetail { 
        public ReceiptDetail() { }
        public ReceiptDetail(int receiptID, string productId, int quantity_Real)
        {
            Receipt_Id = receiptID;
            Product_Id = productId;
            Quantity = quantity_Real;
        }

        public int Receipt_Id { get; set; } 
        public string Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}
