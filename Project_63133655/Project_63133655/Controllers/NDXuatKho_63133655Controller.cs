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
    public class NDXuatKho_63133655Controller : Controller
    {
        private Project_63133655Entities db = new Project_63133655Entities();

        // GET: NDXuatKho_63133655
        public ActionResult Index(string SoPhieuXuat)
        {
            string[] soID = System.IO.File.ReadAllLines(Server.MapPath("~/saveID.txt"));
            SoPhieuXuat = soID[0];
            var locNDXUATKHO = db.NDXUATKHO.SqlQuery("exec LOC_NDXUATKHO '" + SoPhieuXuat + "' ");
            return View(locNDXUATKHO.ToList());
        }

        // GET: NDXuatKho_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDXUATKHO nDXUATKHO = db.NDXUATKHO.Find(id);
            if (nDXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(nDXUATKHO);
        }

        // GET: NDXuatKho_63133655/Create
        public ActionResult Create()
        {
            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF");
            ViewBag.SoPhieuXuat = new SelectList(db.XUATKHO, "SoPhieuXuat", "MaNV");
            return View();
        }

        // POST: NDXuatKho_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuXuat,MaCF,LoaiCF,SoLuong,DVT")] NDXUATKHO nDXUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.NDXUATKHO.Add(nDXUATKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF", nDXUATKHO.MaCF);
            ViewBag.SoPhieuXuat = new SelectList(db.XUATKHO, "SoPhieuXuat", "MaNV", nDXUATKHO.SoPhieuXuat);
            return View(nDXUATKHO);
        }

        // GET: NDXuatKho_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDXUATKHO nDXUATKHO = db.NDXUATKHO.Find(id);
            if (nDXUATKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF", nDXUATKHO.MaCF);
            ViewBag.SoPhieuXuat = new SelectList(db.XUATKHO, "SoPhieuXuat", "MaNV", nDXUATKHO.SoPhieuXuat);
            return View(nDXUATKHO);
        }

        // POST: NDXuatKho_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuXuat,MaCF,LoaiCF,SoLuong,DVT")] NDXUATKHO nDXUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nDXUATKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCF = new SelectList(db.THEKHO, "MaCF", "LoaiCF", nDXUATKHO.MaCF);
            ViewBag.SoPhieuXuat = new SelectList(db.XUATKHO, "SoPhieuXuat", "MaNV", nDXUATKHO.SoPhieuXuat);
            return View(nDXUATKHO);
        }

        // GET: NDXuatKho_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NDXUATKHO nDXUATKHO = db.NDXUATKHO.Find(id);
            if (nDXUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(nDXUATKHO);
        }

        // POST: NDXuatKho_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NDXUATKHO nDXUATKHO = db.NDXUATKHO.Find(id);
            db.NDXUATKHO.Remove(nDXUATKHO);
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
