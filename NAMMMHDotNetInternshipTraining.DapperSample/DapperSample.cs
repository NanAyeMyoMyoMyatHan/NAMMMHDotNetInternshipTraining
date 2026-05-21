using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMMMHDotNetInternshipTraining.DapperSample
{

    internal class DapperSample
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "NAMMMHDotNetInternshipTraining",
            IntegratedSecurity = true,
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true


        };
        public void Read()
        {
            string query = @"SELECT [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [dbo].[Tbl_Student] Where IsDelete = 0";
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();
                var lst = db.Query<Student>(query).ToList(); // Dapper will automatically map the columns from the query result to the properties of the Student class based on their names. It will create a list of Student objects and populate their properties with the corresponding values from the database.
                foreach (var item in lst)
                {
                    Console.WriteLine($"StudentId: {item.StudentId}, StudentNo: {item.StudentNo}, StudentName: {item.StudentName}, FatherName: {item.FatherName}, Address: {item.Address}, DateOfBirth: {item.DateOfBirth}, IsDelete: {item.IsDelete}, CreatedDateTime: {item.CreatedDateTime}, CreatedBy: {item.CreatedBy}, ModifiedDateTime: {item.ModifiedDateTime}, ModifiedBy: {item.ModifiedBy}");
                }

            }
        }
        public void Edit()
        {
            string query = $@"SELECT [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [dbo].[Tbl_Student] Where StudentId = @StudentId and IsDelete =0 ";
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();
                var item = db.Query<Student>(query,new Student {StudentId =1}).FirstOrDefault(); // Dapper will automatically map the columns from the query result to the properties of the Student class based on their names. It will create a list of Student objects and populate their properties with the corresponding values from the database.
                if (item is null)
                {
                    Console.WriteLine("No record found with the specified StudentId.");

                }
                else
                {
                    Console.WriteLine($"StudentId: {item.StudentId}, StudentNo: {item.StudentNo}, StudentName: {item.StudentName}, FatherName: {item.FatherName}, Address: {item.Address}, DateOfBirth: {item.DateOfBirth}, IsDelete: {item.IsDelete}, CreatedDateTime: {item.CreatedDateTime}, CreatedBy: {item.CreatedBy}, ModifiedDateTime: {item.ModifiedDateTime}, ModifiedBy: {item.ModifiedBy}");
                }                   }
        }
        public void Delete()
        {
            string query = $@"SELECT [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [dbo].[Tbl_Student] Where StudentId = @StudentId and IsDelete =0 ";
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();
                
            }

        }
        public void Create(Student student)
        {
            string query = @"
                INSERT INTO [dbo].[Tbl_Student]
                (
                    [StudentNo], [StudentName], [FatherName], [Address], 
                    [DateOfBirth], [IsDelete], [CreatedDateTime], [CreatedBy],[ModifiedDateTime],[ModifiedBy]
                )
                VALUES
                (
                    @StudentNo, @StudentName, @FatherName, @Address, 
                    @DateOfBirth, @IsDelete, @CreatedDateTime, @CreatedBy,@ModifiedDateTime,@ModifiedBy
                );";

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();

                // Dapper tip: Pass the 'student' object directly. 
                // Dapper will automatically match the properties to the @parameters in your query!
                int rowsAffected = db.Execute(query, student);

                Console.WriteLine(rowsAffected > 0
                    ? "Student created successfully via Dapper."
                    : "Insert failed.");
            }
        }

        public void Update(Student student)
        {
            string query = @"
                UPDATE [dbo].[Tbl_Student]
                SET
                    [StudentNo] = @StudentNo,
                    [StudentName] = @StudentName,
                    [FatherName] = @FatherName,
                    [Address] = @Address,
                    [DateOfBirth] = @DateOfBirth,
                    [IsDelete] = @IsDelete,
                    [ModifiedDateTime] = @ModifiedDateTime,
                    [ModifiedBy] = @ModifiedBy
                WHERE [StudentId] = @StudentId";

            // Update modification parameters right before executing
            student.ModifiedDateTime = DateTime.Now;

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();

                // Dapper maps everything automatically from your 'student' object
                int rowsAffected = db.Execute(query, student);

                Console.WriteLine(rowsAffected > 0
                    ? "Student updated successfully via Dapper."
                    : "Update failed.");
            }
        }

        public void Delete(int studentId)
        {
            // Performing a logical delete (Soft Delete) matching your IsDelete = 0 approach
            string query = @"
                UPDATE [dbo].[Tbl_Student]
                SET 
                    [IsDelete] = 1,
                    [ModifiedDateTime] = @ModifiedDateTime,
                    [ModifiedBy] = @ModifiedBy
                WHERE [StudentId] = @StudentId AND [IsDelete] = 0";

            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            {
                db.Open();

                // For a single parameter, pass an anonymous object: new { ParameterName = value }
                int rowsAffected = db.Execute(query, new
                {
                    StudentId = studentId,
                    ModifiedDateTime = DateTime.Now,
                    ModifiedBy = "Admin"
                });

                Console.WriteLine(rowsAffected > 0
                    ? "Student soft-deleted successfully via Dapper."
                    : "Delete failed (Student not found or already deleted).");
            }
        }
    }
}
