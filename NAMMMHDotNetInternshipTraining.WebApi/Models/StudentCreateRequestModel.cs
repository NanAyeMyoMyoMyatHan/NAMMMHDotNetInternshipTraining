namespace NAMMMHDotNetInternshipTraining.WebApi.Models
{
    public class StudentCreateRequestModel
    {
        public string StudentNo { get; set; } = null!;

        public string StudentName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedBy { get; set; } = null!;
    }
    public class StudentCreateResponseModel
    {
        public bool IsSuccess
        {
            get; set;
        }
        public string Message
        {
            get; set;
        }
    }
    public class StudentUpdateRequestModel
    {
        public string StudentNo { get; set; } = null!;

        public string StudentName { get; set; } = null!;

        public string FatherName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public bool IsDelete { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime? ModifiedDateTime { get; set; }

        public string ModifiedBy { get; set; } = null!;
    }
    public class StudentUpdateResponseModel
    {
        public bool IsSuccess
        {
            get; set;
        }
        public string Message
        {
            get; set;
        }
        public StudentModel Student
        {
            get; set;
        }
    }
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string StudentNo { get; set; } = null!;
        public string StudentName { get; set; } = null!;
        public string FatherName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? ModifiedDateTime { get; set; }
        public string ModifiedBy { get; set; } = null!;
    }
    public class StudentPatchRequestModel
    {
        public string? StudentNo { get; set; } = null!;

        public string? StudentName { get; set; } = null!;

        public string? FatherName { get; set; } = null!;

        public string? Address { get; set; } = null!;

        public DateTime? DateOfBirth { get; set; }

        public bool? IsDelete { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public string? CreatedBy { get; set; } = null!;

        public DateTime? ModifiedDateTime { get; set; }

        public string? ModifiedBy { get; set; } = null!;
    }
    public class StudentPatchResponseModel
    {
        public bool IsSuccess
        {
            get; set;
        }
        public string Message
        {
            get; set;
        }
        public StudentModel Student
        {
            get; set;
        }
    }
}
