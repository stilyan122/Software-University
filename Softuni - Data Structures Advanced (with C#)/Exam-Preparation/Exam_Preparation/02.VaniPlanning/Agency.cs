namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Agency : IAgency
    {
        private Dictionary<string, Invoice> invoices
            = new Dictionary<string, Invoice>();

        public void Create(Invoice invoice)
        {
            if (invoices.ContainsKey(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }
            invoices.Add(invoice.SerialNumber, invoice);
        }

        public void ThrowInvoice(string number)
        {
            bool invoiceInList = this.invoices.Remove(number);
            if (invoiceInList == false)
            {
                throw new ArgumentException();
            }
        }

        public void ThrowPayed()
        {
            var invoicesToRemove = this.invoices.Values
                .Where(x => x.Subtotal == 0);
            foreach (var inv in invoicesToRemove)
            {
                this.invoices.Remove(inv.SerialNumber);
            }
        }

        public int Count()
        {
            return this.invoices.Count;
        }

        public bool Contains(string number)
        {
            return this.invoices.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            var invoicesDue = this.invoices.Values
                .Where(x => x.DueDate == due)
                .ToList();
            invoicesDue.ForEach(x =>
            {
                x.Subtotal = 0;
            });
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime 
            start, DateTime end)
        {
            var inv = this.invoices.Values
                .Where(x => x.IssueDate >= start &&
                x.IssueDate <= end)
                .OrderBy(x => x.IssueDate);

            if (inv.Count() == 0)
            {
                throw new ArgumentException();
            }

            return inv;
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            var inv = this.invoices.Values
                .Where(x => x.SerialNumber.Contains(serialNumber))
                .OrderByDescending(x => x.SerialNumber);

            if (inv.Count() == 0)
            {
                throw new ArgumentException();
            }

            return inv;
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime
            start, DateTime end)
        {
            var inv = this.invoices.Values
                .Where(x => x.DueDate >= start &&
                x.DueDate <= end);

            if (inv.Count() == 0)
            {
                throw new ArgumentException();
            }

            return inv;
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department
            department)
        {
            return this.invoices.Values
                .Where(x => x.Department == department)
                .OrderByDescending(x => x.Subtotal)
                .ThenBy(x => x.IssueDate);
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            return this.invoices.Values
                .Where(x => x.CompanyName == company)
                .OrderByDescending(x => x.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            var inv = this.invoices.Values
                .Where(x => x.DueDate == dueDate).ToList();

            if (inv.Count() == 0)
            {
                throw new ArgumentException();
            }

            inv.ForEach(x =>
            {
                x.DueDate.AddDays(days);
            });

        }
    }
}
