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

namespace WarehouseManagement
{
    public partial class BillReportForm : Form
    {
        Bill _bill = new Bill();

        List<Product> _products = new List<Product>();
        List<Agency> _agencies = new List<Agency>();
        List<BillDetail> _billDetails = new List<BillDetail>();

        DbHelper _db = new DbHelper();
        public BillReportForm(Bill bill)
        {
            InitializeComponent();

            List<Product> products = new List<Product>();

            _bill = _db.Bills.Where(o => o.Id == bill.Id).First();
            _billDetails = _db.BillDetails.Where(o => o.Bill_Id == _bill.Id).ToList();
            _products = _db.Products.ToList();
            _agencies = _db.Agencies.ToList();

            foreach(var billDetail in _billDetails)
            {
                Product product = _products.Find(o => o.Id == billDetail.Product_Id);
                products.Add(product);

                product = products.Find(o => o.Id == billDetail.Product_Id);
                product.Quantity_Real = billDetail.Quantity;
            }

            Agency agency = _agencies.Find(o => o.Id == _bill.Agency_Id);

            ReportDataSource reportDataSource = new ReportDataSource("Products", products);

            ReportParameter[] p = new ReportParameter[]
            {
                new ReportParameter("CreatedDate", _bill.Exported_Date),
                new ReportParameter("AccountantName", _bill.Accountant_Id),
                new ReportParameter("BillID", _bill.Id.ToString()),
                new ReportParameter("AgencyName", agency.Name),
                new ReportParameter("AgencyEmail", agency.Email),
                new ReportParameter("AgencyPhone", agency.Phone),
                new ReportParameter("AgencyAddress", agency.Address),
                new ReportParameter("Price", _bill.Price.ToString()),
            };

            reportViewer1.LocalReport.SetParameters(p);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);


            reportViewer1.RefreshReport();
        }

        private void BillReportForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
