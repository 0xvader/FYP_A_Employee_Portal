using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Employee_Portal_Test.Areas.Identity.Data;
using Employee_Portal_Test.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySqlX.XDevAPI.Relational;
using Microsoft.AspNetCore.Hosting;

namespace Employee_Portal_Test.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        bcckContext db = new bcckContext();
        bcck_tempContext dbt = new bcck_tempContext();
         
        private readonly UserManager<Employee_Portal_TestUser> _userManager;
        //added
        private readonly IWebHostEnvironment _iwebhost;
        private readonly bcckContext _context;
        //added
        public DashboardController(bcckContext context, IWebHostEnvironment iwebhost, UserManager<Employee_Portal_TestUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _iwebhost = iwebhost;
        }
        public IActionResult Dashboard5()
        {
            var data = _userManager.GetUserId(HttpContext.User);

            if (data == null)
            {
                return RedirectToAction("Dashboard1");

            }
            else
            {
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                return View(user);
            }
        }
        public IActionResult Dashboard1()
        {
            var data = _userManager.GetUserId(HttpContext.User);

            if (data == null)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                return View(db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault());
            }
        }
        public IActionResult Dashboard2()
        {
            var data = _userManager.GetUserId(HttpContext.User);

            if (data == null)
            {
                return RedirectToAction("Dashboard1");

            }
            else
            {
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                dynamic model = new ExpandoObject();
                model.Family = db.Family.Where(x => x.Empno == user.Empno);
                model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno);
                model.PmastTemp = dbt.PmastTemp.Where(x => x.Empno == user.Empno);
                model.FamilyTemp = dbt.FamilyTemp.Where(x => x.Empno == user.Empno);

                return View(model);
            }

        }
        public IActionResult View1()
        {
            List<History> list = new List<History>();

            int count = list.GetType().GetGenericArguments()[0].GetProperties().Length;
            return View();
        }
        public IActionResult Edit1(string Empno, Pmast Pmast, PmastTempTemp tem)
        {
            var data = _userManager.GetUserId(HttpContext.User);

            if (data == null)
            {
                return RedirectToAction("Dashboard1");

            }
            else
            {

                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                return View(db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault());
            }
        }

        //...
        [HttpPost]
        public IActionResult Edit1(Pmast Pmast, PmastTemp PmastTemp, string empno, PmastTempTemp tem)
        {
            //copy
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            //copy
            db.Entry(Pmast).State = EntityState.Modified;
           // dbt.Entry(tem).State = EntityState.Modified;
            dbt.Entry(PmastTemp).State = EntityState.Modified;
            var k = dbt.PmastTemp.Where(x => x.Empno == user.Empno).AsNoTracking();
            var j = dbt.PmastTempTemp.Where(x => x.Empno == user.Empno).AsNoTracking();
            HttpContext.Session.SetString("Session01", @PmastTemp.Add1);
            HttpContext.Session.SetString("Session1", @Pmast.Add1);
            HttpContext.Session.SetString("Session2", @Pmast.Add2);
            HttpContext.Session.SetString("Session3", @Pmast.Postcode);
            HttpContext.Session.SetString("Session4", @Pmast.Town);
            HttpContext.Session.SetString("Session5", @Pmast.State);
            HttpContext.Session.SetString("Session6", @Pmast.Phone2);
            HttpContext.Session.SetString("Session7", @Pmast.Mstatus);
            HttpContext.Session.SetString("Session8", @Pmast.Relcode);
            HttpContext.Session.SetString("Session9", @Pmast.Itaxno);
            if (k == null)
            {
                PmastTemp newEm = new PmastTemp();
                //
                var p = db.Pmast.Where(x => x.Empno == user.Empno).AsNoTracking().FirstOrDefault();
                newEm.Empno = p.Empno;
                newEm.Name = p.Name;
                newEm.Iname = p.Iname;
                newEm.EmpCode = p.EmpCode;
                dbt.PmastTemp.Add(newEm);
                dbt.SaveChangesAsync();
                
                PmastTemp.Add1 = HttpContext.Session.GetString("Session1");
                PmastTemp.Add2 = HttpContext.Session.GetString("Session2");
                PmastTemp.Postcode = HttpContext.Session.GetString("Session3");
                PmastTemp.Town = HttpContext.Session.GetString("Session4");
                PmastTemp.State = HttpContext.Session.GetString("Session5");
                PmastTemp.Phone2 = HttpContext.Session.GetString("Session6");
                PmastTemp.Mstatus = HttpContext.Session.GetString("Session7");
                PmastTemp.Relcode = HttpContext.Session.GetString("Session8");
                PmastTemp.Itaxno = HttpContext.Session.GetString("Session9");
                dbt.SaveChanges();
                History his = new History();
                his.Empno = user.Empno;
                his.Date = DateTime.Now;
                dbt.History.Add(his);
                dbt.SaveChanges();
                BuildEmailTemplate(PmastTemp.Empno, Pmast);
            }
            else
            {                
                PmastTemp.Add1 = HttpContext.Session.GetString("Session1");
                PmastTemp.Add2 = HttpContext.Session.GetString("Session2");
                PmastTemp.Postcode = HttpContext.Session.GetString("Session3");
                PmastTemp.Town = HttpContext.Session.GetString("Session4");
                PmastTemp.State = HttpContext.Session.GetString("Session5");
                PmastTemp.Phone2 = HttpContext.Session.GetString("Session6");
                PmastTemp.Mstatus = HttpContext.Session.GetString("Session7");
                PmastTemp.Relcode = HttpContext.Session.GetString("Session8");
                PmastTemp.Itaxno = HttpContext.Session.GetString("Session9");
                dbt.SaveChanges();
                History his = new History();
                his.Empno = user.Empno;
                his.Date = DateTime.Now;
                dbt.History.Add(his);
                dbt.SaveChanges();
                BuildEmailTemplate(PmastTemp.Empno, Pmast);
            }
            //else if (j == null)
            //{
            //    PmastTempTemp newEm1 = new PmastTempTemp();
            //    var o = db.Pmast.Where(x => x.Empno == user.Empno).AsNoTracking().FirstOrDefault();
            //    newEm1.Empno = o.Empno;
            //    newEm1.Name = o.Name;
            //    newEm1.Iname = o.Iname;
            //    newEm1.EmpCode = o.EmpCode;
            //    dbt.PmastTempTemp.Add(newEm1);

            //}





            //var a = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            //var b = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            //var c = dbt.PmastTempTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();

            //dbt.SaveChanges();

           

            return RedirectToAction("Dashboard1");
        }
         public IActionResult Index()
        {
           //added
            var result = _context.document.ToList();
         
            return View(result);
        }

        public void BuildEmailTemplate(string empno, Pmast Pmast)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;

            


            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text.cshtml";
                    string id = "";
            
            if (user.Dept == "1")
            {
                id = "sevquy@gmail.com";
            }
                    else if(user.Dept == "2")
            {
                id = "ititghj@naver.com";
            }
            else
            {
                id = "sevquy@hotmail.com";
            }
                    string body = System.IO.File.ReadAllText(path);
                    var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();               
                    var url = "https://localhost:44371/" + "Dashboard/Confirm?";
                    body = body.Replace("@ViewBag.ConfirmationLink", url);
                    body = body.ToString();
                    BuildEmailTemplate("EMPLOYEE SEND THE REQUEST TO EDIT", body, id);
                
            }

            [HttpPost]
            public JsonResult RegisterConfirm(string empno, PmastTemp PmastTemp)
            {
           
                var data = _userManager.GetUserId(HttpContext.User);

                
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
                PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
                Data.Add1 = Datat.Add1;
                Data.Add2 = Datat.Add2;
                Data.Postcode = Datat.Postcode;
                Data.Town = Datat.Town;
                Data.State = Datat.State;
                Data.Phone2 = Datat.Phone2;
                Data.Mstatus = Datat.Mstatus;
                Data.Relcode = Datat.Relcode;
                Data.Itaxno = Datat.Itaxno;
                Data.Name = Datat.Name;
                db.SaveChanges();
                var msg = "Successfully Edited!";
                BuildEmailTemplate4(PmastTemp.Empno);
                return Json(msg);
            }

            public ActionResult Confirm(string empno, Pmast Pmast, PmastTemp PmastTemp)
            {
            
                var data = _userManager.GetUserId(HttpContext.User);

              
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                dynamic model = new ExpandoObject();
                model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno);
                model.PmastTemp = dbt.PmastTemp.Where(x => x.Empno == user.Empno);

                return View(model);

            }

            public static void BuildEmailTemplate(string subjectText, string bodyText, string id)
            {
            
            
            string from, to, bcc, cc, subject, body;
                from = "sevquy@gmail.com";
                  to = id.Trim();
                bcc = "";
                cc = "";
                subject = subjectText;
                StringBuilder sb = new StringBuilder();
                sb.Append(bodyText);
                body = sb.ToString();
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(new MailAddress(to));
                if (!string.IsNullOrEmpty(bcc))
                {
                    mail.Bcc.Add(new MailAddress(bcc));
                }
                if (!string.IsNullOrEmpty(cc))
                {
                    mail.CC.Add(new MailAddress(cc));
                }
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SendEmail(mail);
            }

            public static void SendEmail(MailMessage mail)
            {
                {
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.gmail.com";
                    client.Port = 587;
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "bsm931208");
                    try
                    {
                        client.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        public JsonResult RegisterConfirm1(string empno, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            Data.Add1 = Datat.Add1;
            Data.Add2 = Datat.Add2;
            Data.Postcode = Datat.Postcode;
            Data.Town = Datat.Town;
            Data.State = Datat.State;
            Data.Phone2 = Datat.Phone2;
            Data.Mstatus = Datat.Mstatus;
            Data.Relcode = Datat.Relcode;
            Data.Itaxno = Datat.Itaxno;
            Data.Name = Datat.Name;
            BuildEmailTemplate1(PmastTemp.Empno);
            BuildEmailTemplate1_2(PmastTemp.Empno);

            var msg = "APPROVED";
            return Json(msg);
        }

        public void BuildEmailTemplate1_2(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text4.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm1?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate1_2("HOD Approved THE REQUEST TO EDIT", body);
        }

        public static void BuildEmailTemplate1_2(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }



        public JsonResult RegisterConfirm1_1(string empno, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            Data.Add1 = Datat.Add1;
            Data.Add2 = Datat.Add2;
            Data.Postcode = Datat.Postcode;
            Data.Town = Datat.Town;
            Data.State = Datat.State;
            Data.Phone2 = Datat.Phone2;
            Data.Mstatus = Datat.Mstatus;
            Data.Relcode = Datat.Relcode;
            Data.Itaxno = Datat.Itaxno;
            Data.Name = Datat.Name;
            BuildEmailTemplate1_1(PmastTemp.Empno);
            var msg = "Rejected";
            return Json(msg);
        }

        public void BuildEmailTemplate1_1(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text3.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm1?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate1_1("HR REJECT THE REQUEST TO EDIT", body);
        }

        public static void BuildEmailTemplate1_1(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }




        public void BuildEmailTemplate1(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm1?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate1("HOD SEND THE REQUEST TO EDIT", body);
        }

        public static void BuildEmailTemplate1(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }

        public ActionResult Confirm1(string empno, Pmast Pmast, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            dynamic model = new ExpandoObject();
            model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno);
            model.PmastTemp = dbt.PmastTemp.Where(x => x.Empno == user.Empno);

            return View(model);

        }

        public JsonResult RegisterConfirm_1(string empno, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            Data.Add1 = Datat.Add1;
            Data.Add2 = Datat.Add2;
            Data.Postcode = Datat.Postcode;
            Data.Town = Datat.Town;
            Data.State = Datat.State;
            Data.Phone2 = Datat.Phone2;
            Data.Mstatus = Datat.Mstatus;
            Data.Relcode = Datat.Relcode;
            Data.Itaxno = Datat.Itaxno;
            Data.Name = Datat.Name;
            BuildEmailTemplate_1(PmastTemp.Empno);


            var msg = "Rejected";
            return Json(msg);
        }

        public void BuildEmailTemplate_1(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text5.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm1?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate_1("HOD Reject THE REQUEST TO EDIT", body);
        }

        public static void BuildEmailTemplate_1(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }



        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public IActionResult Edit2(string Empno, Pmast Pmast, PmastTempTemp tem)
        {
            using (var db6 = new bcckContext())
            {
                var data = _userManager.GetUserId(HttpContext.User);
                Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
                return View(db6.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault());
            }

        }
        //...
        [HttpPost]
        public IActionResult Edit2(string Empno, Pmast Pmast, PmastTemp Pmastemp, Family family, FamilyTemp familytem)
        {

            db.Entry(Pmast).State = EntityState.Modified;
            dbt.Entry(Pmastemp).State = EntityState.Modified;
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            HttpContext.Session.SetString("Session11", @Pmast.Econtact);
            HttpContext.Session.SetString("Session12", @Pmast.Category);
            HttpContext.Session.SetString("Session13", @Pmast.Etelno);
            HttpContext.Session.SetString("Session14", @Pmast.Sname);
            HttpContext.Session.SetString("Session15", @Pmast.Snric);
            var k = dbt.PmastTemp.Where(x => x.Empno == user.Empno).AsNoTracking();

            var j = dbt.PmastTempTemp.Where(x => x.Empno == user.Empno).AsNoTracking();
            if (k == null)
            {
                PmastTemp newEm = new PmastTemp();
                var p = db.Pmast.Where(x => x.Empno == user.Empno).AsNoTracking().FirstOrDefault();
                newEm.Empno = p.Empno;
                newEm.Name = p.Name;
                newEm.Iname = p.Iname;
                newEm.EmpCode = p.EmpCode;
                dbt.PmastTemp.Add(newEm);
                dbt.SaveChangesAsync();
                Pmastemp.Econtact = HttpContext.Session.GetString("Session11");
                Pmastemp.Category = HttpContext.Session.GetString("Session12");
                Pmastemp.Etelno = HttpContext.Session.GetString("Session13");
                Pmastemp.Sname = HttpContext.Session.GetString("Session14");
                Pmastemp.Snric = HttpContext.Session.GetString("Session15");
                dbt.SaveChanges();
                History his = new History();
                his.Empno = user.Empno;
                his.Date = DateTime.Now;
                dbt.History.Add(his);
                dbt.SaveChanges();
                BuildEmailTemplate2(Pmastemp.Empno);
            }
            else
            {
                Pmastemp.Econtact = HttpContext.Session.GetString("Session11");
                Pmastemp.Category = HttpContext.Session.GetString("Session12");
                Pmastemp.Etelno = HttpContext.Session.GetString("Session13");
                Pmastemp.Sname = HttpContext.Session.GetString("Session14");
                Pmastemp.Snric = HttpContext.Session.GetString("Session15");
                dbt.SaveChanges();
                History his = new History();
                his.Empno = user.Empno;
                his.Date = DateTime.Now;
                dbt.History.Add(his);
                dbt.SaveChanges();
                BuildEmailTemplate2(Pmastemp.Empno);
            }


            return RedirectToAction("Dashboard2");


        }

        public void BuildEmailTemplate2(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            string id = "";
            if (user.Dept == "1")
            {
                id = "sevquy@gmail.com";
            }
            else if (user.Dept == "2")
            {
                id = "ititghj@naver.com";
            }
            else
            {
                id = "sevquy@hotmail.com";
            }
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm2?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate2("EMPLOYEEE SEND THE REQUEST FOR EDIT", body, id);
        }

        [HttpPost]
        public JsonResult RegisterConfirm2(string empno, PmastTemp Pmastemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();

            var msg = "APPROVED";
            BuildEmailTemplate3(Pmastemp.Empno);
            BuildEmailTemplate3_2(Pmastemp.Empno);
            return Json(msg);
        }
        public JsonResult RegisterConfirm2_1(string empno, PmastTemp Pmastemp, Pmast Pmast)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();

            var msg = "Rejected";
            BuildEmailTemplate3_1(Pmastemp.Empno, Pmast);
            return Json(msg);
        }
        public void BuildEmailTemplate3_1(string empno, Pmast Pmast)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text5.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm3?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            string id;
            if (user.Empno == Pmast.Empno && Pmast.Deptcode == "1")
            {
                id = "sevquy@hotmail.com";
            }
            else
            {
                id = "ititghj@naver.com";
            }
            BuildEmailTemplate_1("HOD Reject your request", body);
        }

        public static void BuildEmailTemplate3_1(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail3 = new MailMessage();
            mail3.From = new MailAddress(from);
            mail3.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail3.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail3.CC.Add(new MailAddress(cc));
            }
            mail3.Subject = subject;
            mail3.Body = body;
            mail3.IsBodyHtml = true;
            SendEmail3(mail3);
        }
        public void BuildEmailTemplate3_2(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text4.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm3?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate1("HOD Approved your request", body);
        }

        public static void BuildEmailTemplate3_2(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail3 = new MailMessage();
            mail3.From = new MailAddress(from);
            mail3.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail3.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail3.CC.Add(new MailAddress(cc));
            }
            mail3.Subject = subject;
            mail3.Body = body;
            mail3.IsBodyHtml = true;
            SendEmail3(mail3);
        }

        public ActionResult Confirm2(string empno, Pmast Pmast, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            dynamic model = new ExpandoObject();
            model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno);
            model.PmastTemp = dbt.PmastTemp.Where(x => x.Empno == user.Empno);

            return View(model);

        }

        public static void BuildEmailTemplate2(string subjectText, string bodyText, string id)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = id.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail2(mail);
        }

        public static void SendEmail2(MailMessage mail)
        {
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "bsm931208");
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }



        public void BuildEmailTemplate3(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var url = "https://localhost:44371/" + "Dashboard/Confirm3?";
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate1("HOD SEND THE REQUEST FOR EDIT", body);
        }

        public static void BuildEmailTemplate3(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail3 = new MailMessage();
            mail3.From = new MailAddress(from);
            mail3.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail3.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail3.CC.Add(new MailAddress(cc));
            }
            mail3.Subject = subject;
            mail3.Body = body;
            mail3.IsBodyHtml = true;
            SendEmail3(mail3);
        }
        public static void SendEmail3(MailMessage mail)
        {
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "bsm931208");
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public ActionResult Confirm3(string empno, Pmast Pmast, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            dynamic model = new ExpandoObject();
            model.Pmast = db.Pmast.Where(x => x.Empno == user.Empno);
            model.PmastTemp = dbt.PmastTemp.Where(x => x.Empno == user.Empno);

            return View(model);

        }

        public JsonResult RegisterConfirm3(string empno, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            Data.Econtact = Datat.Econtact;
            Data.Category = Datat.Category;
            Data.Etelno = Datat.Etelno;
            Data.Sname = Datat.Sname;
            Data.Snric = Datat.Snric;
            db.SaveChanges();
            BuildEmailTemplate4(PmastTemp.Empno);
            var msg = "Successfully Edited!";
            return Json(msg);
        }
        public JsonResult RegisterConfirm3_1(string empno, PmastTemp PmastTemp)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            Pmast Data = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            PmastTemp Datat = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            BuildEmailTemplate4_1(PmastTemp.Empno);
            var msg = "REJECTED";
            return Json(msg);
        }
        public void BuildEmailTemplate4(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text2.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            body = body.ToString();
            
            BuildEmailTemplate4("HR APPROVED THE REQUEST TO EDIT", body);
        }

        public static void BuildEmailTemplate4(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail4 = new MailMessage();
            mail4.From = new MailAddress(from);
            mail4.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail4.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail4.CC.Add(new MailAddress(cc));
            }
            mail4.Subject = subject;
            mail4.Body = body;
            mail4.IsBodyHtml = true;
            SendEmail4(mail4);
        }
        public static void SendEmail4(MailMessage mail)
        {
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "bsm931208");
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void BuildEmailTemplate4_1(string empno)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var path = @"C:/Users/sevqu/Documents/GitHub/FYP_A_Employee_Portal/Employee_Portal_Test/Employee_Portal_Test/Views/Dashboard/Text3.cshtml";
            string body = System.IO.File.ReadAllText(path);
            var regInfo = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            body = body.ToString();

            BuildEmailTemplate1_1("HR REJECT THE REQUEST TO EDIT", body);
        }

        public static void BuildEmailTemplate4_1(string subjectText, string bodyText)
        {
            string from, to, bcc, cc, subject, body;
            from = "sevquy@gmail.com";
            to = "sevquy@gmail.com";
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail4 = new MailMessage();
            mail4.From = new MailAddress(from);
            mail4.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail4.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail4.CC.Add(new MailAddress(cc));
            }
            mail4.Subject = subject;
            mail4.Body = body;
            mail4.IsBodyHtml = true;
            SendEmail4_1(mail4);
        }
        public static void SendEmail4_1(MailMessage mail)
        {
            {
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "bsm931208");
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
     



    }

    } 

