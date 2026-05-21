using NAMMMHDotNetInternshipTraining.DapperSample;

DapperSample dapperSample = new DapperSample(); 
dapperSample.Read();
dapperSample.Edit();

Student newStudent = new Student()
{
    StudentNo = "S013",
    StudentName = "Hnin Hnin",
    FatherName = "U Aung",
    Address = "Yangon",
    DateOfBirth = new DateTime(2001, 5, 10),
    IsDelete = false,
    CreatedDateTime = DateTime.Now,
    CreatedBy = "Admin",
    ModifiedDateTime = null,
    ModifiedBy = "Admin"
};
dapperSample.Create(newStudent);
Student newStudent1 = new Student()
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
dapperSample.Update(newStudent1);
dapperSample.Delete(12);

