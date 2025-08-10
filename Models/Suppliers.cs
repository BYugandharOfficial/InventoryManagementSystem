using System;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Mnagement_System.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public string ProductName { get; set; }

        public string ContactPerson { get; set; }

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public string GSTNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}