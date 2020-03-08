using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSignalR.Services;
using Microsoft.AspNetCore.Mvc;
using DemoSignalR.Models;

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