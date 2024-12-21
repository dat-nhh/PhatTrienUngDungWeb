using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_63133655.Controllers
{
    public class GioiThieu_63133655Controller : Controller
    {
        // GET: GioiThieu_63133655
        public ActionResult Index()
        {
            if (Session["HoTen"] == null || Session["HoTen"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "QuanTri_63133655");
            }
            else
                return View();
        }
    }
}