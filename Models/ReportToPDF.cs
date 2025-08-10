using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Mnagement_System.Models
{
    public class ReportToPDF
    {
        [Key] 
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }
        public string FullName { get; set; }

        public int CategoryId { get; set; } 
        public string CategoryName { get; set; } 

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Status { get; set; } // Paid, Unpaid, Partial
    }
}