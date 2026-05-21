using System;
using NAMMMHDotNetInternshipTraining.AdoDotNetSample;

class Program
{
    static void Main(string[] args)
    {
        AdoDotNetSample ado = new AdoDotNetSample();

        ado.ReadDataFromDatabase();
        ado.EditDataInDatabase();

        Student newStudent = new Student()
        {
            StudentNo = "S011",
            StudentName = "Hla Hla",
            FatherName = "U Aung",
            Address = "Yangon",
            DateOfBirth = new DateTime(2001, 5, 10),
            IsDelete = false,
            CreatedDateTime = DateTime.Now,
            CreatedBy = "Admin",
            ModifiedDateTime = null,
            ModifiedBy = "Admin"
        };

        ado.CreateDataInDatabase(newStudent);

        Student updateStudent = new Student()
        {
            StudentId = 2,
            StudentNo = "S002",
            StudentName = "Updated Name",
            FatherName = "Updated Father",
            Address = "Mandalay",
            DateOfBirth = new DateTime(2000, 8, 15),
            IsDelete = false,
            ModifiedBy = "Admin"
        };

        ado.UpdateDataInDatabase(updateStudent);
        ado.DeleteDataInDatabase(2);
    }
}