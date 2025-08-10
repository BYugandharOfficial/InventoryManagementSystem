using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventory_Mnagement_System.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; } //Primary key

        [Required]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Navagation property for related products
        public virtual ICollection<Products> Products { get; set; }
    }
}