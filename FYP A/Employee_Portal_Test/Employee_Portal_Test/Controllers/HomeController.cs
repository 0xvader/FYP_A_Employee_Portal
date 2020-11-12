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

namespace Employee_Portal_Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Importubs()
        {

            OleDbConnection sourcecon = new OleDbConnection("Provider = VFPOLEDB.1; Data Source = C:\\Users\\Mun yoo min\\Desktop\\ubs94file");
            using (sourcecon)
            {
                OleDbCommand cmd = new OleDbCommand("Select * from pmast", sourcecon);
                OleDbCommand cmd1 = new OleDbCommand("Select * from family", sourcecon);
                sourcecon.Open();
                using (OleDbDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection destinationcon = new SqlConnection("Data Source = (local)\\sqlexpress; Initial Catalog = bcck; Integrated Security = True"))
                    {
                        using (SqlCommand del1 = new SqlCommand("DELETE FROM dbo.family;", destinationcon))
                        {
                            using (SqlCommand del = new SqlCommand("DELETE FROM dbo.pmast;", destinationcon))
                            {
                                using (SqlBulkCopy bc = new SqlBulkCopy(destinationcon))
                                {
                                    bc.DestinationTableName = "dbo.pmast";
                                    destinationcon.Open();
                                    del1.ExecuteNonQuery();
                                    del.ExecuteNonQuery();
                                    bc.ColumnMappings.Add("empno", "EMPNO");
                                    bc.ColumnMappings.Add("emp_code", "EMP_CODE");
                                    bc.ColumnMappings.Add("name", "NAME");
                                    bc.ColumnMappings.Add("iname", "INAME");
                                    bc.ColumnMappings.Add("add1", "ADD1");
                                    bc.ColumnMappings.Add("add2", "ADD2");
                                    bc.ColumnMappings.Add("postcode", "POSTCODE");
                                    bc.ColumnMappings.Add("town", "TOWN");
                                    bc.ColumnMappings.Add("state", "STATE");
                                    bc.ColumnMappings.Add("phone", "PHONE");
                                    bc.ColumnMappings.Add("dbirth", "DBIRTH");
                                    bc.ColumnMappings.Add("nric", "NRIC");
                                    bc.ColumnMappings.Add("nricn", "NRICN");
                                    bc.ColumnMappings.Add("iccolor", "ICCOLOR");
                                    bc.ColumnMappings.Add("national", "NATIONAL");
                                    bc.ColumnMappings.Add("passport", "PASSPORT");
                                    bc.ColumnMappings.Add("sex", "SEX");
                                    bc.ColumnMappings.Add("mstatus", "MSTATUS");
                                    bc.ColumnMappings.Add("mstatusod", "MSTATUSOD");
                                    bc.ColumnMappings.Add("race", "RACE");
                                    bc.ColumnMappings.Add("b_putra", "B_PUTRA");
                                    bc.ColumnMappings.Add("sname", "SNAME");
                                    bc.ColumnMappings.Add("snric", "SNRIC");
                                    bc.ColumnMappings.Add("iskerja", "ISKERJA");
                                    bc.ColumnMappings.Add("tx_ded_sp", "TX_DED_SP");
                                    bc.ColumnMappings.Add("num_child", "NUM_CHILD");
                                    bc.ColumnMappings.Add("econtact", "ECONTACT");
                                    bc.ColumnMappings.Add("etelno", "ETELNO");
                                    bc.ColumnMappings.Add("eadd1", "EADD1");
                                    bc.ColumnMappings.Add("eadd2", "EADD2");
                                    bc.ColumnMappings.Add("eadd3", "EADD3");
                                    bc.ColumnMappings.Add("category", "CATEGORY");
                                    bc.ColumnMappings.Add("plineno", "PLINENO");
                                    bc.ColumnMappings.Add("jtitle", "JTITLE");
                                    bc.ColumnMappings.Add("dcomm", "DCOMM");
                                    bc.ColumnMappings.Add("dconfirm", "DCONFIRM");
                                    bc.ColumnMappings.Add("dpromote", "DPROMOTE");
                                    bc.ColumnMappings.Add("dresign", "DRESIGN");
                                    bc.ColumnMappings.Add("wpermit", "WPERMIT");
                                    bc.ColumnMappings.Add("wp_from", "WP_FROM");
                                    bc.ColumnMappings.Add("wp_to", "WP_TO");
                                    bc.ColumnMappings.Add("epfno", "EPFNO");
                                    bc.ColumnMappings.Add("socsono", "SOCSONO");
                                    bc.ColumnMappings.Add("itaxno", "ITAXNO");
                                    bc.ColumnMappings.Add("paystatus", "PAYSTATUS");
                                    bc.ColumnMappings.Add("dedmem113", "DEDMEM113");
                                    bc.ColumnMappings.Add("dedmem114", "DEDMEM114");
                                    bc.ColumnMappings.Add("remark", "REMARK");
                                    bc.ColumnMappings.Add("photodir", "PHOTODIR");
                                    bc.ColumnMappings.Add("confid", "CONFID");
                                    bc.ColumnMappings.Add("workgrpid", "WORKGRPID");
                                    bc.ColumnMappings.Add("badgeno", "BADGENO");
                                    bc.ColumnMappings.Add("phone2", "PHONE2");
                                    bc.ColumnMappings.Add("email", "EMAIL");
                                    bc.ColumnMappings.Add("jobcode", "JOBCODE");
                                    bc.ColumnMappings.Add("deptcode", "DEPTCODE");
                                    bc.ColumnMappings.Add("relcode", "RELCODE");
                                    bc.ColumnMappings.Add("trancode", "TRANCODE");
                                    bc.ColumnMappings.Add("jstacode", "JSTACODE");
                                    bc.ColumnMappings.Add("brcode", "BRCODE");
                                    bc.ColumnMappings.Add("dpassport", "DPASSPORT");
                                    bc.ColumnMappings.Add("emerphone", "EMERPHONE");
                                    bc.ColumnMappings.Add("emerrship", "EMERRSHIP");
                                    bc.ColumnMappings.Add("jfunction", "JFUNCTION");
                                    bc.ColumnMappings.Add("lschmcode", "LSCHMCODE");
                                    bc.ColumnMappings.Add("cschmcode", "CSCHMCODE");
                                    bc.ColumnMappings.Add("albf", "ALBF");
                                    bc.ColumnMappings.Add("alall", "ALALL");
                                    bc.ColumnMappings.Add("albal", "ALBAL");
                                    bc.ColumnMappings.Add("mcall", "MCALL");
                                    bc.ColumnMappings.Add("finno", "FINNO");
                                    bc.ColumnMappings.Add("edu", "EDU");
                                    bc.ColumnMappings.Add("payrtype", "PAYRTYPE");
                                    bc.ColumnMappings.Add("paymeth", "PAYMETH");
                                    bc.ColumnMappings.Add("bankic", "BANKIC");
                                    bc.ColumnMappings.Add("epftbl", "EPFTBL");
                                    bc.ColumnMappings.Add("socsotbl", "SOCSOTBL");
                                    bc.ColumnMappings.Add("fwlevymtd", "FWLEVYMTD");
                                    bc.ColumnMappings.Add("withpcb", "WITHPCB");
                                    bc.ColumnMappings.Add("ot_maxpay", "OT_MAXPAY");
                                    bc.ColumnMappings.Add("socsoic", "SOCSOIC");
                                    bc.ColumnMappings.Add("icinssocno", "ICINSSOCNO");
                                    bc.ColumnMappings.Add("sobsotbl", "SOBSOTBL");
                                    bc.ColumnMappings.Add("contract", "CONTRACT");
                                    bc.ColumnMappings.Add("epfic", "EPFIC");
                                    bc.ColumnMappings.Add("otraterc", "OTRATERC");
                                    bc.ColumnMappings.Add("epfcat", "EPFCAT");
                                    bc.ColumnMappings.Add("socsocat", "SOCSOCAT");
                                    bc.ColumnMappings.Add("itaxcat", "ITAXCAT");
                                    bc.ColumnMappings.Add("bankcat", "BANKCAT");
                                    bc.ColumnMappings.Add("shifttbl", "SHIFTTBL");
                                    bc.ColumnMappings.Add("almctbl", "ALMCTBL");
                                    bc.ColumnMappings.Add("nm_pcb", "NM_PCB");
                                    bc.ColumnMappings.Add("pbonus_mth", "PBONUS_MTH");
                                    bc.ColumnMappings.Add("whtbl", "WHTBL");
                                    bc.ColumnMappings.Add("ottbl", "OTTBL");
                                    bc.ColumnMappings.Add("nppm", "NPPM");
                                    bc.ColumnMappings.Add("inc_amt", "INC_AMT");
                                    bc.ColumnMappings.Add("inc_date", "INC_DATE");
                                    bc.ColumnMappings.Add("contract_f", "CONTRACT_F");
                                    bc.ColumnMappings.Add("contract_t", "CONTRACT_T");
                                    bc.ColumnMappings.Add("dateenter", "DATEENTER");
                                    bc.ColumnMappings.Add("keyuser", "KEYUSER");
                                    bc.ColumnMappings.Add("mcbal", "MCBAL");
                                    bc.ColumnMappings.Add("created_on", "CREATED_ON");
                                    bc.ColumnMappings.Add("updated_on", "UPDATED_ON");
                                    bc.WriteToServer(rdr);
                                }
                            }
                        }

                    }


                }
                using (OleDbDataReader rdr1 = cmd1.ExecuteReader())
                {
                    using (SqlConnection destinationcon = new SqlConnection("Data Source = (local)\\sqlexpress; Initial Catalog = bcck; Integrated Security = True"))
                    {

                        using (SqlBulkCopy bc = new SqlBulkCopy(destinationcon))
                        {
                            bc.DestinationTableName = "dbo.family";
                            destinationcon.Open();
                            bc.ColumnMappings.Add("empno", "EMPNO");
                            bc.ColumnMappings.Add("memname", "MEMNAME");
                            bc.ColumnMappings.Add("nricno", "NRICNO");
                            bc.ColumnMappings.Add("sex", "SEX");
                            bc.ColumnMappings.Add("datebirth", "DATEBIRTH");
                            bc.WriteToServer(rdr1);
                            destinationcon.Close();
                        }

                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }
            public async Task<IActionResult> Exportubs()
        {

            var dataFromSQL = new DataTable();
            var dataFromSQL1 = new DataTable();

            //using (var sqlConn = new SqlConnection("Data Source = (local)\\sqlexpress; Initial Catalog = bcck; Integrated Security = True"))
            //{
            //    using (SqlCommand sqlCmd = new SqlCommand("select ADD1,PHONE,MSTATUS,SNAME,SNRIC,ECONTACT,ETELNO,ITAXNO,RELCODE,EMERPHONE,EMERRSHIP,EMPNO from pmast", sqlConn))
            //    {
            //        sqlConn.Open();

            //        SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
            //        // populate into temp table
            //        sqlDA.Fill(dataFromSQL);
            //        sqlConn.Close();
            //    }
            //}


            //using (var vfpConn = new OleDbConnection("Provider = VFPOLEDB.1; Data Source = C:\\Users\\Mun yoo min\\Desktop\\ubs94file"))
            //{
            //    using (OleDbCommand vfpCmd = new OleDbCommand("update pmast set add1 = ?, phone = ?, mstatus = ?, sname = ?, snric = ?, econtact = ?, etelno = ?, itaxno = ?, relcode = ?, emerphone = ?, emerrship = ? where empno=?", vfpConn))
            //    {

            //        vfpConn.Open();

            //        vfpCmd.Parameters.Add(new OleDbParameter("parmadd1", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmphone", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmmstatus", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmsname", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmsnric", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmecontact", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmetelno", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmitaxno", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmrelcode", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmemerphone", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmemerrship", "sample string"));
            //        vfpCmd.Parameters.Add(new OleDbParameter("parmempno", "sample string"));


            //        foreach (DataRow dr in dataFromSQL.Rows)
            //        {

            //            vfpCmd.Parameters[0].Value = dr["add1"];
            //            vfpCmd.Parameters[1].Value = dr["phone"];
            //            vfpCmd.Parameters[2].Value = dr["mstatus"];
            //            vfpCmd.Parameters[3].Value = dr["sname"];
            //            vfpCmd.Parameters[4].Value = dr["snric"];
            //            vfpCmd.Parameters[5].Value = dr["econtact"];
            //            vfpCmd.Parameters[6].Value = dr["etelno"];
            //            vfpCmd.Parameters[7].Value = dr["itaxno"];
            //            vfpCmd.Parameters[8].Value = dr["relcode"];
            //            vfpCmd.Parameters[9].Value = dr["emerphone"];
            //            vfpCmd.Parameters[10].Value = dr["emerrship"];
            //            vfpCmd.Parameters[11].Value = dr["empno"];
            //            vfpCmd.ExecuteNonQuery();

            //        }


            //        vfpConn.Close();

            //    }
            //}

            using (var sqlConn1 = new SqlConnection("Data Source = (local)\\sqlexpress; Initial Catalog = bcck; Integrated Security = True"))
            {
                using (SqlCommand sqlCmd1 = new SqlCommand("select MEMNAME,NRICNO,SEX,EMPNO from family", sqlConn1))
                {
                    sqlConn1.Open();

                    SqlDataAdapter sqlDA1 = new SqlDataAdapter(sqlCmd1);
                    
                    sqlDA1.Fill(dataFromSQL1);
                    sqlConn1.Close();
                }
            }
            using (var vfpConn = new OleDbConnection("Provider = VFPOLEDB.1; Data Source = C:\\Users\\Mun yoo min\\Desktop\\ubs94file"))
            {
                using (OleDbCommand vfpCmd1 = new OleDbCommand("update family set memname = ?, nricno = ?, sex = ? where empno=?", vfpConn))
                {

                    vfpConn.Open();
                    
                    vfpCmd1.Parameters.Add(new OleDbParameter("parmmemname", "sample string"));
                    vfpCmd1.Parameters.Add(new OleDbParameter("parmnricno", "sample string"));
                    vfpCmd1.Parameters.Add(new OleDbParameter("parmsex", "sample string"));
                    //vfpCmd1.Parameters.Add("datebirth", OleDbType.Date).Value = DateTime.Now;
                    //vfpCmd1.Parameters.Add(new OleDbParameter("parmdatebirth", DateTime.Now));
                    vfpCmd1.Parameters.Add(new OleDbParameter("parmempno", "sample string"));


                  
                    foreach (DataRow dr1 in dataFromSQL1.Rows)
                    {
                       
                        vfpCmd1.Parameters[0].Value = dr1["memname"];
                        vfpCmd1.Parameters[1].Value = dr1["nricno"];
                        vfpCmd1.Parameters[2].Value = dr1["sex"];
                        //vfpCmd1.Parameters[3].Value = dr1["datebirth"];
                        vfpCmd1.Parameters[3].Value = dr1["empno"];
                        vfpCmd1.ExecuteNonQuery();
                        vfpCmd1.Parameters.Clear();
                    }

                   
                    vfpConn.Close();
                }

                return RedirectToAction(nameof(Index));
            }

        }
    }
}
