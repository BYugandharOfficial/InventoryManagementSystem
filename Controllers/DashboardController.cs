using Inventory_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Mnagement_System.Controllers
{
    public class DashboardController : Controller
    {
       
            // GET: Dashboard

            private AppDbContext db = new AppDbContext();

            public ActionResult Index()
            {
                var totalProducts = db.Products.Count();
                var totalSuppliers = db.Suppliers.Count();
                var totalCustomers = db.Customer.Count();
                var totalSales = db.Sales.Count();
                var totalStock = db.Stocks.Sum(p => (int?)p.Quantity) ?? 0;
                var lowStockCount = db.Stocks.Count(p => p.Quantity <= p.ReorderLevel);

                var recentProducts = db.Products.OrderByDescending(p => p.CreatedDate).Take(6).ToList();

                ViewBag.TotalProducts = totalProducts;
                ViewBag.TotalSuppliers = totalSuppliers;
                ViewBag.TotalCustomers = totalCustomers;
                ViewBag.TotalSales = totalSales;
                ViewBag.TotalStock = totalStock;
                ViewBag.LowStock = lowStockCount;
                ViewBag.RecentProducts = recentProducts;

                return View();
            }
        }

    }