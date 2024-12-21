using System.Web.Mvc;
using BaiTap2_63133655.Models;

namespace BaiTap2_63133655.Controllers
{
    public class SinhVien_63133655Controller : Controller
    {
        // GET: SinhVien_63133655
        public ActionResult Index()
        {
            return View();
        }
        //Request
        public ActionResult ReqIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReqRegister()
        {
            ViewBag.Id = Request["Id"];
            ViewBag.Name = Request["Name"];
            ViewBag.Marks = Request["Marks"];
            return View(ViewBag);
        }
        //Action
        public ActionResult ArgIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ArgRegister(string id, string name, string marks)
        {
            ViewBag.Id = id;
            ViewBag.Name = name;
            ViewBag.Marks = marks;
            return View(ViewBag);
        }
        //FormCollection
        public ActionResult FormIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FormRegister(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return View(ViewBag);
        }
        //Models
        public ActionResult ModelsIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ModelsRegister(SVModels sv)
        {
            ViewBag.Id = sv.id;
            ViewBag.Name = sv.name;
            ViewBag.Marks = sv.marks;
            return View(ViewBag);
        }
    }
}