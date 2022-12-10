using WarehouseManagement.Model;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ProductInputValue1()
        {
            ///the real amount of imported products exceed the amount of theory product
            Product product = new Product("P00H00045", "Healthty eyes", 120, 12, 12, 15, "Jar", 0, "M00H00045", "C0001", "CH000045");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ProductInputValue2()
        {
            ///the tax of imported products does not exceed ten percent of the real price
            Product product = new Product("P00H00045", "Healthty eyes", 120, 50, 12, 12, "Jar", 0, "M00H00045", "C0001", "CH000045");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ProductInputValue3()
        {
            ///the real price of imported products is not negative
            Product product = new Product("P00H00045", "Healthty eyes", -120, 12, 12, 12, "Jar", 0, "M00H00045", "C0001", "CH000045");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ProductInputValue4()
        {
            ///the tax of imported products is not negative
            Product product = new Product("P00H00045", "Healthty eyes", 120, -12, 12, 12, "Jar", 0, "M00H00045", "C0001", "CH000045");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void ConsignmentInputValue1()
        {
            ///the expired date can not earlier than produced date 
            Consignment consignment = new Consignment("P000H000045", DateTime.Parse("1/12/2022"), DateTime.Parse("20 /11/2022"), DateTime.Parse("5 /12/2022"));
        }

    }
}