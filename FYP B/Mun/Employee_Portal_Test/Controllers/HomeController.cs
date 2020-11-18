using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Employee_Portal_Test.Models;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Text;
//added
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Employee_Portal_Test.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Employee_Portal_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Employee_Portal_TestUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        //added
        private readonly IWebHostEnvironment _iwebhost;
        private readonly bcckContext _context;
        //added

        public HomeController(ILogger<HomeController> logger, bcckContext context, IWebHostEnvironment iwebhost, UserManager<Employee_Portal_TestUser> userManager)
        {
            _logger = logger;
            //added
            _context = context;
            _iwebhost = iwebhost;
            //added
            _userManager = userManager;
        }

        public IActionResult Index()
        {
           //added
            var result = _context.document.ToList();
         
            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        public async Task<IActionResult> Exportubs()
        {
            System.Diagnostics.Process.Start("C:\\Users\\Mun yoo min\\Documents\\GitHub\\FYP_A_Employee_Portal\\Employee_Portal_Test\\DataTransfer\\bin\\Debug\\DataTransfer.exe");

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile ifile, document ic)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            string imgext = Path.GetExtension(ifile.FileName);
            if (imgext == ".jpg" || imgext == ".jpeg" || imgext == ".png")
            {
                var saveimg = Path.Combine(_iwebhost.WebRootPath, "Docimg", ifile.FileName);
                var stream = new FileStream(saveimg, FileMode.Create);
                await ifile.CopyToAsync(stream);
                ic.Empno2 = ifile.FileName;
                ic.docpath = saveimg;
                ic.EMPNO = user.Empno;
                await _context.document.AddAsync(ic);
                await _context.SaveChangesAsync();
                ViewData["Message"] = "save successful";
            }
            else
            {
                ViewData["Message"] = "save failed, must be .jpg/.jpeg/.png";
            }
            return RedirectToAction("Index");
        }

    }
}

