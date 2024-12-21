using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThiGK_63133655.Models;

namespace ThiGK_63133655.Controllers
{
    public class DocGia_63133655Controller : Controller
    {
        private ThiGK_63133655Entities db = new ThiGK_63133655Entities();

        public ActionResult GioiThieu_63133655()
        {
            return View();
        }

        public ActionResult TimKiemDG_63133655()
        {
            var docGias = db.DocGia.Include(n => n.LoaiDG);
            return View(docGias.ToList());
        }
        [HttpPost]
        public ActionResult TimKiemDG_63133655(string maDG, string HoTen)
        {

            var docGias = db.DocGia.SqlQuery("exec TimKiem '" + maDG + "', N'" + HoTen + "' ");        
            if (docGias.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(docGias.ToList());
        }

        // GET: DocGia_63133655
        public ActionResult Index()
        {
            var docGia = db.DocGia.Include(d => d.LoaiDG);
            return View(docGia.ToList());
        }

        // GET: DocGia_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGia.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // GET: DocGia_63133655/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDG = new SelectList(db.LoaiDG, "MaLoaiDG", "TenLoaiDG");
            return View();
        }

        // POST: DocGia_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDG")] DocGia docGia)
        {
            var imgDG = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgDG.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgDG.SaveAs(path);
            if (ModelState.IsValid)
            {
                docGia.AnhDG = postedFileName;
                db.DocGia.Add(docGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDG = new SelectList(db.LoaiDG, "MaLoaiDG", "TenLoaiDG", docGia.MaLoaiDG);
            return View(docGia);
        }

        // GET: DocGia_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGia.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDG = new SelectList(db.LoaiDG, "MaLoaiDG", "TenLoaiDG", docGia.MaLoaiDG);
            return View(docGia);
        }

        // POST: DocGia_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,HoDG,TenDG,NgaySinh,GioiTinh,Email,AnhDG,MaLoaiDG")] DocGia docGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(docGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDG = new SelectList(db.LoaiDG, "MaLoaiDG", "TenLoaiDG", docGia.MaLoaiDG);
            return View(docGia);
        }

        // GET: DocGia_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocGia docGia = db.DocGia.Find(id);
            if (docGia == null)
            {
                return HttpNotFound();
            }
            return View(docGia);
        }

        // POST: DocGia_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DocGia docGia = db.DocGia.Find(id);
            db.DocGia.Remove(docGia);
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
