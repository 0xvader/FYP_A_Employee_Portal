using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Portal_Test.Models
{
    public partial class doc
    {
        [Key]
        public int docID { get; set; }

        public string title { get; set; }
        public string docpath { get; set; }

        public string EMPNO { get; set; }
        public string DocType { get; set; }
    }
}
