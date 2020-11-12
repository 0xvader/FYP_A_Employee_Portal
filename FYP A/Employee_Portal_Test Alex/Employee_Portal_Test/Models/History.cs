using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Portal_Test.Models
{
    public partial class History
    {
        [Key]
        public int Id { get; set; }
        public string Empno { get; set; }
        public DateTime? Date { get; set; }
    }
}
