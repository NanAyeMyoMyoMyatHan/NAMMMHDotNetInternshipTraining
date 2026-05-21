using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMMMHDotNetInternshipTraining.AdoDotNetSample
{
    public class AdoDotNetSample
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
        public void ReadDataFromDatabase()
        {

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
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
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);


            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("No record found in the database");
                return;
            }
            connection.Close();
            List<Student> students = new List<Student>();

            foreach (DataRow row in dataTable.Rows)
            {
                Student item = new Student()
                {
                    StudentId = Convert.ToInt32(row["StudentId"]),
                    StudentNo = row["StudentNo"].ToString(),
                    StudentName = row["StudentName"].ToString(),
                    FatherName = row["FatherName"].ToString(),
                    Address = row["Address"].ToString(),
                    DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                    IsDelete = Convert.ToBoolean(row["IsDelete"]),
                    CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"]),// we are sure that this value is not null in the database, so we can directly convert it to DateTime
                    CreatedBy = row["CreatedBy"].ToString(),// we are sure that this value is not null in the database, so we can directly convert it to string
                    ModifiedDateTime = row["ModifiedDateTime"] == DBNull.Value ? null : Convert.ToDateTime(row["ModifiedDateTime"]), // if the value is null in the database, we set it to null in the object, otherwise we convert it to DateTime
                    ModifiedBy = row["ModifiedBy"].ToString()
                };
                students.Add(item);
                Console.WriteLine(item.StudentNo);
                Console.WriteLine(item.StudentName);
                Console.WriteLine(item.FatherName);
                Console.WriteLine(item.Address);
                Console.WriteLine(item.DateOfBirth.ToString("dd,MMMM,YYYY"));
            }




        }

        public void EditDataInDatabase()
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();
            int id = 1; // we want to edit the record with StudentId = 1
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
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();

            if (dataTable.Rows.Count == 0)
            {
                Console.WriteLine("No record found");
                return;
            }
            DataRow row = dataTable.Rows[0];
            Student item = new Student()
            {
                StudentId = Convert.ToInt32(row["StudentId"]),
                StudentNo = row["StudentNo"].ToString(),
                StudentName = row["StudentName"].ToString(),
                FatherName = row["FatherName"].ToString(),
                Address = row["Address"].ToString(),
                DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]),
                IsDelete = Convert.ToBoolean(row["IsDelete"]),
                CreatedDateTime = Convert.ToDateTime(row["CreatedDateTime"]),// we are sure that this value is not null in the database, so we can directly convert it to DateTime
                CreatedBy = row["CreatedBy"].ToString(),// we are sure that this value is not null in the database, so we can directly convert it to string
                ModifiedDateTime = row["ModifiedDateTime"] == DBNull.Value ? null : Convert.ToDateTime(row["ModifiedDateTime"]), // if the value is null in the database, we set it to null in the object, otherwise we convert it to DateTime
                ModifiedBy = row["ModifiedBy"].ToString()
            };

            Console.WriteLine(item.StudentNo);
            Console.WriteLine(item.StudentName);
            Console.WriteLine(item.FatherName);
            Console.WriteLine(item.Address);
            Console.WriteLine(item.DateOfBirth.ToString("dd,MMMM,YYYY"));



        }

        public void CreateDataInDatabase(Student student)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = @"
        INSERT INTO Tbl_Student
        (
            StudentNo,
            StudentName,
            FatherName,
            Address,
            DateOfBirth,
            IsDelete,
            CreatedDateTime,
            CreatedBy,
            ModifiedDateTime,
            ModifiedBy
        )
        VALUES
        (
            @StudentNo,
            @StudentName,
            @FatherName,
            @Address,
            @DateOfBirth,
            @IsDelete,
            @CreatedDateTime,
            @CreatedBy,
            @ModifiedDateTime,
            @ModifiedBy
        )";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentNo", student.StudentNo);
            command.Parameters.AddWithValue("@StudentName", student.StudentName);
            command.Parameters.AddWithValue("@FatherName", student.FatherName);
            command.Parameters.AddWithValue("@Address", student.Address);
            command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            command.Parameters.AddWithValue("@IsDelete", student.IsDelete);
            command.Parameters.AddWithValue("@CreatedDateTime", student.CreatedDateTime);
            command.Parameters.AddWithValue("@CreatedBy", student.CreatedBy);
            command.Parameters.AddWithValue("@ModifiedDateTime",
                student.ModifiedDateTime == null
                    ? DBNull.Value
                    : student.ModifiedDateTime);
            command.Parameters.AddWithValue("@ModifiedBy", student.ModifiedBy);

            int result = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0
                ? "Student created successfully."
                : "Insert failed.");
        }
        public void UpdateDataInDatabase(Student student)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = @"
        UPDATE Tbl_Student
        SET
            StudentNo = @StudentNo,
            StudentName = @StudentName,
            FatherName = @FatherName,
            Address = @Address,
            DateOfBirth = @DateOfBirth,
            IsDelete = @IsDelete,
            ModifiedDateTime = @ModifiedDateTime,
            ModifiedBy = @ModifiedBy
        WHERE StudentId = @StudentId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentId", student.StudentId);
            command.Parameters.AddWithValue("@StudentNo", student.StudentNo);
            command.Parameters.AddWithValue("@StudentName", student.StudentName);
            command.Parameters.AddWithValue("@FatherName", student.FatherName);
            command.Parameters.AddWithValue("@Address", student.Address);
            command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            command.Parameters.AddWithValue("@IsDelete", student.IsDelete);
            command.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Now);
            command.Parameters.AddWithValue("@ModifiedBy", student.ModifiedBy);

            int result = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0
                ? "Student updated successfully."
                : "Update failed.");
        }
        public void DeleteDataInDatabase(int id)
        {
            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            connection.Open();

            string query = @"
        UPDATE Tbl_Student
        SET
            IsDelete = 1,
            ModifiedDateTime = @ModifiedDateTime,
            ModifiedBy = @ModifiedBy
        WHERE StudentId = @StudentId";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentId", id);
            command.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Now);
            command.Parameters.AddWithValue("@ModifiedBy", "Admin");

            int result = command.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result > 0
                ? "Student deleted successfully."
                : "Delete failed.");
        }
    }
}
