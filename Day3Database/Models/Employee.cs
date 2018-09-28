using System;
using System.Collections.Generic;
using System.Text;

namespace Day3Database.Models
{
    public class Employee
    {
        public Guid EmployeeID { get; set; }
        public string EmployeeName { get; set;}
        public Department Department { get; set; }
       // public DateTime? HireDate { get; set; }
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
