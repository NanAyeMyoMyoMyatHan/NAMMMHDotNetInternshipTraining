using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMMMHDotNetInternshipTraining.EFCoreSample
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=NAMMMHDotNetInternshipTraining;User Id=sa;Password=sasa@123;TrustServerCertificate=true;");
            }
        }
        public DbSet<Student> Students { get; set; }
    }
    [Table("Tbl_Student")]
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        public string StudentNo { get; set; }

        public string StudentName { get; set; }

        public string FatherName { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDateTime { get; set; }// allow null because when we create a new record, there is no modified date time

        public string ModifiedBy { get; set; }
    }
}
