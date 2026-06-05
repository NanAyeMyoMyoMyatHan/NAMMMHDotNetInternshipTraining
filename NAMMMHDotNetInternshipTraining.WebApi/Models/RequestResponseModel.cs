namespace NAMMMHDotNetInternshipTraining.WebApi.Models
{

    public class Blog
    {
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogAuthor { get; set; }
    }

    public class BlogCreateRequestModel
    {
       
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    public class BlogCreateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class BlogUpdateRequestModel
    {
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    public class BlogUpdateResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
     public class BlogDeleteRequestModel
    {
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
    public class BlogDeleteResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }


    
}
