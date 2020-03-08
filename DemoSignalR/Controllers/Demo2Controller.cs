using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoSignalR.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoSignalR.Controllers
{
    public class Demo2Controller : Controller
    {

        private readonly PreguntasService preguntasService;


        public Demo2Controller(PreguntasService preguntasService)
        {
            this.preguntasService = preguntasService;
        }


        public IActionResult Index()
        {
            return View(preguntasService.SiguientePregunta().GetAwaiter().GetResult());
        }

    }
}