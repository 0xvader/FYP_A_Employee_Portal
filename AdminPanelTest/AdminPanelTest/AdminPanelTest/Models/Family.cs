using System;
using System.Collections.Generic;

namespace AdminPanelTest.Models
{
    public partial class Family
    {
        public string Empno { get; set; }
        public string Memname { get; set; }
        public string Nricno { get; set; }
        public string Sex { get; set; }
        public DateTime? Datebirth { get; set; }

        public virtual Pmast EmpnoNavigation { get; set; }
    }
}
