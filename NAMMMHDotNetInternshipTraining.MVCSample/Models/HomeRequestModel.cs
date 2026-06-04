namespace NAMMMHDotNetInternshipTraining.MVCSample.Models
{
    public class HomeRequestModel
    {
        public int pageNo { get; set; }

        public int pageSize { get; set; }
    }
    public class HomeResponseModel
    {
        
    }
    public class BlogListRequestModel
    {
       public int pageNo { get; set; } = 1;
       public int pageSize { get; set; } = 10;
        
    }
    public class BlogListResponseModel
    {
        public List<Blog> Data { get; set; }
        internal int pageCount { get; set; }
        internal int TotalRecords { get; set; }
        internal int pageNo { get; set; }
        internal int pageSize { get; set; }
       
    }
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }
    public class PaginationModel
    {
        public int TotalRecords { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public int pageCount { get; set; }
    }
    public class BlogCreateRequestModel
    {
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    public class BlogEditResponseModel
    {
        public Blog Data { get; set; }
    }
    public class BlogEditRequestModel
    {
        public int BlogId { get; set; }

    }
    public class BlogUpdateRequestModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    public class BlogDeleteRequestModel
    {
        public int BlogId { get; set; }
    }
    public class BlogDeleteResponseModel
    {
        public Blog Data { get; set; }
    }
    public class BlogCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
