using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Mnagement_System.Models
{
    public class SaleItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Bill")]
        public int SaleId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Bill Bill { get; set; }
    }
}