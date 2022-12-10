using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Supplier
    {
        public Supplier(string supplierID, string supplierName, string supplierAddress, string supplierPhone, string supplierEmail)
        {
            Id = supplierID;
            Name = supplierName;
            Address = supplierAddress;
            Phone = supplierPhone;
            Email = supplierEmail;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
