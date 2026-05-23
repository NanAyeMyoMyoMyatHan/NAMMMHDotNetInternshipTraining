using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMMMHDotNetInternshipTraining.EFCoreSample
{
    public class EFCoreSample
    {
        private readonly AppDbContext _context;
        public EFCoreSample()
        {
            _context = new AppDbContext();
        }
        public void ReadStudents()
        {
            List<Student> students = _context.Students.ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"Student No: {student.StudentNo}, Student Name: {student.StudentName}");
            }
        }
        public void CreateStudent()
        {
            var student = new Student
            {
                StudentNo = "S001",
                StudentName = "John Doe",
                FatherName = "Richard Roe",
                Address = "123 Main St",
                DateOfBirth = new DateTime(2000, 1, 1),
                IsDelete = false,
                CreatedDateTime = DateTime.Now,
                CreatedBy = "Admin",
                ModifiedDateTime = DateTime.Now,
                ModifiedBy = "Admin"

            };
            _context.Students.Add(student);
            int result = _context.SaveChanges();
            Console.WriteLine(result > 0 ? "Seaving Successful." : "Saving Failed");
        }
        public void UpdateStudent()
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == 1);
            if (student != null)
            {
                student.Address = "456 Elm St";
                student.ModifiedDateTime = DateTime.Now;
                student.ModifiedBy = "Admin";
                int result = _context.SaveChanges();
                Console.WriteLine(result > 0 ? "Update Successful." : "Update Failed");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void DeleteStudent()
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == 1);
            if (student != null)
            {
                student.IsDelete = true;
                student.ModifiedDateTime = DateTime.Now;
                student.ModifiedBy = "Admin";
                int result = _context.SaveChanges();
                Console.WriteLine(result > 0 ? "Delete Successful." : "Delete Failed");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void EditSutdent()
        {
            var student = _context.Students.FirstOrDefault(s => s.StudentId == 1);
            if (student != null)
            {
                Console.WriteLine(JsonConvert.SerializeObject(student));
                Console.WriteLine(JsonConvert.SerializeObject(student, Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
