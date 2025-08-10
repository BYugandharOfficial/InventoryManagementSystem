using Inventory_Mnagement_System.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Inventory_Management_System.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Accounts> Accounts { get; set; }

        public DbSet<Register> Registers { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Category { get; set; }
        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
       
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Bill> Bill { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<ReportToPDF> ReportToPDF { get; set; }

        public AppDbContext() : base("DefaultConnection") { }

      
    }
}
