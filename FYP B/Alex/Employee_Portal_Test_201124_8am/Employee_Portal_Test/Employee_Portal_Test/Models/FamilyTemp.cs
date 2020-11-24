using System;
using System.Collections.Generic;

namespace Employee_Portal_Test.Models
{
    public partial class FamilyTemp
    {
        public string Empno { get; set; }
        public string Memname { get; set; }
        public string Nricno { get; set; }
        public string Sex { get; set; }
        public DateTime? Datebirth { get; set; }

        public string FATHERNM { get; set; }

        public string MOTHERNM { get; set; }

        public virtual PmastTemp EmpnoNavigation { get; set; }
    }
}
