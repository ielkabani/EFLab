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

            List<Invoice> invoices = _context.Invoices.ToList();
            invoices.ForEach(x => lstInvoices.Items.Add(x.GetInvoiceText(", ")));       
            }
    }
}
