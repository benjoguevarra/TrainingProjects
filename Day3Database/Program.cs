using Day3Database.Models;
using Day3Database.Repositories; // benjo
using System;
using System.Collections;
using System.Collections.Generic;

namespace Day3Database
{
    class Program
    {
        static void Main(string[] args) //push 2
        {
            #region createEmp
            var emp = CreateEmp("New Benjo", new Guid("67c3d0e7-d64c-45bc-a3c9-42060f3e12d7"));
            var emps = RetrieveEmp(emp.EmployeeID);
            UpdateEmp(emps);
           var allEmp = RetrieveAllEmp();
           allEmp.ForEach( (empx) => DeleteEmp(empx.EmployeeID) );
            #endregion

            #region createDepartment
            var dep = CreateDept("Accounting",true);
            CreateDept("IT", true);
            CreateDept("Faculty", true);

            var dept = RetrieveDept(dep.DeptID);

            UpdateDept(dept);

            var allDept = RetrieveAllDept();

          //  allDept.ForEach((depx) => DeleteDept(depx.DeptID));
            #endregion

            #region createapplicant
            /*
            var benjo = CreateApplicant("benjo", "de jesus", "guevarra", DateTime.Parse("1974-03-26"));
            CreateApplicant("x", "y", "z", DateTime.Parse("1974-03-26"));
            CreateApplicant("1", "2", "3", DateTime.Parse("1974-03-26"));
            CreateApplicant("a", "b", "c", DateTime.Parse("1974-03-26"));


            var applicant = RetrieveApplicant(benjo.ApplicantId);

            UpdateApplicant(applicant);

            var allApplicants = RetrieveAllApplicants();

            allApplicants.ForEach((a) => DeleteApplicant(a.ApplicantId));
            */
            #endregion

            Console.ReadLine();
        }

        #region applicant
        static Applicant CreateApplicant(string firstName, string lastName,
           string middleName, DateTime birthDate)
        {
            var applicant = new Applicant
            {
                ApplicantId = Guid.NewGuid(),
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                BirthDate = birthDate
            };

            var repository = new ApplicantRepository();
            var newApplicant = repository.Create(applicant);
            return newApplicant;
        }
        private static void UpdateApplicant(Applicant applicant)
        {
            applicant.FirstName = "Benjo 1";
            var repository = new ApplicantRepository();
            repository.Update(applicant);
        }

        private static List<Applicant> RetrieveAllApplicants()
        {
            var repository = new ApplicantRepository();
            return repository.Retrieve();
        }

        private static Applicant RetrieveApplicant(Guid applicantId)
        {
            var repository = new ApplicantRepository();
            return repository.Retrieve(applicantId);
        }

        private static void DeleteApplicant(Guid applicantId)
        {
            var repository = new ApplicantRepository();
            repository.Delete(applicantId);
        }
        #endregion

        #region employee
        static Employee CreateEmp(string empName, Guid deptID)
        {
            var emp = new Employee();
            emp.EmployeeID = Guid.NewGuid();
            emp.EmployeeName = empName;
            emp.Department = new Department();
            emp.Department.DeptID = deptID;

            var repo = new EmployeeRepository();
            var newEmp = repo.Create(emp);

            return newEmp;
        }

        private static void UpdateEmp(Employee emp)
        {
            emp.EmployeeName = "New Benjo Guevarra";
            var repo = new EmployeeRepository();
            repo.Update(emp);
        }

        private static Employee RetrieveEmp(Guid empID)
        {
            var repo = new EmployeeRepository();
            return repo.Retrieve(empID);
        }

        private static void DeleteEmp(Guid empID)
        {
            var repo = new EmployeeRepository();
            repo.Delete(empID);
        }

        private static List<Employee> RetrieveAllEmp()
        {
            var repo = new EmployeeRepository();
            return repo.Retrieve();
        }
        #endregion

        #region dept
        static Department CreateDept(string deptName, bool isActive)
        {
            var dept = new Department();
            dept.DeptID = Guid.NewGuid();
            dept.DeptName = deptName;
            dept.IsActive = isActive;
                 
            var repo = new DepartmentRepository();
            var newDept = repo.Create(dept);

            return newDept;
        }

        private static void UpdateDept(Department dept)
        {
            dept.DeptName = "New Dept";
            var repo = new DepartmentRepository();
            repo.Update(dept);
        }

        private static Department RetrieveDept(Guid deptID)
        {
            var repo = new DepartmentRepository();
            return  repo.Retrieve(deptID);
        }

        private static List<Department> RetrieveAllDept()
        {
            var repo = new DepartmentRepository();
            return repo.Retrieve();
        }

        private static void DeleteDept(Guid deptID)
        {
            var repo = new DepartmentRepository();
            repo.Delete(deptID);
        }
        #endregion
    }
}
