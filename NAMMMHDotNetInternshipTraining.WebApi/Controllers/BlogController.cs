using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NAMMMHDotNetInternshipTraining.EFCoreSample2.DataBaseFirst.AppDbModels;
using NAMMMHDotNetInternshipTraining.WebApi.Models;

namespace NAMMMHDotNetInternshipTraining.WebApi.Controllers
{
    [Route("api/[controller]")] // This attribute defines the route template for the controller. The [controller] token will be replaced with the name of the controller, which in this case is "Blog". So, the route for this controller will be "api/Blog".
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _db.TblBlogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(item);

        }

        [HttpPost]
        public IActionResult CreateBlog(BlogCreateRequestModel requestModel)
        {
            _db.TblBlogs.Add(new TblBlog
            {
                BlogTitle=requestModel.BlogTitle,
                BlogAuthor=requestModel.BlogAuthor,
                BlogContent=requestModel.BlogContent
            });
            var result = _db.SaveChanges();
            return Ok(new BlogCreateResponseModel
            {
                IsSuccess = result > 0,
                Message = result>0 ? "Create Success":"Fail to Create"
            });
        }
        [HttpPut("{id}")]
        public IActionResult Update(BlogUpdateRequestModel requestModel, int id)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if(item == null)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog Not Found"
                });
            }
            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;
            var result = _db.SaveChanges();
            return Ok(new BlogUpdateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Update Success" : "Update Fail"
            });
        }
        [HttpDelete("{id}")]
         public IActionResult Delete(int id, BlogDeleteRequestModel requestModel)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if(item == null)
            {
                return NotFound(new BlogDeleteResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog Not Found"
                });
            }
            _db.TblBlogs.Remove(item);
            var result = _db.SaveChanges();
            return Ok(new BlogDeleteResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Delete Success" : "Delete Fail"
            });
        }
        [HttpPatch("{id}")]
        public IActionResult PatchData(int id,BlogUpdateRequestModel requestModel)
        {
            var item = _db.TblBlogs.FirstOrDefault(x => x.BlogId == id);
            if(item == null)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog Not Found"
                });
            }
            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;
            var result =_db.SaveChanges();
            return Ok(new BlogUpdateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Blog Patch Success " : "Patch fail"
            });
            int count = 0;
            if(! string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                count++;
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                count++;
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                count++;
                item.BlogContent = requestModel.BlogContent;
            }
            if (count == 0)
            {
                return NotFound(new BlogUpdateResponseModel
                {
                    IsSuccess = false,
                    Message = "Blog Not Found"
                });

                var results = _db.SaveChanges();
                return Ok(new BlogUpdateResponseModel
                {
                    IsSuccess = result > 0,
                     Message = result > 0 ? "Blog patched successfully" : "Failed to patch blog"
                      });

                }

        }
   
    }
}
