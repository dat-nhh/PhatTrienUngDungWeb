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
    public class NhapKho_63133655Controller : Controller
    {
        private Project_63133655Entities db = new Project_63133655Entities();

        // GET: NhapKho_63133655
        public ActionResult Index()
        {
            var nHAPKHO = db.NHAPKHO.Include(n => n.NHANVIEN);
            return View(nHAPKHO.ToList());
        }
        [HttpPost]
        public ActionResult Index(string SoPhieuNhap)
        {
            var timNHAPKHO = db.NHAPKHO.SqlQuery("exec TIMKIEM_NHAPKHO '" + SoPhieuNhap + "' ");
            return View(timNHAPKHO.ToList());
        }

        // GET: NhapKho_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAPKHO nHAPKHO = db.NHAPKHO.Find(id);
            string fSave = Server.MapPath("/saveID.txt");
            string[] soID = { nHAPKHO.SoPhieuNhap };
            System.IO.File.WriteAllLines(fSave, soID);
            if (nHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nHAPKHO);
        }

        // GET: NhapKho_63133655/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV");
            return View();
        }

        // POST: NhapKho_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuNhap,NgayNhap,MaNV")] NHAPKHO nHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.NHAPKHO.Add(nHAPKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV", nHAPKHO.MaNV);
            return View(nHAPKHO);
        }

        // GET: NhapKho_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAPKHO nHAPKHO = db.NHAPKHO.Find(id);
            if (nHAPKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV", nHAPKHO.MaNV);
            return View(nHAPKHO);
        }

        // POST: NhapKho_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuNhap,NgayNhap,MaNV")] NHAPKHO nHAPKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nHAPKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV", nHAPKHO.MaNV);
            return View(nHAPKHO);
        }

        // GET: NhapKho_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NHAPKHO nHAPKHO = db.NHAPKHO.Find(id);
            if (nHAPKHO == null)
            {
                return HttpNotFound();
            }
            return View(nHAPKHO);
        }

        // POST: NhapKho_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NHAPKHO nHAPKHO = db.NHAPKHO.Find(id);
            db.NHAPKHO.Remove(nHAPKHO);
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
