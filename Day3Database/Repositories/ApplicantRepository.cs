using Day3Database.Models;
using System;
using System.Collections.Generic; // benjo
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day3Database.Repositories
{
    public class ApplicantRepository : RepositoryBase<Applicant>
    {
        private readonly string insertStatement = @"INSERT INTO [Applicant] 
                            ( ApplicantID, FirstName, MiddleName, LastName,BirthDate)
                            VALUES 
                            ( @applicantID, @firstName, @middleName, @lastName, @birthDate )";

        private readonly string updateStatement = @"UPDATE [Applicant] 
                            SET FirstName = @firstName,  MiddleName = @middleName,  LastName = @lastName, BirthDate = @birthDate
                            WHERE ApplicantID = @applicantID";

        private readonly string deleteStatement = @"DELETE FROM [Applicant] WHERE ApplicantID = @applicantID";

        private readonly string retrieveStatement = @"SELECT  ApplicantID, FirstName, MiddleName, LastName, BirthDate FROM [Applicant] ";

        private readonly string retrieveFilter = @"WHERE ApplicantID = @applicantID";

        protected override void LoadInsertParameters(SqlCommand command, Applicant newApplicant)
        {
            command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier).Value = newApplicant.ApplicantId;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50).Value = newApplicant.FirstName;
            command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50).Value = newApplicant.MiddleName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50).Value = newApplicant.LastName;
            command.Parameters.Add("@birthDate", SqlDbType.Date).Value = newApplicant.BirthDate;
        }

        public ApplicantRepository()
        {
            base.InsertStatement = this.insertStatement;
            base.DeleteStatement = this.deleteStatement;
            base.UpdateStatement = this.updateStatement;
            base.RetrieveStatement = this.RetrieveStatement+ this.retrieveFilter;
            base.RetrieveAllStatement = this.RetrieveAllStatement;
        }

        protected override void LoadDeleteParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("applicationID", SqlDbType.UniqueIdentifier).Value = id;
        }

 
        protected override void LoadUpdateParameters(SqlCommand command, Applicant applicant)
        {
            command.Parameters.Add("@applicantID", SqlDbType.UniqueIdentifier).Value = applicant.ApplicantId;
            command.Parameters.Add("@firstName", SqlDbType.NVarChar, 50).Value = applicant.FirstName;
            command.Parameters.Add("@middleName", SqlDbType.NVarChar, 50).Value = applicant.MiddleName;
            command.Parameters.Add("@lastName", SqlDbType.NVarChar, 50).Value = applicant.LastName;
            command.Parameters.Add("@birthDate", SqlDbType.Date).Value = applicant.BirthDate;

        }

        protected override Applicant LoadEntity(SqlDataReader reader)
        {
            var applicant = new Applicant();
            applicant.ApplicantId = reader.GetGuid(0);
            applicant.FirstName = reader.GetString(1);
            applicant.MiddleName = reader.GetString(2);
            applicant.LastName = reader.GetString(3);
            applicant.BirthDate = reader.GetDateTime(4);
            return applicant;
        }

        protected override void LoadRetrieveParameters(SqlCommand command, Guid id)
        {
            command.Parameters.Add("@applicantID",SqlDbType.UniqueIdentifier).Value = id;
        }
        
    }
}
