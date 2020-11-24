using System;
using System.ComponentModel.DataAnnotations;

namespace Employee_Portal_Test.Models
{
    public partial class History
    {
        [Key]
        public int Id { get; set; }
        public string Empno { get; set; }
        public DateTime? Date { get; set; }
        public string Deptno { get; set; }
        public int Hodappr { get; set; }
        public int Hrappr { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string Name { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Mstatus { get; set; }
        public string Relcode { get; set; }
        public string Itaxno { get; set; }
        public string Phone { get; set; }
        public string Padd1 { get; set; }
        public string Padd2 { get; set; }
        public string Pname { get; set; }
        public string Ppostcode { get; set; }
        public string Ptown { get; set; }
        public string Pstate { get; set; }
        public string Pmstatus { get; set; }
        public string Prelcode { get; set; }
        public string Pitaxno { get; set; }
        public string Pphone { get; set; }
        public string Econtact { get; set; }
        public string EMERPHONE { get; set; }
        public string EMERRSHIP { get; set; }
        public string? Sname { get; set; }
        public string Snric { get; set; }
        public string Pecontact { get; set; }
        public string Pemerphone { get; set; }
        public string Pemerrship { get; set; }
        public string Psname { get; set; }
        public string Psnric { get; set; }

    }
}
