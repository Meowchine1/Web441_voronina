﻿using Microsoft.AspNetCore.Mvc;
using WebMSSQL.Models;

namespace WebMSSQL.Controllers
{
    public class StartController : Controller
    {

        public IActionResult Login() 
        {
            return View("Startup");
        }

        public IActionResult Autorization() 
        {
            return View();
        }

    
       
    }
}
