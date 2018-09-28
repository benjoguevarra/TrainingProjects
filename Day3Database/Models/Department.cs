using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Database.Models
{
    public class Department
    {
        public Guid DeptID { get; set; }
        public string DeptName { get; set; }
        public bool IsActive { get; set; }
    }
}
