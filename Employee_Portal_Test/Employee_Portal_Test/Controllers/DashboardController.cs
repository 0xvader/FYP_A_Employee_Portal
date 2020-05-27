using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Portal_Test.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard1()
        {
            return View();
        }
        public IActionResult Dashboard2()
        {
            return View();
        }
        public IActionResult Dashboard3()
        {
            return View();
        }
    }
}
