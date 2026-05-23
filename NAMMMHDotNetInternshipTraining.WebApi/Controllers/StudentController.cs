using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAMMMHDotNetInternshipTraining.EFCoreSample2.DataBaseFirst.AppDbModels;
using NAMMMHDotNetInternshipTraining.WebApi.Models;

namespace NAMMMHDotNetInternshipTraining.WebApi.Controllers
{
    [Route("api/[controller]")] // This attribute defines the route template for the controller. The [controller] token will be replaced with the name of the controller, which in this case is "Blog". So, the route for this controller will be "api/Blog".
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext db = new AppDbContext();
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = db.TblStudents.ToList();
            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            var item = db.TblStudents.FirstOrDefault(x=> x.StudentId==id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateBlog(StudentCreateRequestModel requestModel)
        {
            db.TblStudents.Add(new TblStudent
            {
                StudentNo = requestModel.StudentNo,
                StudentName = requestModel.StudentName,
                FatherName = requestModel.FatherName,
                Address = requestModel.Address,
                DateOfBirth = requestModel.DateOfBirth,
                IsDelete = requestModel.IsDelete,
                CreatedDateTime = requestModel.CreatedDateTime,
                CreatedBy = requestModel.CreatedBy,
                ModifiedDateTime = requestModel.ModifiedDateTime,
                ModifiedBy = requestModel.ModifiedBy
            });
            var result = db.SaveChanges();
            return Ok (new StudentCreateResponseModel
            {
                IsSuccess = result > 0,
                Message =result> 0 ? "Blog created successfully" : "Failed to create blog"
            });
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, StudentUpdateRequestModel requestModel)
        {
            var item = db.TblStudents.FirstOrDefault(x => x.StudentId == 14);
            if (item == null)
            {
                return NotFound(new StudentUpdateResponseModel
                {
                    IsSuccess =false,
                    Message = "Blog not found"
                });
            }
            return Ok(new StudentUpdateResponseModel
            {
                IsSuccess =true,
                Message = "Blog updated successfully",
                Student = new StudentModel
                {
                    StudentNo = requestModel.StudentNo,
                    StudentName = requestModel.StudentName,
                    FatherName = requestModel.FatherName,
                    Address = requestModel.Address,
                    DateOfBirth = requestModel.DateOfBirth,
                    IsDelete = requestModel.IsDelete,
                    CreatedDateTime = requestModel.CreatedDateTime,
                    CreatedBy = requestModel.CreatedBy,
                    ModifiedDateTime = requestModel.ModifiedDateTime,
                    ModifiedBy = requestModel.ModifiedBy
                }
            });
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = db.TblStudents.FirstOrDefault(x => x.StudentId == 14);
            if (item == null)
            {
                return NotFound(new StudentUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog not found"
                        
                });
            }
            db.TblStudents.Remove(item);
            var result = db.SaveChanges();
            return Ok(new StudentUpdateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Blog Deleted successfully":"Failes to delete Blog"
            });
        }
        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, StudentPatchRequestModel studentPatchRequest)
        {
            var item = db.TblStudents.FirstOrDefault(x => x.StudentId == 14);
            if (item != null)
            {
                item.StudentNo = studentPatchRequest.StudentNo ?? item.StudentNo;
                item.StudentName = studentPatchRequest.StudentName ?? item.StudentName;
                item.FatherName = studentPatchRequest.FatherName ?? item.FatherName;
                item.Address = studentPatchRequest.Address ?? item.Address;
                item.DateOfBirth = studentPatchRequest.DateOfBirth ?? item.DateOfBirth;
                item.IsDelete = studentPatchRequest.IsDelete ?? item.IsDelete;
                item.CreatedDateTime = studentPatchRequest.CreatedDateTime ?? item.CreatedDateTime;
                item.CreatedBy = studentPatchRequest.CreatedBy ?? item.CreatedBy;
                item.ModifiedDateTime = studentPatchRequest.ModifiedDateTime ?? item.ModifiedDateTime;
                item.ModifiedBy = studentPatchRequest.ModifiedBy ?? item.ModifiedBy;
                var result = db.SaveChanges();
                return Ok(new StudentPatchResponseModel
                {
                    IsSuccess = result > 0,
                    Message = result > 0 ? "Blog patched successfully" : "Failed to patch blog"
                });
            }
            return NotFound(new StudentPatchResponseModel
            {
                IsSuccess = false,
                Message = "Blog not found"
            });
            int count = 0;
            if (!string.IsNullOrEmpty(studentPatchRequest.StudentNo))
            {
                count++;                            
                item.StudentNo = studentPatchRequest.StudentNo;
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.StudentName))
            {
                count++;
                item.StudentName = studentPatchRequest.StudentName;
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.FatherName))
            {
                count++;
                item.FatherName = studentPatchRequest.FatherName;
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.Address))
            {
                count++;
                item.Address = studentPatchRequest.Address;
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.DateOfBirth.ToString()))
            {
                count++;
                item.DateOfBirth = Convert.ToDateTime(studentPatchRequest.DateOfBirth);
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.IsDelete.ToString()))
            {
                count++;
                item.IsDelete = Convert.ToBoolean(studentPatchRequest.IsDelete);
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.CreatedDateTime.ToString()))
            {
                count++;
                item.CreatedDateTime = Convert.ToDateTime(studentPatchRequest.CreatedDateTime);
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.CreatedBy))
            {
                count++;
                item.CreatedBy = studentPatchRequest.CreatedBy;
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.ModifiedDateTime.ToString()))
            {
                count++;
                item.ModifiedDateTime = Convert.ToDateTime(studentPatchRequest.ModifiedDateTime);
            }
            if (!string.IsNullOrEmpty(studentPatchRequest.ModifiedBy))
            {
                count++;
                item.ModifiedBy = studentPatchRequest.ModifiedBy;
            }
            if(count == 0)
            {
                return NotFound(new StudentPatchResponseModel
                {
                    IsSuccess = false,
                    Message = "No fields to update"
                });
                var result = db.SaveChanges();
                return Ok(new StudentPatchResponseModel
                {
                    IsSuccess = result > 0,
                    Message = result > 0 ? "Blog patched successfully" : "Failed to patch blog"
                });
            }
        }
    }
}
