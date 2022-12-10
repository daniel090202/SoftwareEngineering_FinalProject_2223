using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Bill
    {
        public Bill() { }
        public Bill(string exported_Date, string checked_Date, double price, string payment, string status, string paid, string accountant_Id, int agency_Id)
        {
            Exported_Date = exported_Date;
            Checked_Date = checked_Date;
            Price = price;
            Payment = payment;
            Status = status;
            Paid = paid;
            Accountant_Id = accountant_Id;
            Agency_Id = agency_Id;
        }

        public int Id { get; set; }
        public string Exported_Date { get; set; }
        public string Checked_Date { get; set; }
        public double Price { get; set; }
        public string Payment { get; set; }
        public string Status { get; set; }
        public string Paid { get; set; }
        public string Accountant_Id { get; set; }
        public int Agency_Id { get; set; }
    }
}
