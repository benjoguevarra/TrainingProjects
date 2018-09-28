using Day3Database.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day3Database.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>
    {
        private readonly string insertStatement = @"INSERT INTO [Department] 
                            ( DeptID, DeptName, IsActive)
                            VALUES 
                            ( @deptID, @deptName, @isActive)";

        private readonly string updateStatement = @"UPDATE [Department] 
                            SET DeptName = @deptName, IsActive=@isActive
                            WHERE DeptID = @deptID";

        private readonly string deleteStatement = @"DELETE FROM [Department] WHERE DeptID = @deptID";

        private readonly string retrieveStatement = @"SELECT  DeptID, DeptName, IsActive FROM [Department] ";

        private readonly string retrieveFilter = @"WHERE DeptID = @deptID";

        protected override void LoadInsertParameters(SqlCommand command, Department newDept)
        {
            command.Parameters.Add("@deptID", SqlDbType.UniqueIdentifier).Value = newDept.DeptID;
            command.Parameters.Add("@deptName", SqlDbType.NVarChar, 50).Value = newDept.DeptName;
            command.Parameters.Add("@isActive", SqlDbType.Bit).Value = newDept.IsActive;
        }

        public DepartmentRepository()
        {
            base.InsertStatement = this.insertStatement;
            base.DeleteStatement = this.deleteStatement;
            base.UpdateStatement = this.updateStatement;
            base.RetrieveStatement = this.retrieveStatement + this.retrieveFilter;
            base.RetrieveAllStatement = this.retrieveStatement;
        }

        protected override void LoadDeleteParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@deptID", SqlDbType.UniqueIdentifier).Value = id;
        }

        protected override void LoadUpdateParameters(SqlCommand command, Department dept)
        {
            command.Parameters.Add("@deptID", SqlDbType.UniqueIdentifier).Value = dept.DeptID;
            command.Parameters.Add("@deptName", SqlDbType.NVarChar, 50).Value = dept.DeptName;
            command.Parameters.Add("@isActive", SqlDbType.NVarChar, 50).Value = dept.IsActive;
        }

        protected override Department LoadEntity(SqlDataReader reader)
        {
            var dept = new Department();
            dept.DeptID = reader.GetGuid(0);
            dept.DeptName = reader.GetString(1);
            dept.IsActive = reader.GetBoolean(2);
            return dept;
        }

        protected override void LoadRetrieveParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@deptID", SqlDbType.UniqueIdentifier).Value = id;
        }     

    }
}
