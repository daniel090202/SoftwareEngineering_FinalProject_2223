using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement.Model
{
    public class Category
    {
        public Category()
        {
        }

        public Category(string categoryID, string targetConsumer, string gender, int age, string effectOn)
        {
            Id = categoryID;
            Consumer = targetConsumer;
            Gender = gender;
            Age = age;
            Effect = effectOn;
        }

        public string Id { get; set; }
        public string Consumer { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Effect { get; set; }
    }
}
