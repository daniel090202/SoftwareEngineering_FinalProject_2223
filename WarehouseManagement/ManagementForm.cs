using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagement.Model;

namespace WarehouseManagement
{
    public partial class ManagementForm : Form
    {
        DbHelper _db = new DbHelper();

        List<Receipt> _receipts = new List<Receipt>();
        List<Bill> _bills = new List<Bill>();
        List<ReceiptDetail> _receiptDetails = new List<ReceiptDetail>();
        List<BillDetail> _billsDetails = new List<BillDetail>();  

        public ManagementForm()
        {
            InitializeComponent();

            _receipts = _db.Receipts.ToList();
            _bills = _db.Bills.ToList();
            _receiptDetails = _db.ReceiptDetails.ToList();
            _billsDetails = _db.BillDetails.ToList();
        }

        private void ManagementForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BillForm billForm = new BillForm();
            billForm.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value;
            DateTime endDate = dateTimePicker2.Value;

            List<Receipt> receipts = new List<Receipt>();
            List<Bill> bills = new List<Bill>();

            List<ReceiptDetail> receiptDetails = new List<ReceiptDetail>();
            List<BillDetail> billDetails = new List<BillDetail>();

            List<Product> products = new List<Product>();

            double importationCapital = 0;
            double totalRevenue = 0;

            if (startDate == endDate || startDate.Date > endDate.Date)
            {
                return;
            }

            receipts = _receipts.FindAll(o => DateTime.Parse(o.Created_Date) > startDate && DateTime.Parse(o.Created_Date) < endDate);
            bills = _bills.FindAll(o => DateTime.Parse(o.Exported_Date) > startDate && DateTime.Parse(o.Exported_Date) < endDate);

            foreach(var receipt in receipts)
            {
                receiptDetails = _receiptDetails.FindAll(o => o.Receipt_Id == receipt.Id);
                importationCapital += receipt.Price;
            }

            foreach(var bill in bills)
            {
                billDetails = _billsDetails.FindAll(o => o.Bill_Id == bill.Id);
                totalRevenue += bill.Price;
            }

            dataGridView1.DataSource = receiptDetails;
            dataGridView2.DataSource = billDetails;

            foreach(var receiptDetail in receiptDetails)
            {
                Product product = products.Find(o => o.Id == receiptDetail.Product_Id);

                if(product != null)
                {
                    product.Quantity_Real += receiptDetail.Quantity;
                }
                else if(product == null)
                {
                    products.Add(new Product(receiptDetail.Product_Id, "", 0, 0, 0, receiptDetail.Quantity, "", 0, "", "", ""));
                }
            }

            Product mostImportedProduct = products.Find(o => o.Quantity_Real == products.Max(n => n.Quantity_Real));

            if(mostImportedProduct != null)
            {
                textBox1.Text = mostImportedProduct.Id;
                textBox2.Text = mostImportedProduct.Quantity_Real.ToString();
                textBox6.Text = importationCapital.ToString();
            }

            foreach (var billDetail in billDetails)
            {
                Product product = products.Find(o => o.Id == billDetail.Product_Id);

                if (product != null)
                {
                    product.Quantity_Real += billDetail.Quantity;
                }
                else if (product == null)
                {
                    products.Add(new Product(billDetail.Product_Id, "", 0, 0, 0, billDetail.Quantity, "", 0, "", "", ""));
                }
            }

            Product mostExportedProduct = products.Find(o => o.Quantity_Real == products.Max(n => n.Quantity_Real)); mostImportedProduct = products.Find(o => o.Quantity_Real == products.Max(n => n.Quantity_Real));

            if(mostImportedProduct != null)
            {
                textBox4.Text = mostExportedProduct.Id;
                textBox3.Text = mostExportedProduct.Quantity_Real.ToString();
                textBox5.Text = totalRevenue.ToString();
                textBox7.Text = (totalRevenue * 0.2).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }
    }
}
