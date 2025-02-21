using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace PhatTrienPMQL2425K2.Controllers
{
    public class GradeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(GradeModel model)
        {
            double diemTong = model.TinhDiemTong();
            ViewBag.DiemTong = diemTong;
            return View();
        }
    }
}
