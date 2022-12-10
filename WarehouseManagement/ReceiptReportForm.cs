using Microsoft.Reporting.WinForms;
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
using WarehouseManagement.SupplementProductManagementDataSetTableAdapters;

namespace WarehouseManagement
{
    public partial class ReceiptReportForm : Form
    {
        Receipt _receipt;

        List<Product> _products = new List<Product>();

        DbHelper _db = new DbHelper();
        public ReceiptReportForm(Receipt receipt)
        {
            InitializeComponent();

            _receipt = _db.Receipts.Where(o => o.Id == receipt.Id).First();

            List<ReceiptDetail> receiptDetails = new List<ReceiptDetail>();
            List<Product> products = _db.Products.ToList();

            receiptDetails = _db.ReceiptDetails.Where(o => o.Receipt_Id == _receipt.Id).ToList();

            foreach (var receiptDetail in receiptDetails)
            {
                Product product = products.Find(o => o.Id == receiptDetail.Product_Id);

                _products.Add(product);
            }

            ReportDataSource reportDataSource = new ReportDataSource("Products", _products);

            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("CreatedDate", _receipt.Created_Date),
                new ReportParameter("AccountantName", _receipt.Accountant_Id),
                new ReportParameter("ReceiptID", _receipt.Id.ToString()),
                new ReportParameter("SupplierID", _receipt.Supplier_Id),
                new ReportParameter("WarehouseAddress", _receipt.Address),
                new ReportParameter("Price", _receipt.Price.ToString()),
            };

            reportViewer1.LocalReport.SetParameters(p);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);


            reportViewer1.RefreshReport();
        }

        private void ReceiptReportForm_Load(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
