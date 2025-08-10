using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Mnagement_System.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; } //Primary key

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; } //Foreign key

        public int Quantity { get; set; }


        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Unit { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public virtual Categories Categories { get; set; }
    }
}