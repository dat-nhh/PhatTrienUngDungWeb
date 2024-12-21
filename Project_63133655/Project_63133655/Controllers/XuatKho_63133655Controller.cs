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
    public class XuatKho_63133655Controller : Controller
    {
        private Project_63133655Entities db = new Project_63133655Entities();

        // GET: XuatKho_63133655
        public ActionResult Index()
        {
            var xUATKHO = db.XUATKHO.Include(x => x.NHANVIEN);
            return View(xUATKHO.ToList());
        }
        [HttpPost]
        public ActionResult Index(string SoPhieuXuat)
        {
            var timXUATKHO = db.XUATKHO.SqlQuery("exec TIMKIEM_XUATKHO '" + SoPhieuXuat + "' ");
            return View(timXUATKHO.ToList());
        }

        // GET: XuatKho_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUATKHO xUATKHO = db.XUATKHO.Find(id);
            string fSave = Server.MapPath("/saveID.txt");
            string[] soID = { xUATKHO.SoPhieuXuat };
            System.IO.File.WriteAllLines(fSave, soID);
            if (xUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(xUATKHO);
        }

        // GET: XuatKho_63133655/Create
        public ActionResult Create()
        {
            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV");
            return View();
        }

        // POST: XuatKho_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SoPhieuXuat,NgayXuat,MaNV,TenNgNhan,DiaChi,SDT")] XUATKHO xUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.XUATKHO.Add(xUATKHO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV", xUATKHO.MaNV);
            return View(xUATKHO);
        }

        // GET: XuatKho_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUATKHO xUATKHO = db.XUATKHO.Find(id);
            if (xUATKHO == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV", xUATKHO.MaNV);
            return View(xUATKHO);
        }

        // POST: XuatKho_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SoPhieuXuat,NgayXuat,MaNV,TenNgNhan,DiaChi,SDT")] XUATKHO xUATKHO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(xUATKHO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV = new SelectList(db.NHANVIEN, "MaNV", "HoNV", xUATKHO.MaNV);
            return View(xUATKHO);
        }

        // GET: XuatKho_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            XUATKHO xUATKHO = db.XUATKHO.Find(id);
            if (xUATKHO == null)
            {
                return HttpNotFound();
            }
            return View(xUATKHO);
        }

        // POST: XuatKho_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            XUATKHO xUATKHO = db.XUATKHO.Find(id);
            db.XUATKHO.Remove(xUATKHO);
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
