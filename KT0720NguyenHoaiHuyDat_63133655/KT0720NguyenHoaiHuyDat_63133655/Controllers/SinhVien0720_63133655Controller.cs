using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using KT0720NguyenHoaiHuyDat_63133655.Models;

namespace KT0720NguyenHoaiHuyDat_63133655.Controllers
{
    public class SinhVien0720_63133655Controller : Controller
    {
        private KT0720_63133655Entities db = new KT0720_63133655Entities();

        // GET: SinhVien0720_63133655
        public ActionResult Index()
        {
            var sINHVIEN = db.SINHVIEN.Include(s => s.LOP);
            return View(sINHVIEN.ToList());
        }

        // GET: SinhVien0720_63133655/Details/5
        public ActionResult Details(string id)
        {    
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIEN.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // GET: SinhVien0720_63133655/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop");
            return View();
        }

        // POST: SinhVien0720_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SINHVIEN sINHVIEN)
        {
            var imgNV = Request.Files["Avatar"];
            //Lấy thông tin từ input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
            //Lưu hình đại diện về Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgNV.SaveAs(path);
            if (ModelState.IsValid)
            {
                sINHVIEN.AnhSV = postedFileName;
                db.SINHVIEN.Add(sINHVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop", sINHVIEN.MaLop);
            return View(sINHVIEN);
        }

        // GET: SinhVien0720_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIEN.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop", sINHVIEN.MaLop);
            return View(sINHVIEN);
        }

        // POST: SinhVien0720_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,HoSV,TenSV,NgaySinh,GioiTinh,AnhSV,DiaChi,MaLop")] SINHVIEN sINHVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sINHVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOP, "MaLop", "TenLop", sINHVIEN.MaLop);
            return View(sINHVIEN);
        }

        // GET: SinhVien0720_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sINHVIEN = db.SINHVIEN.Find(id);
            if (sINHVIEN == null)
            {
                return HttpNotFound();
            }
            return View(sINHVIEN);
        }

        // POST: SinhVien0720_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SINHVIEN sINHVIEN = db.SINHVIEN.Find(id);
            db.SINHVIEN.Remove(sINHVIEN);
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

        public ActionResult GioiThieu_63133655()
        {
            return View();
        }
        public ActionResult TimKiem_63133655()
        {
            var sinhViens = db.SINHVIEN.Include(n => n.LOP);
            return View(sinhViens.ToList());
        }
        [HttpPost]
        public ActionResult TimKiem_63133655(string maSV, string HoTen)
        {

            var sinhViens = db.SINHVIEN.SqlQuery("exec TimKiem_63133655 '" + maSV + "', N'" + HoTen + "' ");
            //var nhanViens = db.NhanViens.SqlQuery("SELECT * FROM NhanVien WHERE MaNV='" + maNV + "'");
            //var nhanViens = db.NhanViens.Where(abc => abc.MaNV == maNV);
            if (sinhViens.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(sinhViens.ToList());
        }
    }
}
