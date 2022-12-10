using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Accountant
    {
        public Accountant() { }
        public Accountant(string id, string name, string email, string gender, string phone, string address)
        {
            Id = id;
            Name = name;
            Email = email;
            Gender = gender;
            Phone = phone;
            Address = address;
        }
    
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
