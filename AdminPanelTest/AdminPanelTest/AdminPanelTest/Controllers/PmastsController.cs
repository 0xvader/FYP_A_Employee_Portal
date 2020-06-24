using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPanelTest.Models;

namespace AdminPanelTest.Controllers
{
    public class PmastsController : Controller
    {
        private readonly bcckContext _context;

        public PmastsController(bcckContext context)
        {
            _context = context;
        }

        // GET: Pmasts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pmast.ToListAsync());
        }


        // GET: Employee/Create

        public IActionResult AddOrEdit(int id=0)
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
          public async Task<IActionResult> AddOrEdit([Bind("Empno,EmpCode,Name,Iname,Add1")] Pmast pmast)
        {
         
                
                 _context.Add(pmast);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           // return View(pmast);
        }


        [HttpGet]
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
        public async Task<IActionResult> EditOnly([Bind("id,Empno,EmpCode,Name,Iname,Add1")] Pmast pmast)
        {
            
                    _context.Update(pmast);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

            
            // return View(pmast);
        }


        
        // GET: Employee/Delete/5

        public async Task<IActionResult> Delete(String id)
        {
            var employee = await _context.Pmast.FindAsync(id);
            _context.Pmast.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
