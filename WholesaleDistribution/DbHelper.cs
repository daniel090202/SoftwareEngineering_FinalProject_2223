using Microsoft.EntityFrameworkCore;
using WholesaleDistribution.Models;

namespace WholesaleDistribution
{
    public class DbHelper: DbContext
    {
        public DbHelper(DbContextOptions<DbHelper> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillDetail>().HasKey(bd => new { bd.Product_Id, bd.Bill_Id });
        }
    }
}
