using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Manufacturer
    {
        public Manufacturer() { }
        public Manufacturer(string manufacturerID, string manufacturerName, string manufacturerEmail, string manufacturerNation, string manufacturerPhone, string manufacturerAddress)
        {
            Id = manufacturerID;
            Name = manufacturerName;
            Email = manufacturerEmail;
            Nation = manufacturerNation;
            Phone = manufacturerPhone;
            Address = manufacturerAddress;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Nation { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
