using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement.Model;

namespace WarehouseManagement
{
    public class DbHelper: DbContext
    {
        public DbHelper() : base("name=myDatabaseConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DbHelper>());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Consignment> Consignments { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReceiptDetail>().HasKey(rd => new { rd.Product_Id, rd.Receipt_Id});
            modelBuilder.Entity<BillDetail>().HasKey(bd => new { bd.Product_Id, bd.Bill_Id });
        }
    }
}
