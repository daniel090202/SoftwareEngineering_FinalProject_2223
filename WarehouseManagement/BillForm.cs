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
    public partial class BillForm : Form
    {
        DbHelper _db = new DbHelper();

        List<Bill> _bills = new List<Bill>();
        List<Agency> _agencies = new List<Agency>();
        List<Product> _products = new List<Product>();
        List<Accountant> _accountants = new List<Accountant>();
        List<BillDetail> _billDetails = new List<BillDetail>();

        public BillForm()
        {
            InitializeComponent();

            _bills = _db.Bills.ToList();
            _agencies = _db.Agencies.ToList();
            _products = _db.Products.ToList();
            _accountants = _db.Accountants.ToList();
            _billDetails = _db.BillDetails.ToList();

            ComboBoxInitialize();
        }

        public void ComboBoxInitialize()
        {
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            foreach (var bill in _bills)
            {
                if (bill.Status == "on processing")
                {
                    comboBox1.Items.Add(bill.Id);
                }
                else
                {
                    comboBox2.Items.Add(bill.Id);
                }
            }

            comboBox3.Items.Add("on processing");
            comboBox3.Items.Add("processed");

            comboBox4.Items.Add("unpaid");
            comboBox4.Items.Add("paid");

            foreach (var accountant in _accountants)
            {
                comboBox5.Items.Add(accountant.Id);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string billID = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (billID == null || billID == "")
            {
                return;
            }
             
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

            List<Product> products = new List<Product>();
            List<BillDetail> billDetails = new List<BillDetail>();

            Agency agency = new Agency();

            int ID = int.Parse(billID);

            Bill bill = _bills.Find(o => o.Id == ID);

            billDetails = _billDetails.FindAll(o => o.Bill_Id == bill.Id);

            agency = _agencies.Find(o => o.Id == bill.Agency_Id);

            string name = agency.Name;
            string email = agency.Email;
            string phone = agency.Phone;
            string address = agency.Address;

            string billStatus = bill.Status;
            string billPaid = bill.Paid;
            string billPayment = bill.Payment;

            textBox1.Text = name;
            textBox2.Text = email;
            textBox3.Text = phone;
            textBox4.Text = address;

            textBox5.Text = billPayment;

            comboBox3.Text = billStatus;
            comboBox4.Text = billPaid;

            dataGridView1.DataSource = billDetails;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string billID = comboBox2.GetItemText(comboBox2.SelectedItem);

            if (billID == null || billID == "")
            {
                return;
            }
                
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;

            List<Product> products = new List<Product>();
            List<BillDetail> billDetails = new List<BillDetail>();

            Agency agency = new Agency();

            int ID = int.Parse(billID);

            Bill bill = _bills.Find(o => o.Id == ID);

            billDetails = _billDetails.FindAll(o => o.Bill_Id == bill.Id);

            agency = _agencies.Find(o => o.Id == bill.Agency_Id);

            string name = agency.Name;
            string email = agency.Email;
            string phone = agency.Phone;
            string address = agency.Address;

            string billStatus = bill.Status;
            string billPaid = bill.Paid;
            string billPayment = bill.Payment;

            textBox1.Text = name;
            textBox2.Text = email;
            textBox3.Text = phone;
            textBox4.Text = address;

            textBox5.Text = billPayment;

            comboBox3.Text = billStatus;
            comboBox4.Text = billPaid;

            dataGridView1.DataSource = billDetails;
        }

        private void BillForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string billID = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (billID == "" || billID == null)
            {
                billID = comboBox2.GetItemText(comboBox2.SelectedItem);
            }

            int ID = int.Parse(billID);

            Bill bill = _db.Bills.Where(o => o.Id == ID).First();

            string billStatus = comboBox3.GetItemText(comboBox3.SelectedItem);
            string billPaid = comboBox4.GetItemText(comboBox4.SelectedItem);

            string accountantID = comboBox5.GetItemText(comboBox5.SelectedItem);

            if (billStatus != "on processing")
            {
                bill.Checked_Date = DateTime.Now.ToString();
                bill.Status = billStatus;
                bill.Paid = billPaid;
                bill.Accountant_Id = accountantID;

                _db.SaveChanges();
            }

            button4_Click(sender, e);

            dataGridView1.DataSource = null;

            _bills = _db.Bills.ToList();

            ComboBoxInitialize();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            dataGridView1.ClearSelection();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string billID = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (billID == "" || billID == null)
            {
                billID = comboBox2.GetItemText(comboBox2.SelectedItem);
            }

            int ID = int.Parse(billID);

            Bill bill = _db.Bills.Where(o => o.Id == ID).First();

            string billStatus = "canceled";
            string billPaid = comboBox4.GetItemText(comboBox4.SelectedItem);

            string accountantID = comboBox5.GetItemText(comboBox5.SelectedItem);

            bill.Checked_Date = DateTime.Now.ToString();
            bill.Status = billStatus;
            bill.Paid = "unpaid";
            bill.Accountant_Id = accountantID;

            _db.SaveChanges();

            button4_Click(sender, e);

            dataGridView1.DataSource = null;

            _bills = _db.Bills.ToList();

            ComboBoxInitialize();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string billID = comboBox1.GetItemText(comboBox1.SelectedItem);

            if (billID == "" || billID == null)
            {
                billID = comboBox2.GetItemText(comboBox2.SelectedItem) ;
            }

            int ID = int.Parse(billID);

            Bill bill = _db.Bills.Where(o => o.Id == ID).First();

            BillReportForm billReportForm = new BillReportForm(bill);
            billReportForm.ShowDialog(this);
        }
    }
}
