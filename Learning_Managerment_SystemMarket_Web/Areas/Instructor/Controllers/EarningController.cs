﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Web.Areas.Instructor.Controllers
{
    public class EarningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}