namespace WholesaleDistribution.Models
{
    public class Consignment
    {
        public Consignment() { }

        public Consignment(string consignment_Id, DateTime produced_Date, DateTime expired_Date, DateTime imported_Date)
        {
            Id = consignment_Id;
            Produced_Date = produced_Date;
            Expired_Date = expired_Date;
            Imported_Date = imported_Date;
        }

        public string Id { get; set; }
        public DateTime Produced_Date { get; set; }
        public DateTime Expired_Date { get; set; }
        public DateTime Imported_Date { get; set; }
    }
}
