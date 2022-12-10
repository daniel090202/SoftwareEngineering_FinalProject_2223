namespace RetailsDistribution.Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name, string email, string phone, string address, string gender, string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
            Gender = gender;
            Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
