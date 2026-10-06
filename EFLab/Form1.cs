using EFLab.Models.DataLayer;

namespace EFLab
{
    public partial class Form1 : Form
    {
        private MMABooksContext _context;
        private Customer _customer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _context = new MMABooksContext();
            _customer = _context.Customers.Find(2);
            lstInvoices.Items.Add(_customer.GetCustomerText(", "));

            //Step1: Get the data source from the database using EF Core
            List<Invoice> invoices = _context.Invoices.ToList();
            invoices.ForEach(x => lstInvoices.Items.Add(x.GetInvoiceText(", ")));


            //Step2: Define a query (using LINQ expressoin syntax)

            var selectedInv = from inv in invoices
                              where inv.ProductTotal > 100
                              select inv;
            //Step3: Execute the query and display the results in the lstFiltered1

            foreach (var inv in selectedInv)
            {
                lstFiltered1.Items.Add(inv.GetInvoiceText(", "));
            }

            //Step2: Define a quey (using LINQ method syntax)
            var selectedInv2 = invoices.Where(inv => inv.ProductTotal > 100)
                                       .OrderBy(inv => inv.InvoiceDate)
                                       .ThenByDescending(invoices => invoices.ProductTotal)
                                       .Select(inv => new { inv.InvoiceDate, inv.ProductTotal });

            //Step3: Execute the query and diplay the results in the lstFiltered2

            foreach (var inv in selectedInv2)
            {
                lstFiltered2.Items.Add(inv.InvoiceDate.ToString() + ", " + inv.ProductTotal.ToString());
            }

        }

    }
}
