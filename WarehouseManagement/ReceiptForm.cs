using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarehouseManagement.Model;

namespace WarehouseManagement
{
    public partial class ReceiptForm : Form
    {
        DbHelper _db = new DbHelper();

        List<Accountant> _accountants = new List<Accountant>();
        List<Product> _products = new List<Product>();
        List<Category> _categories = new List<Category>();
        List<Manufacturer> _manufacturers = new List<Manufacturer>();
        List<Consignment> _consignments = new List<Consignment>();

        Supplier _supplier;

        public ReceiptForm()
        {
            InitializeComponent();

            _accountants = _db.Accountants.ToList<Accountant>();

            foreach(var accountant in _accountants)
            {
                comboBox1.Items.Add(accountant.Id);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string productID = textBox7.Text;
            string productName = textBox8.Text;
            double productPrice = double.Parse(textBox9.Text);
            double productTax = double.Parse(textBox10.Text);
            string productUnit = textBox11.Text;
            int deliveredAmount = int.Parse(textBox12.Text);
            int importedAmount = int.Parse(textBox13.Text);

            string categoryID = textBox14.Text;
            string targetConsumer = textBox15.Text;
            string gender = textBox16.Text;
            int age = int.Parse(textBox17.Text);
            string effectOn = textBox18.Text;

            string manufacturerID = textBox19.Text;
            string manufacturerName = textBox20.Text;
            string manufacturerNation = textBox21.Text;
            string manufacturerAddress = textBox22.Text;
            string manufacturerPhone = textBox23.Text;
            string manufacturerEmail = textBox24.Text;

            string consignmentID = textBox1.Text;
            DateTime importedDate = dateTimePicker1.Value;
            DateTime producedDate = dateTimePicker2.Value;
            DateTime expiredDate = dateTimePicker3.Value;

            _products.Add(new Product(productID, productName, productPrice, productTax, deliveredAmount, importedAmount, productUnit, 0, manufacturerID, categoryID, consignmentID));
            _manufacturers.Add(new Manufacturer(manufacturerID, manufacturerName, manufacturerEmail, manufacturerNation, manufacturerPhone, manufacturerAddress));
            _categories.Add(new Category(categoryID, targetConsumer, gender, age, effectOn));
            _consignments.Add(new Consignment(consignmentID, producedDate, expiredDate, importedDate));

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _products;

            textBox1.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();

            dataGridView1.ClearSelection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

                return;
            }

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            Category category = new Category();
            Manufacturer manufacturer = new Manufacturer();
            Consignment consignment = new Consignment();

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            string productID = row.Cells[0].Value.ToString();
            string productName = row.Cells[1].Value.ToString();
            double productPrice = double.Parse(row.Cells[2].Value.ToString());
            double productTax = double.Parse(row.Cells[3].Value.ToString());
            string productUnit = row.Cells[6].Value.ToString();
            int deliveredAmount = int.Parse(row.Cells[4].Value.ToString());
            int importedAmount = int.Parse(row.Cells[5].Value.ToString());
            int soldAmount = int.Parse(row.Cells[7].Value.ToString());

            string categoryID = row.Cells[9].Value.ToString();
            category = _categories.Find(o => o.Id == categoryID);
            string targetConsumer = category.Consumer;
            string gender = category.Gender;
            int age = category.Age;
            string effectOn = category.Effect;

            string manufacturerID = row.Cells[8].Value.ToString();
            manufacturer = _manufacturers.Find(o => o.Id == manufacturerID);
            string manufacturerName = manufacturer.Name;
            string manufacturerNation = manufacturer.Nation;
            string manufacturerAddress = manufacturer.Address;
            string manufacturerPhone = manufacturer.Phone;
            string manufacturerEmail = manufacturer.Email;

            string consignmentID = row.Cells[10].Value.ToString();
            consignment = _consignments.Find(o => o.Id == consignmentID);
            DateTime importedDate = consignment.Imported_Date;
            DateTime producedDate = consignment.Produced_Date;
            DateTime expiredDate = consignment.Expired_Date;

            textBox1.Text = consignmentID;
            textBox7.Text = productID;
            textBox8.Text = productName;
            textBox9.Text = productPrice.ToString();
            textBox10.Text = productTax.ToString();
            textBox11.Text = productUnit;
            textBox12.Text = deliveredAmount.ToString();
            textBox13.Text = importedAmount.ToString();
            textBox14.Text = categoryID;
            textBox15.Text = targetConsumer;
            textBox16.Text = gender;
            textBox17.Text = age.ToString();
            textBox18.Text = effectOn;
            textBox19.Text = manufacturerID;
            textBox20.Text = manufacturerName;
            textBox21.Text = manufacturerNation;
            textBox22.Text = manufacturerAddress;
            textBox23.Text = manufacturerPhone;
            textBox24.Text = manufacturerEmail;

            dateTimePicker1.Value = importedDate;
            dateTimePicker2.Value = producedDate;
            dateTimePicker3.Value = expiredDate;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            DialogResult rs = MessageBox.Show("Are you sure to delete this item?", "Confirm delete", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                Category category = new Category();
                Manufacturer manufacturer = new Manufacturer();
                Consignment consignment = new Consignment();
                Product product = new Product();

                string productID = textBox7.Text;
                product = _products.Find(o => o.Id == productID);
                _products.Remove(product);

                string categoryID = textBox14.Text;
                category = _categories.Find(o => o.Id == categoryID);
                _categories.Remove(category);

                string manufacturerID = textBox19.Text;
                manufacturer = _manufacturers.Find(o => o.Id == manufacturerID);
                _manufacturers.Remove(manufacturer);

                string consignmentID = textBox1.Text;
                consignment = _consignments.Find(o => o.Id == consignmentID);
                _consignments.Remove(consignment);


                dataGridView1.DataSource = null;
                dataGridView1.DataSource = _products;

                button2_Click(sender, e);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }

            Category category = new Category();
            Manufacturer manufacturer = new Manufacturer();
            Consignment consignment = new Consignment();
            Product product = new Product();

            int index = dataGridView1.SelectedRows[0].Index;

            string formerProductID = dataGridView1.Rows[index].Cells[0].Value.ToString();
            product = _products.Find(o => o.Id == formerProductID);
            _products.Remove(product);

            string formerCategoryID = product.Category_Id;
            category = _categories.Find(o => o.Id == formerCategoryID);
            _categories.Remove(category);

            string formerManufacturerID = product.Manufacturer_Id;
            manufacturer = _manufacturers.Find(o => o.Id == formerManufacturerID);
            _manufacturers.Remove(manufacturer);

            string formerConsignmentID = product.Consignment_Id;
            consignment = _consignments.Find(o => o.Id == formerConsignmentID);
            _consignments.Remove(consignment);

            string productID = textBox7.Text;
            string productName = textBox8.Text;
            double productPrice = double.Parse(textBox9.Text);
            double productTax = double.Parse(textBox10.Text);
            string productUnit = textBox11.Text;
            int deliveredAmount = int.Parse(textBox12.Text);
            int importedAmount = int.Parse(textBox13.Text);

            string categoryID = textBox14.Text;
            string targetConsumer = textBox15.Text;
            string gender = textBox16.Text;
            int age = int.Parse(textBox17.Text);
            string effectOn = textBox18.Text;

            string manufacturerID = textBox19.Text;
            string manufacturerName = textBox20.Text;
            string manufacturerNation = textBox21.Text;
            string manufacturerAddress = textBox22.Text;
            string manufacturerPhone = textBox23.Text;
            string manufacturerEmail = textBox24.Text;

            string consignmentID = textBox1.Text;
            DateTime importedDate = dateTimePicker1.Value;
            DateTime producedDate = dateTimePicker2.Value;
            DateTime expiredDate = dateTimePicker3.Value;


            _products.Add(new Product(productID, productName, productPrice, productTax, deliveredAmount, importedAmount, productUnit, 0, manufacturerID, categoryID, consignmentID));
            _manufacturers.Add(new Manufacturer(manufacturerID, manufacturerName, manufacturerEmail, manufacturerNation, manufacturerPhone, manufacturerAddress));
            _categories.Add(new Category(categoryID, targetConsumer, gender, age, effectOn));
            _consignments.Add(new Consignment(consignmentID, producedDate, expiredDate, importedDate));

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _products;

            button2_Click(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Product> products = _db.Products.ToList();

            double summary = 0;

            foreach (var category in _categories)
            {
                _db.Categories.Add(category);
            }

            _db.SaveChanges();

            foreach (var manufacturer in _manufacturers)
            {
                _db.Manufacturers.Add(manufacturer);
            }

            _db.SaveChanges();

            foreach (var consignment in _consignments)
            {
                _db.Consignments.Add(consignment);
            }

            _db.SaveChanges();

            foreach(var product in _products)
            {
                Product existedProduct = products.Find(o => o.Id == product.Id);

                if (existedProduct != null)
                {
                    existedProduct.Quantity_Theory += product.Quantity_Theory;
                    existedProduct.Quantity_Real += product.Quantity_Real;
                }
                else
                {
                    _db.Products.Add(product);
                }

                summary += product.Price * product.Quantity_Real * 12;
            }

            _db.SaveChanges();

            string supplierID = textBox2.Text;
            string supplierName = textBox3.Text;
            string supplierAddress = textBox4.Text;
            string supplierPhone = textBox5.Text;
            string supplierEmail = textBox6.Text;

            string warehouseAddress = textBox25.Text;

            string accountantID = comboBox1.GetItemText(comboBox1.SelectedItem);

            _supplier = new Supplier(supplierID, supplierName, supplierAddress, supplierPhone, supplierEmail);
            _db.Suppliers.Add(_supplier);

            _db.SaveChanges();

            Receipt receipt = new Receipt(DateTime.Now.ToString(), summary, warehouseAddress, supplierID, accountantID);

            _db.Receipts.Add(receipt);

            _db.SaveChanges();

            foreach (var product in _products)
            {
                ReceiptDetail receiptDetail = new ReceiptDetail(receipt.Id, product.Id, product.Quantity_Real);

                _db.ReceiptDetails.Add(receiptDetail);
            }

            _db.SaveChanges();

            ReceiptReportForm receiptReportForm = new ReceiptReportForm(receipt);
            receiptReportForm.ShowDialog(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
