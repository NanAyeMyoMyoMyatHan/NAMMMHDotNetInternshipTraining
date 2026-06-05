using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NAMMMHDotNetInternshipTraining.EFCoreDB.AppDbModels;
using NAMMMHDotNetInternshipTraining.MVCSample.Models;

namespace NAMMMHDotNetInternshipTraining.MVCSample.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly  AppDbContext _appDbContext;
        public BlogAjaxController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            var lst = await _appDbContext.TblBlogs
           // .OrderByDescending(s=> s.BlogId)
            .Select(x => new
            {
                blogId = x.BlogId,
                blogTitle = x.BlogTitle,
                blogAuthor = x.BlogAuthor
            })
            .ToListAsync();

            return Json(lst);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(BlogCreateRequestModel requestModel)
        {
            var blog = new TblBlog
            {
                BlogTitle = requestModel.BlogTitle,
                BlogAuthor = requestModel.BlogAuthor,
                BlogContent = requestModel.BlogContent
            };
            await _appDbContext.TblBlogs.AddAsync(blog);
            var result = await _appDbContext.SaveChangesAsync();

            var response = new BlogCreateResponseModel
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Saving Successful." : "Saving Failed."
            };
            return Json(response);
        }
        [HttpGet]
        public async Task<IActionResult> EditData(int id)
        {
            var blog = await _appDbContext.TblBlogs.FirstOrDefaultAsync(x=>x.BlogId==id);
            if (blog == null)
            {
                return Json(new { IsSuccess = false, Message = "Blog not found." });
            }
            var responseModel = new BlogEditResponseModel
            {
                Data = new Blog
                {
                    BlogId = blog.BlogId,
                    BlogTitle = blog.BlogTitle,
                    Author = blog.BlogAuthor,
                    Content = blog.BlogContent
                }
            };
            return Json(responseModel);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.BlogId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateRequestModel requestModel)
        {
            if(requestModel is null)
            {
                return Json(new { IsSuccess = false, Message = "data is missing" });
            }
            var item = await _appDbContext .TblBlogs.
                FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Json(new { IsSuccess = false, Message = "Blog not found." });
            }

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

           
            var result = await _appDbContext.SaveChangesAsync();
            var response = new
            {
                IsSuccess = result > 0,
                Message = result > 0 ? "Updating Successful." : "Updating Failed."
            };
            return Json(response);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _appDbContext .TblBlogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
            {
                return Json(new { IsSuccess = false, Message = "Blog not found." });
            }

            _appDbContext.TblBlogs.Remove(item);
            var result = await _appDbContext.SaveChangesAsync();

            var response = new
            {
                IsSuccess = result > 0,

                Message = result > 0 ? "Deleting Successful." : "Deleting Failed."
            };
            return Json(response);
        }
    }
}
