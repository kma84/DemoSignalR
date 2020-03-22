using Microsoft.AspNetCore.Mvc;

namespace DemoSignalR.Controllers
{
    public class Demo2Controller : Controller
    {
               
        public IActionResult Index()
        {
            return View();
        }

    }
}