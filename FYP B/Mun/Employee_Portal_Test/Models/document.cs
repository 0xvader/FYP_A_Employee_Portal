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

        public string title{ get; set; }
        public string docpath { get; set; }

        public string EMPNO { get; set; }
    }
}
