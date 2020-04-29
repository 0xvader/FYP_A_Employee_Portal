using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using EmployeePortal.Models;
using System.Linq;

namespace EmployeePortal
{
    public class AccountController : Controller
    {
        bcckContext db = new bcckContext();
        public IActionResult Login()
        {
            return View();
        }
        public ActionResult Validate(Pmast pmast)
        {
            var _pmast = db.Pmast.Where(s => s.Empno == pmast.Empno);
            if (_pmast.Any())
            {
                if (_pmast.Where(s => s.Emppass == pmast.Emppass).Any())
                {

                    return Json(new { status = true, message = "Login Successfull!" });
                }
                else
                {
                    return Json(new { status = false, message = "Invalid Password!" });
                }
            }
            else
            {
                return Json(new { status = false, message = "Invalid Email!" });
            }
        }
    }

    

}