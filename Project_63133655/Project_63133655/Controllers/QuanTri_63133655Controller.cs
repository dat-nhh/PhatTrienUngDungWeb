using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Project_63133655.Models;

namespace Project_63133655.Controllers
{
    public class QuanTri_63133655Controller : Controller
    {
        private Project_63133655Entities db = new Project_63133655Entities();

        // GET: QuanTri_63133655
        public bool CheckUser(string username, string password)
        {
            var kq = db.QuanTri.Where(x => x.Email == username && x.Password == password).ToList();
            //string hoTen = kq.First().HoTen;
            if (kq.Count() > 0)
            {
                Session["HoTen"] = kq.First().HoTen;
                return true;
            }
            else
            {
                Session["HoTen"] = null;
                return false;
            }
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(QuanTri qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(qt.Email, qt.Password))
                {
                    FormsAuthentication.SetAuthCookie(qt.Email, true);
                    return RedirectToAction("Index", "GioiThieu_63133655/Index");
                }
                else
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản không đúng.");
            }
            return View(qt);
        }
        public ActionResult Index()
        {
            return View(db.QuanTri.ToList());
        }

        // GET: QuanTri_63133655/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanTri quanTri = db.QuanTri.Find(id);
            if (quanTri == null)
            {
                return HttpNotFound();
            }
            return View(quanTri);
        }

        // GET: QuanTri_63133655/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuanTri_63133655/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Admin,HoTen,Password")] QuanTri quanTri)
        {
            if (ModelState.IsValid)
            {
                db.QuanTri.Add(quanTri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quanTri);
        }

        // GET: QuanTri_63133655/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanTri quanTri = db.QuanTri.Find(id);
            if (quanTri == null)
            {
                return HttpNotFound();
            }
            return View(quanTri);
        }

        // POST: QuanTri_63133655/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Admin,HoTen,Password")] QuanTri quanTri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanTri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanTri);
        }

        // GET: QuanTri_63133655/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanTri quanTri = db.QuanTri.Find(id);
            if (quanTri == null)
            {
                return HttpNotFound();
            }
            return View(quanTri);
        }

        // POST: QuanTri_63133655/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanTri quanTri = db.QuanTri.Find(id);
            db.QuanTri.Remove(quanTri);
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
