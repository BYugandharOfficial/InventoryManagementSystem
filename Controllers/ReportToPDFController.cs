using Inventory_Management_System.Models;
using Inventory_Mnagement_System.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Mnagement_System.Controllers
{
    public class ReportToPDFController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ReportToPDF
        public ActionResult Index()
        {
            return View(db.ReportToPDF.ToList());
        }

        // GET: ReportToPDF/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportToPDF reportToPDF = db.ReportToPDF.Find(id);
            if (reportToPDF == null)
            {
                return HttpNotFound();
            }
            return View(reportToPDF);
        }

        // GET: ReportToPDF/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportToPDF/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,InvoiceDate,CustomerId,FullName,CategoryId,CategoryName,ProductId,ProductName,TotalAmount,PaidAmount,Status")] ReportToPDF reportToPDF)
        {
            if (ModelState.IsValid)
            {
                db.ReportToPDF.Add(reportToPDF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportToPDF);
        }

        // GET: ReportToPDF/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportToPDF reportToPDF = db.ReportToPDF.Find(id);
            if (reportToPDF == null)
            {
                return HttpNotFound();
            }
            return View(reportToPDF);
        }

        // POST: ReportToPDF/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,InvoiceDate,CustomerId,FullName,CategoryId,CategoryName,ProductId,ProductName,TotalAmount,PaidAmount,Status")] ReportToPDF reportToPDF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportToPDF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportToPDF);
        }

        // GET: ReportToPDF/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportToPDF reportToPDF = db.ReportToPDF.Find(id);
            if (reportToPDF == null)
            {
                return HttpNotFound();
            }
            return View(reportToPDF);
        }

        // POST: ReportToPDF/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportToPDF reportToPDF = db.ReportToPDF.Find(id);
            db.ReportToPDF.Remove(reportToPDF);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }





        public ActionResult ExportToPDF()
        {
            var ReportToPDF = db.ReportToPDF.ToList();

            MemoryStream workStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 1, 1, 20, 20);
            
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();

            // Add Title
            document.Add(new Paragraph("Customers.Pdf"));
            document.Add(new Chunk("\n"));

            // Create Table
            PdfPTable table = new PdfPTable(8); // Columns count
            table.WidthPercentage = 100;
            float[] columnWidths = { 2f, 2.5f, 2.5f, 3f, 3f, 3f, 3f, 2f };
            table.SetWidths(columnWidths);

            // Add Header
            table.AddCell("InvoiceId");
            table.AddCell("InvoiceDate");
            table.AddCell("FullName");
            table.AddCell("CategoryName");
            table.AddCell("ProductName");
            table.AddCell("TotalAmount");
            table.AddCell("PaidAmount");
            table.AddCell("Status");
         
            foreach (var ExportPDF in ReportToPDF)
            {
                table.AddCell(ExportPDF.InvoiceId.ToString());
                table.AddCell(ExportPDF.InvoiceDate.ToString());  
                table.AddCell(ExportPDF.FullName.ToString());
                table.AddCell(ExportPDF.CategoryName.ToString());
                table.AddCell(ExportPDF.ProductName.ToString());
                table.AddCell(ExportPDF.TotalAmount.ToString());
                table.AddCell(ExportPDF.PaidAmount.ToString());
                table.AddCell(ExportPDF.Status.ToString());

            }

            document.Add(table);
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", "Report.pdf");
        }
    }
}
    
