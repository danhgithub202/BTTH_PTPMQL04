using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class TinhHoaDonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(TinhHoaDonModel model)
        {
            double tongTien = model.TinhTongTien();
            ViewBag.TongTien = tongTien;
            return View();
        }
    }
}
