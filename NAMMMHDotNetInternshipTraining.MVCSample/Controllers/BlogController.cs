using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMMMHDotNetInternshipTraining.EFCoreDB.AppDbModels;
using NAMMMHDotNetInternshipTraining.MVCSample.Models;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace NAMMMHDotNetInternshipTraining.MVCSample.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
       public IActionResult Generate()
        {
            for (int i = 1; i <= 1000; i++)
            {
                TblBlog blog = new TblBlog
                {
                    
                    BlogTitle = $"Blog Title {i}",
                    Author = $"Blog Author {i}",
                    BlogContent = $"Blog Content {i}"
                };
                _appDbContext.TblBlogs.Add(blog);
            }
            _appDbContext.SaveChanges();
            return Redirect("/Blog");

        }
        public async Task<IActionResult> Index([FromQuery] BlogListRequestModel requestModel)
        {
            var query = _appDbContext.TblBlogs.AsQueryable(); // try to avoid fetching all records at once
            int rowCount=  await _appDbContext.TblBlogs.CountAsync();

            int pageNo = requestModel.pageNo;
            int pageSize = requestModel.pageSize;
            var lst = _appDbContext.TblBlogs
                .OrderByDescending(x => x.BlogId)
                .Skip((requestModel.pageNo - 1) * requestModel.pageSize)
                .Take(requestModel.pageSize)
                .ToList();
            BlogListResponseModel responseModel = new BlogListResponseModel();
            responseModel.pageCount = rowCount / pageSize;
            if(rowCount % pageSize > 0)
            {
                responseModel.pageCount ++;
            }
            responseModel.TotalRecords = rowCount;
            responseModel.pageNo = pageNo;
            responseModel.pageSize = pageSize;
            responseModel.Data = lst.Select(x => new Blog
            {
                BlogId = x.BlogId,
                BlogTitle = x.BlogTitle,
                Author = x.BlogAuthor,
                Content = x.BlogContent
            }).ToList();
            return View(responseModel);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(BlogCreateRequestModel requestModel)
        {
            _appDbContext.TblBlogs.Add(new TblBlog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            });
          var result= await _appDbContext.SaveChangesAsync();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] =result>0? "Blog created successfully!":"Blog create Failed";
            return Redirect("/Blog");
        }
        
        public async Task<IActionResult> Edit([FromQuery]BlogEditRequestModel requestModel)
        {
            var item = await _appDbContext.TblBlogs.FirstOrDefaultAsync(x => x.BlogId == requestModel.BlogId);
            if(item is null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "Blog Not found";
                return Redirect("/blog");
            }
            BlogEditResponseModel model = new BlogEditResponseModel()
            {
                Data = new Blog
                {
                    BlogTitle = item.BlogTitle,
                    Author = item.BlogAuthor,
                    Content = item.BlogContent,
                    BlogId = item.BlogId
                }
            };
            return View(model);
        }

        public async Task<IActionResult> Update(BlogUpdateRequestModel requestModel)
        {
            _appDbContext.TblBlogs.Add(new TblBlog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            });
            var result = await _appDbContext.SaveChangesAsync();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] = result > 0 ? "Blog updated successfully!" : "Blog update Failed";
            return Redirect("/Blog");
        }

        public async Task<IActionResult> Delete([FromQuery]BlogDeleteRequestModel requestModel)
        {
            var item =await _appDbContext.TblBlogs.FirstOrDefaultAsync(x => x.BlogId == requestModel.BlogId);
            if(item == null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "Blog Not found";
                return Redirect("/blog");
            }
            _appDbContext.TblBlogs.Remove(item);
            var result = await _appDbContext.SaveChangesAsync();
            TempData["IsSuccess"] = result > 0;
            TempData["Message"] = result > 0 ? "Blog delete successfully!" : "Blog delete Failed";
            return Redirect("/Blog");

        }

    }
}
