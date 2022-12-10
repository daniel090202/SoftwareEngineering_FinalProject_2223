using Microsoft.AspNetCore.Mvc;
using RetailsDistribution.Models;

namespace RetailsDistribution.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbHelper _db;

        private static Customer _customer = new Customer();
        private static List<Product> _products;
        private static List<Cart> _cart = new List<Cart>();

        public CustomerController(ILogger<HomeController> logger, DbHelper db)
        {
            _logger = logger;
            _db = db;

            _products = _db.Products.ToList();
        }

        public IActionResult Index(int? id)
        {
            List<Product> products = _db.Products.ToList();

            int pageSize = 5;

            return View(PaginatedList<Product>.Create(products, id ?? 1, pageSize));
        }

        public IActionResult Detail(string id)
        {
            Product product = _products.Find(o => o.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Add(IFormCollection Fields)
        {
            string productID = Fields["id"];
            int amount = int.Parse(Fields["quantity"]);

            Cart cart = _cart.Find(o => o.Product_Id == productID);

            if (cart != null)
            {
                cart.Quantity += amount;
            }
            else
            {
                _cart.Add(new Cart(productID, amount));
            }

            return RedirectToAction("Cart");
        }

        public IActionResult Cart(int? id)
        {
            List<Product> products = new List<Product>();

            _products = _db.Products.ToList();

            foreach (var cart in _cart)
            {
                Product product = _products.Find(o => o.Id == cart.Product_Id);
                products.Add(product);
            }

            ViewBag.Cart = _cart;
            ViewBag.Customer = _customer;

            int pageSize = 5;

            return View(PaginatedList<Product>.Create(products, id ?? 1, pageSize));
        }

        public IActionResult Remove(string id)
        {
            Product product = _products.Find(o => o.Id == id);

            Cart cart = _cart.Find(o => o.Product_Id == product.Id);
            _cart.Remove(cart);

            return RedirectToAction("Cart");
        }

        public IActionResult Invoice(int? id)
        {
            List<Invoice> invoices = _db.Invoices.ToList();

            int pageSize = 5;

            return View(PaginatedList<Invoice>.Create(invoices, id ?? 1, pageSize));
        }

        [HttpPost]
        public IActionResult Invoice(IFormCollection Fields)
        {
            if (_customer == null)
            {
                return View();
            }

            string payment = Fields["payment"];
            string checkedDate = "on processing";
            string status = "on processing";
            string paid = "unpaid";
            string Accountant_Id = "20EH00373";


            double summary = 0;

            foreach (var cart in _cart)
            {
                Product product = _products.Find(o => o.Id == cart.Product_Id);

                summary += product.Price * cart.Quantity * 12 + product.Tax;
            }

            summary *= 0.3;

            _db.Invoices.Add(new Invoice(DateTime.Now.ToString(), checkedDate, summary, payment, status, paid, Accountant_Id, _customer.Id));
            _db.SaveChanges();

            Invoice invoice = _db.Invoices.Where(o => o.Customer_Id == _customer.Id).First();

            foreach (var cart in _cart)
            {
                Product product = _products.Find(o => o.Id == cart.Product_Id);

                _db.InvoiceDetails.Add(new InvoiceDetail(invoice.Id, product.Id, cart.Quantity));
            }

            _db.SaveChanges();

            _cart = null;
            _cart = new List<Cart>();

            return RedirectToAction("Invoice");
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(IFormCollection Fields)
        {
            string email = Fields["email"];
            string password = Fields["password"];

            List<Customer> customers = _db.Customers.ToList();

            Customer customer = customers.Find(o => o.Email == email && o.Password == password);

            if(customer != null)
            {
                _customer = customer;

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(IFormCollection Fields)
        {
            string email = Fields["email"];
            string password = Fields["password"];
            string phone = Fields["phone"];
            string address = Fields["address"];
            string gender = Fields["gender"];
            string name = Fields["name"];

            List<Customer> customers = _db.Customers.ToList();

            Customer customer = customers.Find(o => o.Email == email && o.Password == password);

            if (customer == null)
            {
                _db.Customers.Add(new Customer(name, email, phone, address, gender, password));
                _db.SaveChanges();

                return RedirectToAction("SignIn");
            }

            return View();
        }
    }
}
