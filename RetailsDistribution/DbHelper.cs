using Microsoft.EntityFrameworkCore;
using RetailsDistribution.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RetailsDistribution
{
    public class DbHelper : DbContext
    {
        public DbHelper(DbContextOptions<DbHelper> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InvoiceDetail>().HasKey(bd => new { bd.Product_Id, bd.Invoice_Id });
        }
    }
}
