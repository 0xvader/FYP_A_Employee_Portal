using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminPanel4.Models;

namespace AdminPanel4.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            using (DBModels db = new DBModels())
            {
                List<pmast> empList = db.pmasts.ToList<pmast>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);


            }
        }

        
        [HttpGet]
        public ActionResult AddOrEdit(String id)
        {
            if(id=="0")
            {
                return View(new pmast());
            }
            else
            {
                using (DBModels db = new DBModels())
                {
                    // return View(db.pmasts.Where(x => Convert.ToInt32(x.EMPNO) == id).FirstOrDefault<pmast>());
                    return View(db.pmasts.Where(x => x.EMPNO == id).FirstOrDefault<pmast>());
                }
            }
        }




        [HttpPost]
        public ActionResult AddOrEdit(pmast emp)
        {
            using (DBModels db = new DBModels())
            {
               
                    db.pmasts.Add(emp);      
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved success" }, JsonRequestBehavior.AllowGet);
                

               
                   

            }

        }
        [HttpGet]
        public ActionResult EditOnly(String id)
        {
            if (id == "0")
            {
                return View(new pmast());
            }
            else
            {
                using (DBModels db = new DBModels())
                {
                    // return View(db.pmasts.Where(x => Convert.ToInt32(x.EMPNO) == id).FirstOrDefault<pmast>());
                    return View(db.pmasts.Where(x => x.EMPNO == id).FirstOrDefault<pmast>());
                }
            }
        }
        [HttpPost]
        public ActionResult EditOnly(pmast emp)
        {
           
            using (DBModels db = new DBModels())
            {

                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Updated Succesfuly " }, JsonRequestBehavior.AllowGet);
            }
            
        }
        
        [HttpPost]
        public ActionResult Delete(String id)
        {
            using (DBModels db = new DBModels())
            {
                pmast emp = db.pmasts.Where(x => x.EMPNO == id).FirstOrDefault<pmast>();
                db.pmasts.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Succesfuly " }, JsonRequestBehavior.AllowGet);
            }
        }
        


    }
}