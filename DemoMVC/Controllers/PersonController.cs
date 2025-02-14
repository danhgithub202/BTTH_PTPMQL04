using MvcMovie.Models;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
    
    [HttpPost]
    public IActionResult Index(Person ps)
    {
        string StrOutput = "Xin chào" + ps.PersonId + "-" + ps.Fullname + "-" + ps.Address;
        ViewBag.Message = StrOutput;
        return View();
    }
    }


}