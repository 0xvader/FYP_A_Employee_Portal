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
using System.IO;

namespace Employee_Portal_Test.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        bcckContext db = new bcckContext();
        bcck_tempContext dbt = new bcck_tempContext();
        private readonly UserManager<Employee_Portal_TestUser> _userManager;
        private readonly bcckContext _context;
        private readonly SignInManager<Employee_Portal_TestUser> _signInManager;
        private readonly IWebHostEnvironment _iwebhost;




        public DashboardController(UserManager<Employee_Portal_TestUser> userManager, bcckContext context, SignInManager<Employee_Portal_TestUser> signInManager, IWebHostEnvironment iwebhost)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
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
                model.Document = dbt.Doc.Where(x => x.EMPNO == user.Empno);


                return View(model);
            }

        }
        public IActionResult View1()
        {
            List<History> list = new List<History>();

            int count = list.GetType().GetGenericArguments()[0].GetProperties().Length;
            return View();
        }
        public IActionResult Edit1(string Empno, Pmast Pmast, PmastTemp tem)
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
        public IActionResult Edit1(Pmast Pmast, PmastTemp PmastTemp, string empno, PmastTemp tem)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            db.Entry(Pmast).State = EntityState.Modified;
            dbt.Entry(PmastTemp).State = EntityState.Modified;
            var l = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            HttpContext.Session.SetString("Session1", @Pmast.Add1);
            HttpContext.Session.SetString("Session2", @Pmast.Add2);
            HttpContext.Session.SetString("Session3", @Pmast.Postcode);
            HttpContext.Session.SetString("Session4", @Pmast.Town);
            HttpContext.Session.SetString("Session5", @Pmast.State);
            HttpContext.Session.SetString("Session6", @Pmast.Phone);
            HttpContext.Session.SetString("Session7", @Pmast.Mstatus);
            HttpContext.Session.SetString("Session8", @Pmast.Relcode);
            HttpContext.Session.SetString("Session9", @Pmast.Itaxno);
            PmastTemp.Add1 = HttpContext.Session.GetString("Session1");
            PmastTemp.Add2 = HttpContext.Session.GetString("Session2");
            PmastTemp.Postcode = HttpContext.Session.GetString("Session3");
            PmastTemp.Town = HttpContext.Session.GetString("Session4");
            PmastTemp.State = HttpContext.Session.GetString("Session5");
            PmastTemp.Phone = HttpContext.Session.GetString("Session6");
            PmastTemp.Mstatus = HttpContext.Session.GetString("Session7");
            PmastTemp.Relcode = HttpContext.Session.GetString("Session8");
            PmastTemp.Itaxno = HttpContext.Session.GetString("Session9");
            dbt.SaveChanges();
            BuildEmailTemplate(PmastTemp.Empno, Pmast);
            Addhis(PmastTemp, Pmast);
    

            return RedirectToAction("Dashboard1");

        }

        public void Addhis(PmastTemp PmastTemp, Pmast Pmast)
        {
            db.Entry(Pmast).Reload();
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var l = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            History his = new History();
            his.Empno = user.Empno;
            his.Date = DateTime.Now;
            his.Deptno = user.Dept;
            his.Hodappr = 0;
            his.Hrappr = 0;
            his.Name = l.Name;
            his.Add1 = PmastTemp.Add1;
            his.Add2 = PmastTemp.Add2;
            his.Postcode = PmastTemp.Postcode;
            his.Town = PmastTemp.Town;
            his.State = PmastTemp.State;
            his.Mstatus = PmastTemp.Mstatus;
            his.Relcode = PmastTemp.Relcode;
            his.Itaxno = PmastTemp.Itaxno;
            his.Phone = PmastTemp.Phone;

            his.Econtact = l.Econtact;
            his.EMERPHONE = l.Emerphone;
            his.EMERRSHIP = l.Emerrship;
            his.Sname = l.Sname;
            his.Snric = l.Snric;
            his.Pecontact = l.Econtact;
            his.Pemerphone = l.Emerphone;
            his.Pemerrship = l.Emerrship;
            his.Psname = l.Sname;
            his.Psnric = l.Snric;
            his.Padd1 = l.Add1;
            his.Padd2 = l.Add2;
            his.Ppostcode = l.Postcode;
            his.Ptown = l.Town;
            his.Pstate = l.State;
            his.Pmstatus = l.Mstatus;
            his.Prelcode = l.Relcode;
            his.Pitaxno = l.Itaxno;
            his.Pphone = l.Phone;
            dbt.History.Add(his);
            dbt.SaveChanges();

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
            else if (user.Dept == "2")
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
            Data.Phone = Datat.Phone;
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
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "qkfnfn1208");
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
            Data.Phone = Datat.Phone;
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
            Data.Phone = Datat.Phone;
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
            Data.Phone = Datat.Phone;
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
            HttpContext.Session.SetString("Session12", @Pmast.Emerrship);
            HttpContext.Session.SetString("Session13", @Pmast.Emerphone);
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
                Pmastemp.Emerrship = HttpContext.Session.GetString("Session12");
                Pmastemp.Emerphone = HttpContext.Session.GetString("Session13");
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
                Pmastemp.Emerrship = HttpContext.Session.GetString("Session12");
                Pmastemp.Emerphone = HttpContext.Session.GetString("Session13");
                Pmastemp.Sname = HttpContext.Session.GetString("Session14");
                Pmastemp.Snric = HttpContext.Session.GetString("Session15");
                dbt.SaveChanges();
                Addhis2(Pmastemp, Pmast);
                dbt.SaveChanges();
                BuildEmailTemplate2(Pmastemp.Empno);
            }


            return RedirectToAction("Dashboard2");


        }

        public void Addhis2(PmastTemp PmastTemp, Pmast Pmast)
        {
            db.Entry(Pmast).Reload();
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            var l = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
            var c = dbt.PmastTemp.Where(x => x.Empno == user.Empno).FirstOrDefault();
            History his = new History();
            his.Empno = user.Empno;
            his.Date = DateTime.Now;
            his.Deptno = user.Dept;
            his.Hodappr = 0;
            his.Hrappr = 0;
            his.Name = l.Name;

            his.Add1 = l.Add1;
            his.Add2 = l.Add2;
            his.Postcode = l.Postcode;
            his.Town = l.Town;
            his.State = l.State;
            his.Mstatus = l.Mstatus;
            his.Relcode = l.Relcode;
            his.Itaxno = l.Itaxno;
            his.Phone = l.Phone;
            his.Pphone = l.Phone;
            his.Padd1 = l.Add1;
            his.Padd2 = l.Add2;
            his.Ppostcode = l.Postcode;
            his.Ptown = l.Town;
            his.Pstate = l.State;
            his.Pmstatus = l.Mstatus;
            his.Prelcode = l.Relcode;
            his.Pitaxno = l.Itaxno;
            his.Pecontact = l.Econtact;
            his.Pemerphone = l.Emerphone;
            his.Pemerrship = l.Emerrship;
            his.Psname = l.Sname;
            his.Psnric = l.Snric;
            his.Econtact = c.Econtact;
            his.EMERPHONE = c.Emerphone;
            his.EMERRSHIP = c.Emerrship;
            his.Sname = c.Sname;
            his.Snric = c.Snric;
            dbt.History.Add(his);
            dbt.SaveChanges();

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
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "qkfnfn1208");
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
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "qkfnfn1208");
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
            Data.Emerphone = Datat.Emerphone;
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
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "qkfnfn1208");
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
                client.Credentials = new System.Net.NetworkCredential("sevquy@gmail.com", "qkfnfn1208");
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

        /*--------------------------------------------------------------------------------------------------------------------*/
        /* public IActionResult test()
         {
             return View(dbt.History.ToList());

         }
        */

        public IActionResult upload()
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            //added
            var result = dbt.Doc.Where(x => x.EMPNO == user.Empno).ToList();

            return View(result);
        }


        [HttpPost]
        public async Task<IActionResult> upload(IFormFile ifile, doc ic)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            string imgext = Path.GetExtension(ifile.FileName);
            if (imgext == ".jpg" || imgext == ".jpeg" || imgext == ".png" || imgext == ".JPG" || imgext == ".JPEG" || imgext == ".PNG")
            {
                var saveimg = Path.Combine(_iwebhost.WebRootPath, "Docimg", ifile.FileName);
                var stream = new FileStream(saveimg, FileMode.Create);
                await ifile.CopyToAsync(stream);
                ic.title = ifile.FileName;
                ic.docpath = saveimg;
                ic.EMPNO = user.Empno;
                await dbt.Doc.AddAsync(ic);
                await dbt.SaveChangesAsync();
                ViewData["Message"] = "save successful";
            }
            else
            {
                ViewData["Message"] = "save failed, must be .jpg/.jpeg/.png";
            }
            return RedirectToAction("Dashboard2");
        }

        public IActionResult upload1()
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            //added
            var result = db.Pmast.Where(x => x.Empno == user.Empno).ToList();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> upload1(IFormFile ifile, int _totLen)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            string imgext = Path.GetExtension(ifile.FileName);

            if (imgext == ".jpg" || imgext == ".jpeg" || imgext == ".png" || imgext == ".JPG" || imgext == ".JPEG" || imgext == ".PNG")
            {
                try
                {
                    var saveimg = Path.Combine(_iwebhost.WebRootPath, "Docimg", ifile.FileName);
                    var stream = new FileStream(saveimg, FileMode.Create);
                    await ifile.CopyToAsync(stream);
                    var c = db.Pmast.Where(x => x.Empno == user.Empno).FirstOrDefault();
                    c.P_path = saveimg;
                    c.P_title = ifile.FileName;
                    await db.SaveChangesAsync();
                    ViewData["Message"] = "save successful";
                    return RedirectToAction("Dashboard1");
                }
                catch
                {
                    return RedirectToAction("Dashboard1");
                }

            }
            else
            {
                ViewData["Message"] = "save failed, must be .jpg/.jpeg/.png";
            }
            return RedirectToAction("Dashboard1");
        }

        //MarriageType


        [HttpPost]
        public async Task<IActionResult> upload2(IFormFile ifile, doc ic)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            if (ifile != null)
            {
                string imgext = Path.GetExtension(ifile.FileName);

                if (imgext == ".jpg" || imgext == ".jpeg" || imgext == ".png" || imgext == ".JPG" || imgext == ".JPEG" || imgext == ".PNG" || imgext == ".pdf" || imgext == ".PDF")
                {
                    var saveimg = Path.Combine(_iwebhost.WebRootPath, "Docimg", ifile.FileName);
                    var stream = new FileStream(saveimg, FileMode.Create);
                    await ifile.CopyToAsync(stream);
                    ic.title = ifile.FileName;
                    ic.docpath = saveimg;
                    ic.EMPNO = user.Empno;
                    ic.DocType = "Marriage Certificate";
                    await dbt.Doc.AddAsync(ic);
                    await dbt.SaveChangesAsync();
                    ViewData["Message"] = "save successful";
                }
                else
                {
                    ViewData["Message"] = "save failed, must be .jpg/.jpeg/.png";
                }
                return RedirectToAction("Edit1");
            }

            else
            {
                return RedirectToAction("Edit1");
            }
        }
        //Religion Document


        [HttpPost]
        public async Task<IActionResult> upload3(IFormFile ifile, doc ic)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            if (ifile != null)
            {
                string imgext = Path.GetExtension(ifile.FileName);
                if (imgext == ".jpg" || imgext == ".jpeg" || imgext == ".png" || imgext == ".JPG" || imgext == ".JPEG" || imgext == ".PNG" || imgext == ".pdf" || imgext == ".PDF")
                {
                    var saveimg = Path.Combine(_iwebhost.WebRootPath, "Docimg", ifile.FileName);
                    var stream = new FileStream(saveimg, FileMode.Create);
                    await ifile.CopyToAsync(stream);
                    ic.title = ifile.FileName;
                    ic.docpath = saveimg;
                    ic.EMPNO = user.Empno;
                    ic.DocType = "Religion Change Document";
                    await dbt.Doc.AddAsync(ic);
                    await dbt.SaveChangesAsync();
                    ViewData["Message"] = "save successful";
                }
                else
                {
                    ViewData["Message"] = "save failed, must be .jpg/.jpeg/.png";
                }
                return RedirectToAction("Edit1");
            }
            else
            {
                return RedirectToAction("Edit1");
            }
        }

        //Income Tax Document

    [HttpPost]
        public async Task<IActionResult> upload4(IFormFile ifile, doc ic)
        {
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;
            if (ifile != null)
            {


                string imgext = Path.GetExtension(ifile.FileName);
                if (imgext == ".jpg" || imgext == ".jpeg" || imgext == ".png" || imgext == ".JPG" || imgext == ".JPEG" || imgext == ".PNG" || imgext == ".pdf" || imgext == ".PDF")
                {
                    var saveimg = Path.Combine(_iwebhost.WebRootPath, "Docimg", ifile.FileName);
                    var stream = new FileStream(saveimg, FileMode.Create);
                    await ifile.CopyToAsync(stream);
                    ic.title = ifile.FileName;
                    ic.docpath = saveimg;
                    ic.EMPNO = user.Empno;
                    ic.DocType = "Income Tax Document";
                    await dbt.Doc.AddAsync(ic);
                    await dbt.SaveChangesAsync();
                    ViewData["Message"] = "save successful";
                }
                else
                {
                    ViewData["Message"] = "save failed, must be .jpg/.jpeg/.png";
                }
                return RedirectToAction("Edit1");
            }
            else
            {
                return RedirectToAction("Edit1");
            }
        }


        public IActionResult test2()
        {

            return View();
        }


        public JsonResult testL()
        {
            String id = "testp@gmail.com";
            String pd = "123456*";
            var msg2 = "failed";
            var msg = "failed";
            var msg3 = "";
            var data = _userManager.GetUserId(HttpContext.User);
            Employee_Portal_TestUser user = _userManager.FindByIdAsync(data).Result;


            var result = _signInManager.PasswordSignInAsync(id, pd, true, lockoutOnFailure: false);
            Pmast Pmast = new Pmast();
            PmastTemp tem = new PmastTemp();
            var e = dbt.PmastTemp.Where(x => x.Empno == "134679").FirstOrDefault();
            var c = dbt.PmastTemp.Where(x => x.Empno == "888888").FirstOrDefault();


            if (e == null)
            {

                return Json(msg2);
            }
            else
            {

                e.Add1 = "wewe";
                dbt.SaveChangesAsync();

                if (e.Add1 == "wewe")
                {
                    msg2 = " Test Empno : 134679 " + " Add1 value : wewe " + " Result : Success ";
                }
                else
                {
                    msg2 = " Test Empno : 134679 " + " Add1 value : wewe " + " Result : Failed ";

                }

            }
            if (c == null)
            {
                return Json(msg);
            }
            else
            {
                c.Add1 = "ekjwldskamopdljwqpjdwoqjkopdwqepwqjpewjqpejwqpkdnalcnaslnskejwoqejwoqijewoqeewqewqewqewqewqewqewqewqasdczc";
                try
                {
                    dbt.SaveChanges();
                    msg = " Test Empno : 888888 " + " Add1 value : ekjwldskamopdljwqpjdwoqjkopdwqepwqjpewjqpejwqpkdnalcnaslnskejwoqejwoqijewoqeewqewqewqewqewqewqewqewqasdczc " + " Result : Success ";
                }
                catch
                {
                    msg = " Test Empno : 888888 " + " Add1 value : ekjwldskamopdljwqpjdwoqjkopdwqepwqjpewjqpejwqpkdnalcnaslnskejwoqejwoqijewoqeewqewqewqewqewqewqewqewqasdczc " + " Result : Failed ";
                }
            }


            msg3 = msg2 + "//////" + msg;
            return Json(msg3);
        }



        /*  if (result.Result.Succeeded)
          {

              var msg = "Test ID: testp@gmail.com" + "password: 123456*" + "Result: Successful";



              return Json(msg);

          }
          var msg1 = "Test ID: testp@gmail.com" + "password: 123456*" + "Result: Failed";

          return Json(msg1);
        */

    }



}


