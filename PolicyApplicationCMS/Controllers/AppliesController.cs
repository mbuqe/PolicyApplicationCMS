using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PolicyApplicationCMS.Models;

namespace PolicyApplicationCMS.Controllers
{
    public class AppliesController : Controller
    {
        private InsuranceContext db = new InsuranceContext();

        // GET: Applies
        public ActionResult Index()
        {
            var apply = db.Apply.Include(a => a.Customer);
            var customers = db.Customers.Include(a => a.C_IDNumber);
            return View(apply.ToList());
        }

        // GET: Applies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply apply = db.Apply.Find(id);
            if (apply == null)
            {
                return HttpNotFound();
            }
            return View(apply);
        }

        // GET: Applies/Create
        public ActionResult Create()
        {
            var singleListItem = db.Customers.ToList().LastOrDefault();
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "QuotationID");
            
            return View(singleListItem);
        }

        // POST: Applies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Policy_Number,C_IDNumber,Commencement_date,QuotationID,Ben_IDNumber,Application_Status,Policy_Status")] Apply apply)
        {
            if (ModelState.IsValid)
            {
                db.Apply.Add(apply);
                db.SaveChanges();
                return RedirectToAction("MyProfile");
            }

            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "QuotationID", apply.QuotationID);
            ViewBag.C_IDNumber = new SelectList(db.Customers, "C_IDNumber", "C_IDNumber", apply.QuotationID);
            return View(apply);
        }

        // GET: Applies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply apply = db.Apply.Find(id);
            if (apply == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "Pre_existing_Conditions", apply.QuotationID);
            return View(apply);
        }

        // POST: Applies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Policy_Number,C_IDNumber,Commencement_date,QuotationID,Ben_IDNumber,Application_Status,Policy_Status")] Apply apply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "Pre_existing_Conditions", apply.QuotationID);
            return View(apply);
        }

        // GET: Applies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apply apply = db.Apply.Find(id);
            if (apply == null)
            {
                return HttpNotFound();
            }
            return View(apply);
        }

        // POST: Applies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apply apply = db.Apply.Find(id);
            db.Apply.Remove(apply);
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
    }
}
