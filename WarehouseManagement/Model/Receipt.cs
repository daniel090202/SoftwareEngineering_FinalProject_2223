using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Receipt
    {
        public Receipt() { }
        public Receipt(string createdDate, double summary, string warehouseAddress, string supplierID, string accountantID)
        {
            Created_Date = createdDate;
            Price = summary;
            Address = warehouseAddress;
            Supplier_Id = supplierID;
            Accountant_Id = accountantID;
        }

        public int Id { get; set; }
        public string Created_Date { get; set; }
        public double Price { get; set; }
        public string Address { get; set; }
        public string Supplier_Id { get; set; }
        public string Accountant_Id { get; set; }
    }
}
