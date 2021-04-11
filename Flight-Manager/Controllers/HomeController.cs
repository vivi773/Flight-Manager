﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Flight_Manager.Data;
using Flight_Manager.Models;

namespace Flight_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected ApplicationDbContext mcontext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            mcontext = context;
            _logger = logger;
        }

       
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {   
            return View();
        }

        //public IActionResult Create()
        //{
          //  return View();
        //}


        //[Authorize(Roles = "Admin")]
        //public IActionResult Reservation()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
