using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee_Portal_Test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Data.OleDb;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Drawing.Text;
using System.Security.Cryptography.X509Certificates;
using Google.Protobuf.WellKnownTypes;

namespace Employee_Portal_Test.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly bcckContext _context;

        public AdminController(bcckContext context)
        {
            _context = context;
        }

        // GET: Pmasts
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pmast.ToListAsync());
        }


        // GET: Employee/Create
        [Authorize(Roles = "Admin")]
        public IActionResult AddOrEdit(int id = 0)
        {
            if (Convert.ToString(id) == "0")
            {
                return View(new Pmast());

            }

            else
            {
                return View(_context.Pmast.Find(Convert.ToString(id)));

            }
        }


        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrEdit([Bind("Empno,EmpCode,Name,Iname,Add1,Add2,Dbirth,Nric,Passport,Phone,Phone2,Mstatus,National,Race,Relcode,Itaxno,Epfno,Bankcode,Bankaccno,Deptcode")] Pmast pmast)
        {


            _context.Add(pmast);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            // return View(pmast);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult EditOnly(int id = 0)
        {
            if (Convert.ToString(id) == "0")
            {
                return View(new Pmast());
            }
            else

            {
                // await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return View(_context.Pmast.Find(Convert.ToString(id)));

            }
        }


        // POST: Employee/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditOnly([Bind("id,Empno,Empno,EmpCode,Name,Iname,Add1,Add2,Dbirth,Nric,Passport,Phone,Phone2,Mstatus,National,Race,Relcode,Itaxno,Epfno,Bankcode,Bankaccno,Deptcode")] Pmast pmast)
        {

            _context.Update(pmast);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            // return View(pmast);
        }



        // GET: Employee/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(String id)
        {
            var employee = await _context.Pmast.FindAsync(id);
            _context.Pmast.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        
        
    }
}