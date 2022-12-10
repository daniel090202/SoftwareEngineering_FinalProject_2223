using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Product
    {
        public Product() { }

        public Product(string id, string name, double price, double tax, int quantity_theory, int quantity_real, string unit, int sold, string manufacturer_Id, string category_Id, string consignment_Id)
        {
            Id = id;
            Name = name;
            Price = price;
            Tax = tax;
            Quantity_Theory = quantity_theory;
            Quantity_Real = quantity_real;
            Unit = unit;
            Sold = sold;
            Manufacturer_Id = manufacturer_Id;
            Category_Id = category_Id;
            Consignment_Id = consignment_Id;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }
        public int Quantity_Theory { get; set; }
        public int Quantity_Real { get; set; }
        public string Unit { get; set; }
        public int Sold { get; set; }
        public string Manufacturer_Id { get; set; }
        public string Category_Id { get; set; }
        public string Consignment_Id { get; set; }
    }
}
