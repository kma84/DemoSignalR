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

        private readonly PreguntasService preguntasService;


        public Demo1Controller(PreguntasService preguntasService)
        {
            this.preguntasService = preguntasService;
        }


        public IActionResult Index()
        {
            return View(preguntasService.SiguientePregunta().GetAwaiter().GetResult());
        }
    }
}