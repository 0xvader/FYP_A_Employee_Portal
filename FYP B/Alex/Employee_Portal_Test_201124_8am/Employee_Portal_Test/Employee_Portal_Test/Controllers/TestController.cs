using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Employee_Portal_Test.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee_Portal_Test.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace Employee_Portal_Test.Controllers
{
    public class TestController : Controller
    {
        bcckContext db = new bcckContext();
        bcck_tempContext dbt = new bcck_tempContext();
        private readonly UserManager<Employee_Portal_TestUser> _userManager;
        private readonly SignInManager<Employee_Portal_TestUser> _signInManager;


        public TestController(UserManager<Employee_Portal_TestUser> userManager, SignInManager<Employee_Portal_TestUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            ;
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> test()
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;

            return View(await dbt.History.Where(x => x.Hodappr == 0 && x.Deptno == user.Dept).ToListAsync());
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult test2(int id = 0)
        {

            if (Convert.ToString(id) == "0")
            {
                return View(new History());

            }
            else
            {
                /*dynamic model = new ExpandoObject();
                var data = _userManager.GetUserId(HttpContext.User);
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();*/
                return View(dbt.History.Find(Convert.ToInt32(id)));
            }
        }


        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> test2([Bind("id,Id,Empno,Date")] History history, int id)
        {

            var a = dbt.History.Where(x => x.Id == id).FirstOrDefault();
            a.Hodappr = history.Hodappr + 1;
            await dbt.SaveChangesAsync();
            return RedirectToAction(nameof(test));
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> test3([Bind("id,Id,Empno,Date")] History history, int id)
        {

            var a = dbt.History.Where(x => x.Id == id).FirstOrDefault();
            a.Hodappr = history.Hodappr + 1;
            await dbt.SaveChangesAsync();
            return RedirectToAction(nameof(test));
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> test4()
        {

            return View(await dbt.History.Where(x => x.Hrappr == 0 && x.Hodappr == 1).ToListAsync());
        }

        [Authorize(Roles = "Admin")]
        public IActionResult test5(int id = 0)
        {

            if (Convert.ToString(id) == "0")
            {
                return View(new History());

            }
            else
            {
                /*dynamic model = new ExpandoObject();
                var data = _userManager.GetUserId(HttpContext.User);
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();*/
                return View(dbt.History.Find(Convert.ToInt32(id)));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> test5([Bind("id,Id,Empno,Date")] History history, int id)
        {

            var a = dbt.History.Where(x => x.Id == id).FirstOrDefault();
            a.Hrappr = 1;
            var b = a.Empno;
            var c = db.Pmast.Where(x => x.Empno == b).FirstOrDefault();
            c.Add1 = a.Add1;
            c.Add2 = a.Add2;
            c.Postcode = a.Postcode;
            c.Town = a.Town;
            c.State = a.State;
            c.Phone2 = a.Phone;
            c.Mstatus = a.Mstatus;
            c.Relcode = a.Relcode;
            c.Itaxno = a.Itaxno;
            c.Econtact = a.Econtact;
            c.Emerphone = a.EMERPHONE;
            c.Emerrship = a.EMERRSHIP;
            c.Sname = a.Sname;
            c.Snric = a.Snric;
            await db.SaveChangesAsync();
            await dbt.SaveChangesAsync();
            return RedirectToAction(nameof(test4));
        }

        public async Task<IActionResult> test6([Bind("id,Id,Empno,Date")] History history, int id)
        {
            var a = dbt.History.Where(x => x.Id == id).FirstOrDefault();
            a.Hrappr = history.Hrappr + 1;
            await dbt.SaveChangesAsync();
            return RedirectToAction(nameof(test4));
        }


        public JsonResult testL()
        {
            String id = "testp@gmail.com";
            String pd = "126*";
            String id1 = "testp@gmail.com";
            String pd1 = "123456*";
            String id2 = "testp2@gmail.com";
            String pd2 = "123456*";
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var msg = "";
            var msg1 = "";
            var msg3 = "";
            var result = _signInManager.PasswordSignInAsync(id, pd, true, lockoutOnFailure: false);
            var res1 = _signInManager.PasswordSignInAsync(id1, pd1, true, lockoutOnFailure: false);
            var res2 = _signInManager.PasswordSignInAsync(id2, pd2, true, lockoutOnFailure: false);
            if (result.Result.Succeeded)
            {

                msg = " Test ID: testp@gmail.com " + " password: 126* " + " Result: Successful " + "" + "" + "/////////";
                if (res1.Result.Succeeded)
                {
                    msg1 = " Test ID: testp@gmail.com" + " password: 123456*" + " Result: Successful";
                }
                else
                {
                    msg1 = " Test ID: testp@gmail.com" + " password: 123456*" + " Result: Failed";
                }
            
            }
            else
            {
                msg = " Test ID: testp@gmail.com " + "password: 126* " + " Result: Failed " + "" +
                    "" +
                    "/////";
                if (res1.Result.Succeeded)
                {
                    msg1 = " Test ID: testp@gmail.com" + " password: 123456*" + " Result: Successful";
                }
                else
                {
                    msg1 = " Test ID: testp@gmail.com" + " password: 123456*" + " Result: Failed";
                }
              
            }
            msg3 = msg + msg1;
            return Json(msg3);

        }

    }
}
