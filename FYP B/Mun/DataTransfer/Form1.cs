using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace DataTransfer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //con = foxpro(pmast), con2 = mssql(pmast), con3 = foxpro(family), con4 = mssql(family)
            //viewing content for both database
            string oledbpath = "Provider=VFPOLEDB.1;Data Source=C:\\Users\\Mun yoo min\\Desktop\\ubs94file";
            string sqlpath = "Data Source=(local)\\sqlexpress;Initial Catalog=bcck1;Integrated Security=True";
            OleDbConnection con = new OleDbConnection(oledbpath);
            SqlConnection con2 = new SqlConnection(sqlpath);

            OleDbCommand cmd = new OleDbCommand("select empno,add1,phone,mstatus,sname,snric,econtact,etelno,itaxno,relcode,emerphone,emerrship from pmast", con);
            SqlCommand cmd2 = new SqlCommand("select EMPNO,ADD1,PHONE,MSTATUS,SNAME,SNRIC,ECONTACT,ETELNO,ITAXNO,RELCODE,EMERPHONE,EMERRSHIP from pmast", con2);
            OleDbCommand cmd3 = new OleDbCommand("select * from family", con);
            SqlCommand cmd4 = new SqlCommand("select * from family", con2);

            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            OleDbDataAdapter sda3 = new OleDbDataAdapter(cmd3);
            SqlDataAdapter sda4 = new SqlDataAdapter(cmd4);

            DataTable td = new DataTable();
            DataTable td2 = new DataTable();
            DataTable td3 = new DataTable();
            DataTable td4 = new DataTable();

            sda.Fill(td);
            sda2.Fill(td2);
            sda3.Fill(td3);
            sda4.Fill(td4);

            dataGridView1.DataSource = td;
            dataGridView2.DataSource = td2;
            dataGridView3.DataSource = td3;
            dataGridView4.DataSource = td4;
        }
        //button 1 = export, button 2 = import
        private void button1_Click(object sender, EventArgs e)
        {
            // table to store SQL Data
            var dataFromSQL = new DataTable();
            var dataFromSQL1 = new DataTable();
            var dataFromSQLT = new DataTable();
            string insrt = "INSERT INTO family ([empno],[memname],[nricno],[sex],[datebirth])VALUES(?,?,?,?,?)";
            string oledbpath = "Provider=VFPOLEDB.1;Data Source=C:\\Users\\Mun yoo min\\Desktop\\ubs94file";
            string sqlpath = "Data Source=(local)\\sqlexpress;Initial Catalog=bcck1;Integrated Security=True";
            // connection to SQL-Server
            using (var sqlConn = new SqlConnection(sqlpath))
            {
                using (SqlCommand sqlCmd = new SqlCommand("select ADD1,PHONE,MSTATUS,SNAME,SNRIC,ECONTACT,ETELNO,ITAXNO,RELCODE,EMERPHONE,EMERRSHIP,EMPNO from pmast", sqlConn))
                {
                    sqlConn.Open();

                    SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                    // populate into temp table
                    sqlDA.Fill(dataFromSQL);
                    sqlConn.Close();
                }
            }

            // connect to dbf 
            using (var vfpConn = new OleDbConnection(oledbpath))
            {
                using (OleDbCommand vfpCmd = new OleDbCommand("update pmast set add1 = ?, phone = ?, mstatus = ?, sname = ?, snric = ?, econtact = ?, etelno = ?, itaxno = ?, relcode = ?, emerphone = ?, emerrship = ? where empno=?", vfpConn))
                {

                    vfpConn.Open();
                    // Parameters added in order of the INSERT command above
                    vfpCmd.Parameters.Add(new OleDbParameter("parmadd1", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmphone", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmmstatus", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmsname", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmsnric", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmecontact", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmetelno", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmitaxno", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmrelcode", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmemerphone", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmemerrship", "sample string"));
                    vfpCmd.Parameters.Add(new OleDbParameter("parmempno", "sample string"));

                    //vfpCmd.Parameters.Add(new OleDbParameter("parmCreateDate", DateTime.Now));
                    // Now, for each row in the ORIGINAL SQL table, apply the insert to VFP
                    foreach (DataRow dr in dataFromSQL.Rows)
                    {
                        // set the parameters based on whatever current record is
                        vfpCmd.Parameters[0].Value = dr["add1"];
                        vfpCmd.Parameters[1].Value = dr["phone"];
                        vfpCmd.Parameters[2].Value = dr["mstatus"];
                        vfpCmd.Parameters[3].Value = dr["sname"];
                        vfpCmd.Parameters[4].Value = dr["snric"];
                        vfpCmd.Parameters[5].Value = dr["econtact"];
                        vfpCmd.Parameters[6].Value = dr["etelno"];
                        vfpCmd.Parameters[7].Value = dr["itaxno"];
                        vfpCmd.Parameters[8].Value = dr["relcode"];
                        vfpCmd.Parameters[9].Value = dr["emerphone"];
                        vfpCmd.Parameters[10].Value = dr["emerrship"];
                        vfpCmd.Parameters[11].Value = dr["empno"];
                        vfpCmd.ExecuteNonQuery();

                    }

                    // close VFP connection
                    vfpConn.Close();

                }
            }
            //connection to mssql family
            using (var sqlConn1 = new SqlConnection(sqlpath))
            {
                using (SqlCommand sqlCmd1 = new SqlCommand("select EMPNO,MEMNAME,NRICNO,SEX,DATEBIRTH from family", sqlConn1))
                {
                    sqlConn1.Open();

                    SqlDataAdapter sqlDA1 = new SqlDataAdapter(sqlCmd1);
                    // populate into temp table
                    sqlDA1.Fill(dataFromSQL1);
                    sqlConn1.Close();
                }
            }
            using (var vfpConn = new OleDbConnection(oledbpath))
            {
                using (OleDbCommand dele = new OleDbCommand("delete from family;", vfpConn))
                {
                    vfpConn.Open();
                    //dele.ExecuteNonQuery();

                    using (OleDbCommand vfpCmd1 = new OleDbCommand(insrt, vfpConn))
                    {


                        // Parameters added in order of the INSERT command above
                        vfpCmd1.Parameters.Add(new OleDbParameter("parmempno", "sample string"));
                        vfpCmd1.Parameters.Add(new OleDbParameter("parmmemname", "sample string"));
                        vfpCmd1.Parameters.Add(new OleDbParameter("parmnricno", "sample string"));
                        vfpCmd1.Parameters.Add(new OleDbParameter("parmsex", "sample string"));
                        vfpCmd1.Parameters.Add(new OleDbParameter("parmdatebirth", DateTime.Now));

                        // For each row in the ORIGINAL SQL table, apply the insert to VFP
                        foreach (DataRow dr1 in dataFromSQL1.Rows)
                        {
                            //set the parameters based on whatever current record is
                            vfpCmd1.Parameters[0].Value = dr1["empno"];
                            vfpCmd1.Parameters[1].Value = dr1["memname"];
                            vfpCmd1.Parameters[2].Value = dr1["nricno"];
                            vfpCmd1.Parameters[3].Value = dr1["sex"];
                            vfpCmd1.Parameters[4].Value = dr1["datebirth"];
                            vfpCmd1.ExecuteNonQuery();

                        }

                        // close VFP connection
                        vfpConn.Close();
                    }
                }

                //delete duplicate

                using (var oleConn1 = new OleDbConnection(oledbpath))
                {
                    using (OleDbCommand oleCmd1 = new OleDbCommand("select distinct empno,memname,nricno,sex,datebirth from family", oleConn1))
                    {
                        oleConn1.Open();

                        OleDbDataAdapter oleDA1 = new OleDbDataAdapter(oleCmd1);
                        // populate into temp table
                        oleDA1.Fill(dataFromSQLT);
                        oleConn1.Close();
                    }
                }
                using (var vfpConnt = new OleDbConnection(oledbpath))
                {
                    using (OleDbCommand delet = new OleDbCommand("delete from family;", vfpConn))
                    {
                        vfpConn.Open();
                        delet.ExecuteNonQuery();

                        using (OleDbCommand vfpCmdt = new OleDbCommand(insrt, vfpConn))
                        {

                            // Parameters added in order of the INSERT command above
                            vfpCmdt.Parameters.Add(new OleDbParameter("parmempno", "sample string"));
                            vfpCmdt.Parameters.Add(new OleDbParameter("parmmemname", "sample string"));
                            vfpCmdt.Parameters.Add(new OleDbParameter("parmnricno", "sample string"));
                            vfpCmdt.Parameters.Add(new OleDbParameter("parmsex", "sample string"));
                            vfpCmdt.Parameters.Add(new OleDbParameter("parmdatebirth", DateTime.Now));

                            // Now, for each row in the ORIGINAL SQL table, apply the insert to VFP
                            foreach (DataRow dr1 in dataFromSQLT.Rows)
                            {
                                //set the parameters based on whatever current record is
                                vfpCmdt.Parameters[0].Value = dr1["empno"];
                                vfpCmdt.Parameters[1].Value = dr1["memname"];
                                vfpCmdt.Parameters[2].Value = dr1["nricno"];
                                vfpCmdt.Parameters[3].Value = dr1["sex"];
                                vfpCmdt.Parameters[4].Value = dr1["datebirth"];
                                vfpCmdt.ExecuteNonQuery();

                            }

                            // close VFP connection
                            vfpConnt.Close();
                        }
                    }

                    MessageBox.Show("Export Successful");
                    this.Close();

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oledbpath = "Provider=VFPOLEDB.1;Data Source=C:\\Users\\Mun yoo min\\Desktop\\ubs94file";
            string sqlpath = "Data Source=(local)\\sqlexpress;Initial Catalog=bcck1;Integrated Security=True";
            string sqlpathtemp = "Data Source=(local)\\sqlexpress;Initial Catalog=bcck;Integrated Security=True";
            using (OleDbConnection sourcecon = new OleDbConnection(oledbpath))
            {
                //use this in the first table to see result
                //string sqlcom = "select family.empno, family.memname, family.nricno, family.sex, family.datebirth, pmastsub.fathernm, pmastsub.mothernm, pmastsub.resumdir from pmastsub(addition) inner join family(main) on pmastsub.empno = family.empno";
                string sqlcom = "select family.empno, family.memname, family.nricno, family.sex, family.datebirth, pmastsub.fathernm, pmastsub.mothernm from pmastsub inner join family on pmastsub.empno = family.empno";
                OleDbCommand cmd = new OleDbCommand("Select * from pmast", sourcecon);
                OleDbCommand cmd1 = new OleDbCommand(sqlcom, sourcecon);

                sourcecon.Open();
                using (OleDbDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection destinationcon = new SqlConnection(sqlpath))
                    {
                        using (SqlCommand del2 = new SqlCommand("DELETE FROM dbo.family;", destinationcon))
                        {
                            using (SqlCommand del = new SqlCommand("DELETE FROM dbo.pmast;", destinationcon))
                            {
                                using (SqlBulkCopy bc = new SqlBulkCopy(destinationcon))
                                {
                                    bc.DestinationTableName = "dbo.pmast";
                                    destinationcon.Open();
                                    del2.ExecuteNonQuery();
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
                                    destinationcon.Close();
                                }

                            }
                        }
                    }

                }


                using (OleDbDataReader rdr1 = cmd1.ExecuteReader())
                {
                    using (SqlConnection destinationcon = new SqlConnection(sqlpath))
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
                            bc.ColumnMappings.Add("fathernm", "FATHERNM");
                            bc.ColumnMappings.Add("mothernm", "MOTHERNM");
                            bc.WriteToServer(rdr1);
                            destinationcon.Close();
                        }

                    }
                }
                //importing to pmast_temp
                using (OleDbDataReader rdr2 = cmd.ExecuteReader())
                {
                    using (SqlConnection destinationcon = new SqlConnection(sqlpathtemp))
                    {
                        using (SqlCommand del2 = new SqlCommand("DELETE FROM dbo.family_temp;", destinationcon))
                        {
                            using (SqlCommand del = new SqlCommand("DELETE FROM dbo.pmast_temp;", destinationcon))
                            {
                                using (SqlBulkCopy bc1 = new SqlBulkCopy(destinationcon))
                                {
                                    bc1.DestinationTableName = "dbo.pmast_temp";
                                    destinationcon.Open();
                                    del2.ExecuteNonQuery();
                                    del.ExecuteNonQuery();
                                    bc1.ColumnMappings.Add("empno", "EMPNO");
                                    bc1.ColumnMappings.Add("emp_code", "EMP_CODE");
                                    bc1.ColumnMappings.Add("name", "NAME");
                                    bc1.ColumnMappings.Add("iname", "INAME");
                                    bc1.ColumnMappings.Add("add1", "ADD1");
                                    bc1.ColumnMappings.Add("add2", "ADD2");
                                    bc1.ColumnMappings.Add("postcode", "POSTCODE");
                                    bc1.ColumnMappings.Add("town", "TOWN");
                                    bc1.ColumnMappings.Add("state", "STATE");
                                    bc1.ColumnMappings.Add("phone", "PHONE");
                                    bc1.ColumnMappings.Add("dbirth", "DBIRTH");
                                    bc1.ColumnMappings.Add("nric", "NRIC");
                                    bc1.ColumnMappings.Add("nricn", "NRICN");
                                    bc1.ColumnMappings.Add("iccolor", "ICCOLOR");
                                    bc1.ColumnMappings.Add("national", "NATIONAL");
                                    bc1.ColumnMappings.Add("passport", "PASSPORT");
                                    bc1.ColumnMappings.Add("sex", "SEX");
                                    bc1.ColumnMappings.Add("mstatus", "MSTATUS");
                                    bc1.ColumnMappings.Add("mstatusod", "MSTATUSOD");
                                    bc1.ColumnMappings.Add("race", "RACE");
                                    bc1.ColumnMappings.Add("b_putra", "B_PUTRA");
                                    bc1.ColumnMappings.Add("sname", "SNAME");
                                    bc1.ColumnMappings.Add("snric", "SNRIC");
                                    bc1.ColumnMappings.Add("iskerja", "ISKERJA");
                                    bc1.ColumnMappings.Add("tx_ded_sp", "TX_DED_SP");
                                    bc1.ColumnMappings.Add("num_child", "NUM_CHILD");
                                    bc1.ColumnMappings.Add("econtact", "ECONTACT");
                                    bc1.ColumnMappings.Add("etelno", "ETELNO");
                                    bc1.ColumnMappings.Add("eadd1", "EADD1");
                                    bc1.ColumnMappings.Add("eadd2", "EADD2");
                                    bc1.ColumnMappings.Add("eadd3", "EADD3");
                                    bc1.ColumnMappings.Add("category", "CATEGORY");
                                    bc1.ColumnMappings.Add("plineno", "PLINENO");
                                    bc1.ColumnMappings.Add("jtitle", "JTITLE");
                                    bc1.ColumnMappings.Add("dcomm", "DCOMM");
                                    bc1.ColumnMappings.Add("dconfirm", "DCONFIRM");
                                    bc1.ColumnMappings.Add("dpromote", "DPROMOTE");
                                    bc1.ColumnMappings.Add("dresign", "DRESIGN");
                                    bc1.ColumnMappings.Add("wpermit", "WPERMIT");
                                    bc1.ColumnMappings.Add("wp_from", "WP_FROM");
                                    bc1.ColumnMappings.Add("wp_to", "WP_TO");
                                    bc1.ColumnMappings.Add("epfno", "EPFNO");
                                    bc1.ColumnMappings.Add("socsono", "SOCSONO");
                                    bc1.ColumnMappings.Add("itaxno", "ITAXNO");
                                    bc1.ColumnMappings.Add("paystatus", "PAYSTATUS");
                                    bc1.ColumnMappings.Add("dedmem113", "DEDMEM113");
                                    bc1.ColumnMappings.Add("dedmem114", "DEDMEM114");
                                    bc1.ColumnMappings.Add("remark", "REMARK");
                                    bc1.ColumnMappings.Add("photodir", "PHOTODIR");
                                    bc1.ColumnMappings.Add("confid", "CONFID");
                                    bc1.ColumnMappings.Add("workgrpid", "WORKGRPID");
                                    bc1.ColumnMappings.Add("badgeno", "BADGENO");
                                    bc1.ColumnMappings.Add("phone2", "PHONE2");
                                    bc1.ColumnMappings.Add("email", "EMAIL");
                                    bc1.ColumnMappings.Add("jobcode", "JOBCODE");
                                    bc1.ColumnMappings.Add("deptcode", "DEPTCODE");
                                    bc1.ColumnMappings.Add("relcode", "RELCODE");
                                    bc1.ColumnMappings.Add("trancode", "TRANCODE");
                                    bc1.ColumnMappings.Add("jstacode", "JSTACODE");
                                    bc1.ColumnMappings.Add("brcode", "BRCODE");
                                    bc1.ColumnMappings.Add("dpassport", "DPASSPORT");
                                    bc1.ColumnMappings.Add("emerphone", "EMERPHONE");
                                    bc1.ColumnMappings.Add("emerrship", "EMERRSHIP");
                                    bc1.ColumnMappings.Add("jfunction", "JFUNCTION");
                                    bc1.ColumnMappings.Add("lschmcode", "LSCHMCODE");
                                    bc1.ColumnMappings.Add("cschmcode", "CSCHMCODE");
                                    bc1.ColumnMappings.Add("albf", "ALBF");
                                    bc1.ColumnMappings.Add("alall", "ALALL");
                                    bc1.ColumnMappings.Add("albal", "ALBAL");
                                    bc1.ColumnMappings.Add("mcall", "MCALL");
                                    bc1.ColumnMappings.Add("finno", "FINNO");
                                    bc1.ColumnMappings.Add("edu", "EDU");
                                    bc1.ColumnMappings.Add("payrtype", "PAYRTYPE");
                                    bc1.ColumnMappings.Add("paymeth", "PAYMETH");
                                    bc1.ColumnMappings.Add("bankic", "BANKIC");
                                    bc1.ColumnMappings.Add("epftbl", "EPFTBL");
                                    bc1.ColumnMappings.Add("socsotbl", "SOCSOTBL");
                                    bc1.ColumnMappings.Add("fwlevymtd", "FWLEVYMTD");
                                    bc1.ColumnMappings.Add("withpcb", "WITHPCB");
                                    bc1.ColumnMappings.Add("ot_maxpay", "OT_MAXPAY");
                                    bc1.ColumnMappings.Add("socsoic", "SOCSOIC");
                                    bc1.ColumnMappings.Add("icinssocno", "ICINSSOCNO");
                                    bc1.ColumnMappings.Add("sobsotbl", "SOBSOTBL");
                                    bc1.ColumnMappings.Add("contract", "CONTRACT");
                                    bc1.ColumnMappings.Add("epfic", "EPFIC");
                                    bc1.ColumnMappings.Add("otraterc", "OTRATERC");
                                    bc1.ColumnMappings.Add("epfcat", "EPFCAT");
                                    bc1.ColumnMappings.Add("socsocat", "SOCSOCAT");
                                    bc1.ColumnMappings.Add("itaxcat", "ITAXCAT");
                                    bc1.ColumnMappings.Add("bankcat", "BANKCAT");
                                    bc1.ColumnMappings.Add("shifttbl", "SHIFTTBL");
                                    bc1.ColumnMappings.Add("almctbl", "ALMCTBL");
                                    bc1.ColumnMappings.Add("nm_pcb", "NM_PCB");
                                    bc1.ColumnMappings.Add("pbonus_mth", "PBONUS_MTH");
                                    bc1.ColumnMappings.Add("whtbl", "WHTBL");
                                    bc1.ColumnMappings.Add("ottbl", "OTTBL");
                                    bc1.ColumnMappings.Add("nppm", "NPPM");
                                    bc1.ColumnMappings.Add("inc_amt", "INC_AMT");
                                    bc1.ColumnMappings.Add("inc_date", "INC_DATE");
                                    bc1.ColumnMappings.Add("contract_f", "CONTRACT_F");
                                    bc1.ColumnMappings.Add("contract_t", "CONTRACT_T");
                                    bc1.ColumnMappings.Add("dateenter", "DATEENTER");
                                    bc1.ColumnMappings.Add("keyuser", "KEYUSER");
                                    bc1.ColumnMappings.Add("mcbal", "MCBAL");
                                    bc1.ColumnMappings.Add("created_on", "CREATED_ON");
                                    bc1.ColumnMappings.Add("updated_on", "UPDATED_ON");
                                    bc1.WriteToServer(rdr2);
                                    destinationcon.Close();
                                }
                            }
                        }

                    }
                }
                //import to family_temp
                using (OleDbDataReader rdr1 = cmd1.ExecuteReader())
                {
                    using (SqlConnection destinationcon = new SqlConnection(sqlpathtemp))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(destinationcon))
                        {
                            bc.DestinationTableName = "dbo.family_temp";
                            destinationcon.Open();
                            bc.ColumnMappings.Add("empno", "EMPNO");
                            bc.ColumnMappings.Add("memname", "MEMNAME");
                            bc.ColumnMappings.Add("nricno", "NRICNO");
                            bc.ColumnMappings.Add("sex", "SEX");
                            bc.ColumnMappings.Add("datebirth", "DATEBIRTH");
                            bc.ColumnMappings.Add("fathernm", "FATHERNM");
                            bc.ColumnMappings.Add("mothernm", "MOTHERNM");
                            bc.WriteToServer(rdr1);
                            destinationcon.Close();
                        }

                    }
                    MessageBox.Show("Import/Sync Successful");
                    this.Close();
                }

            }

        }
    }
}