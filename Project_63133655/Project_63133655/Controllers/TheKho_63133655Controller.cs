using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_63133655.Models;

namespace Project_63133655.Controllers
{
    public class TheKho_63133655Controller : Controller
    {
        private Project_63133655Entities db = new Project_63133655Entities();

        // GET: TheKho_63133655
        public ActionResult Index()
        {
            return View(db.THEKHO.ToList());
        }
        [HttpPost]
        public ActionResult Index(string maCF, string loaiCF)
        {
            var timTHEKHO = db.THEKHO.SqlQuery("exec TIMKIEM_THEKHO '" + maCF + "', N'" + loaiCF + "' ");
            return View(timTHEKHO.ToList());
        }

        // GET: TheKho_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEKHO tHEKHO = db.THEKHO.Find(id);
            if (tHEKHO == null)
            {
                return HttpNotFound();
            }
            return View(tHEKHO);
        }

        // GET: TheKho_63133655/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TheKho_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCF,LoaiCF,SoLuong,DVT,DonGia")] THEKHO tHEKHO)
        {
            if (ModelState.IsValid)
            {
                db.THEKHO.Add(tHEKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tHEKHO);
        }

        // GET: TheKho_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEKHO tHEKHO = db.THEKHO.Find(id);
            if (tHEKHO == null)
            {
                return HttpNotFound();
            }
            return View(tHEKHO);
        }

        // POST: TheKho_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCF,LoaiCF,SoLuong,DVT,DonGia")] THEKHO tHEKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tHEKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tHEKHO);
        }

        // GET: TheKho_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            THEKHO tHEKHO = db.THEKHO.Find(id);
            if (tHEKHO == null)
            {
                return HttpNotFound();
            }
            return View(tHEKHO);
        }

        // POST: TheKho_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            THEKHO tHEKHO = db.THEKHO.Find(id);
            db.THEKHO.Remove(tHEKHO);
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
