using Microsoft.AspNetCore.Mvc;

namespace DemoSignalR.Controllers
{
    public class Demo1Controller : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

    }
}