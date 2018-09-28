using Day3Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day3Database.Repositories
{
    class EmployeeRepository : RepositoryBase<Employee>
    {
        private readonly string insertStatement = @"INSERT INTO [Employee] 
                            (EmployeeID, EmployeeName, DeptID)
                            VALUES 
                            ( @employeeID, @employeeName, @deptID)";

        private readonly string updateStatement = @"UPDATE [Employee] 
                            SET EmployeeName = @employeeName, DeptID=@deptID
                            WHERE EmployeeID = @employeeID";

        private readonly string deleteStatement = @"DELETE FROM [Employee] WHERE EmployeeID = @employeeID";

        private readonly string retrieveStatement = @"SELECT  EmployeeID, EmployeeName, DeptID FROM [Employee] ";

        private readonly string retrieveFilter = @"WHERE EmployeeID = @employeeID";

        public EmployeeRepository()
        {
            base.InsertStatement = this.insertStatement;
            base.DeleteStatement = this.deleteStatement;
            base.UpdateStatement = this.updateStatement;
            base.RetrieveStatement = this.retrieveStatement + this.retrieveFilter;
            base.RetrieveAllStatement = this.retrieveStatement;
        }

        protected override void LoadDeleteParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier).Value = id;

        }

        protected override Employee LoadEntity(SqlDataReader reader)
        {
            var emp = new Employee();
            emp.EmployeeID = reader.GetGuid(0);
            emp.EmployeeName = reader.GetString(1);
            emp.DeptID = reader.GetString(2);
            return emp;
        }

        protected override void LoadInsertParameters(SqlCommand command, Employee emp)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier).Value = emp.EmployeeID;
            command.Parameters.Add("@employeeName", SqlDbType.NVarChar, 50).Value = emp.EmployeeName;
            command.Parameters.Add("@deptID", SqlDbType.NVarChar,50).Value = emp.DeptID;
        }

        protected override void LoadRetrieveParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier).Value = id;
        }

        protected override void LoadUpdateParameters(SqlCommand command, Employee emp)
        {
            command.Parameters.Add("@employeeID", SqlDbType.UniqueIdentifier).Value = emp.EmployeeID;
            command.Parameters.Add("@employeeName", SqlDbType.NVarChar, 50).Value = emp.EmployeeName;
            command.Parameters.Add("@deptID", SqlDbType.NVarChar, 50).Value = emp.DeptID;
        }
    }
}
