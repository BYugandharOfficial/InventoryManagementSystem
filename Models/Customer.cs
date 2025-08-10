using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Mnagement_System.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } 

        [Required]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}