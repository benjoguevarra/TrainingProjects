using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Database.Models
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set;}
        public string DeptID { get; set; }
        /* {
             get
             {
                 return DeptID;
             }
             set
             {
                    
             }
         } */


    }
}
