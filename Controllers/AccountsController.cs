using Inventory_Management_System.Models;
using Inventory_Mnagement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Inventory_Mnagement_System.Controllers
{
  
    public class AccountsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.RoleList = new SelectList(new[] { "Admin", "Manager", "User" });
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string username, string password, String role)
        {
            var user = db.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password && u.Role==role);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["Username"] = user.Username;
                Session["Role"] = user.Role;
                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.RoleList = new SelectList(new[] { "Admin", "Manager", "User" });
            ViewBag.ErrorMessage = "Invalid Credentials";
            return View();
        }
        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }






        // GET: /Account/Register
        [Authorize(Roles = "Admin")]
        public ActionResult Register()
        {
           
            return View();

        }

        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Accounts.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return View(model);
                }

                var user = new Accounts
                {
                    Username = model.Username,
                    Password = model.Password, // In real apps, hash the password!
                    Role = model.Role
                };

                db.Accounts.Add(user);
                db.SaveChanges();

                TempData["Success"] = "User registered successfully!";
                return RedirectToAction("Login");
            }

            return View(model);
        }

       


    }

}


