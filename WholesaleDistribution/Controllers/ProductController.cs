using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using System.Linq;
using WholesaleDistribution.Models;

namespace WholesaleDistribution.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbHelper _db;

        private static List<Product> _products;
        private static List<Cart> _cart = new List<Cart>();

        public ProductController(ILogger<HomeController> logger, DbHelper db)
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

        [HttpPost]
        public IActionResult Add(IFormCollection Fields)
        {
            string productID = Fields["id"];
            int amount = int.Parse(Fields["quantity"]);

            Cart cart = _cart.Find(o => o.Product_Id == productID);

            if(cart != null)
            {
                cart.Quantity += amount;
            }
            else
            {
                _cart.Add(new Cart( productID, amount));
            }

            return RedirectToAction("Cart");
        }

        public IActionResult Detail(string id)
        {
            Product product = _products.Find(o => o.Id == id);

            return View(product);
        }

        public IActionResult Remove(string id)
        {
            Product product = _products.Find(o => o.Id == id);

            Cart cart = _cart.Find(o => o.Product_Id == product.Id);
            _cart.Remove(cart);

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

            int pageSize = 5;

            return View(PaginatedList<Product>.Create(products, id ?? 1, pageSize));
        }

        public IActionResult Agency()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agency(IFormCollection Fields)
        {
            string name = Fields["name"];
            string email = Fields["email"];
            string phone = Fields["phone"];
            string address = Fields["address"];
            string payment = Fields["payment"];

            string checkedDate = "on processing";
            string status = "on processing";
            string paid = "unpaid";
            string Accountant_Id = "20EH00373";

            List<Agency> agencies = _db.Agencies.ToList<Agency>();
            Agency agency = new Agency();

            agency = agencies.Find(o => o.Phone == phone || o.Email == email);

            if (agency == null)
            {
                _db.Agencies.Add(new Agency(name, email, phone, address));
            }

            _db.SaveChanges();

            agency = _db.Agencies.Where(o => o.Phone == phone).First();

            double summary = 0;

            foreach(var cart in _cart) {
                Product product = _products.Find(o => o.Id == cart.Product_Id);

                summary += product.Price * cart.Quantity * 12 + product.Tax;
            }

            summary *= 0.3;

            _db.Bills.Add(new Bill(DateTime.Now.ToString(), checkedDate, summary, payment, status, paid, Accountant_Id, agency.Id));
            _db.SaveChanges();

            Bill bill = _db.Bills.Where(o => o.Agency_Id == agency.Id).First();

            foreach (var cart in _cart)
            {
                Product product = _products.Find(o => o.Id == cart.Product_Id);

                _db.BillDetails.Add(new BillDetail(bill.Id, product.Id, cart.Quantity));
            }

            _db.SaveChanges();

            _cart = null;
            _cart = new List<Cart>();

            return RedirectToAction("Bill");
        }

        public IActionResult Bill(int? id)
        {
            List<Bill> bills = _db.Bills.ToList();

            int pageSize = 5;

            return View(PaginatedList<Bill>.Create( bills, id ?? 1, pageSize));
        }
    }
}