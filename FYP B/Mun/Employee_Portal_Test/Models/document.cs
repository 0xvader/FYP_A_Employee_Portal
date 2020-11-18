using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Employee_Portal_Test.Models
{
    public class document
    {
        [Key]
        public int docID { get; set; }

        public string Empno2 { get; set; }
        public string docpath { get; set; }

        public string EMPNO { get; set; }
    }
}
