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
    public class NDNhapKho_63133655Controller : Controller
    {
        private Project_63133655Entities db = new Project_63133655Entities();

        // GET: NDNhapKho_63133655
        public ActionResult Index(string SoPhieuNhap)
        {
            string[] soID = System.IO.File.ReadAllLines(Server.MapPath("~/saveID.txt"));
            SoPhieuNhap = soID[0];
            var locNDNHAPKHO = db.NDNHAPKHO.SqlQuery("exec LOC_NDNHAPKHO '" + SoPhieuNhap + "' ");
            return View(locNDNHAPKHO.ToList());
        }

        // GET: NDNhapKho_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDNHAPKHO nDNHAPKHO = db.NDNHAPKHO.Find(id);
            if (nDNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nDNHAPKHO);
        }

        // GET: NDNhapKho_63133655/Create
        public ActionResult Create()
        {
            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF");
            ViewBag.SoPhieuNhap = new SelectList(db.NHAPKHO, "SoPhieuNhap", "MaNV");
            return View();
        }

        // POST: NDNhapKho_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuNhap,MaCF,LoaiCF,SoLuong,DVT")] NDNHAPKHO nDNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.NDNHAPKHO.Add(nDNHAPKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF", nDNHAPKHO.MaCF);
            ViewBag.SoPhieuNhap = new SelectList(db.NHAPKHO, "SoPhieuNhap", "MaNV", nDNHAPKHO.SoPhieuNhap);
            return View(nDNHAPKHO);
        }

        // GET: NDNhapKho_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDNHAPKHO nDNHAPKHO = db.NDNHAPKHO.Find(id);
            if (nDNHAPKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.SoPhieuNhap = new SelectList(db.NHAPKHO, "SoPhieuNhap", "MaNV", nDNHAPKHO.SoPhieuNhap);
            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF", nDNHAPKHO.MaCF);
            return View(nDNHAPKHO);
        }

        // POST: NDNhapKho_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuNhap,MaCF,LoaiCF,SoLuong,DVT")] NDNHAPKHO nDNHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nDNHAPKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SoPhieuNhap = new SelectList(db.NHAPKHO, "SoPhieuNhap", "MaNV", nDNHAPKHO.SoPhieuNhap);
            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF", nDNHAPKHO.MaCF);
            return View(nDNHAPKHO);
        }

        // GET: NDNhapKho_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDNHAPKHO nDNHAPKHO = db.NDNHAPKHO.Find(id);
            if (nDNHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nDNHAPKHO);
        }

        // POST: NDNhapKho_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NDNHAPKHO nDNHAPKHO = db.NDNHAPKHO.Find(id);
            db.NDNHAPKHO.Remove(nDNHAPKHO);
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
