using System;
using System.Collections.Generic;

#nullable disable

namespace MVCExample.Models
{
    public partial class Employee
    {
        public string EmpId { get; set; }
        public string EmpName { get; set; }
        public string Password { get; set; }
        public decimal EmpSalary { get; set; }
        public decimal Tds { get; set; }
        public decimal NetSalary { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}
