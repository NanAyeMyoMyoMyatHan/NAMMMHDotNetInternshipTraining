using RestSharp;

RestClient client = new RestClient();

string baseUrl = "https://localhost:7006/api/student";

await Read();
await Create();
await Edit();
await Patch();
await Delete();

Console.ReadLine();

async Task Read()
{
    RestRequest request = new RestRequest(baseUrl, Method.Get);
    var response = await client.ExecuteAsync(request);
    if (response.IsSuccessful)
    {
        Console.WriteLine("Read Result");
        Console.WriteLine(response.Content);
    }
}
async Task Create()
{
    var requestModel = new BlogCreateRequestModel
    {
        BlogTitle = "New Blog Title",
        BlogAuthor = "Author Name",
        BlogContent = "This is the content of the new blog."
    };
    RestRequest request = new RestRequest(baseUrl, Method.Post);
    request.AddJsonBody(requestModel); // RestSharp will automatically serialize the requestModel object to JSON and set the appropriate content type header.

    var response = await client.ExecuteAsync(request);
    Console.WriteLine("Create Result");
    Console.WriteLine(response.Content);
}
async Task Edit()
{
    int id = 1;
    var requestModel = new BlogUpdateRequestModel
    {
        BlogTitle = "Updated Blog Title",
        BlogAuthor = "Updated Author Name",
        BlogContent = "This is the updated content of the blog."
    };
    RestRequest request = new RestRequest($"{baseUrl}/{id}", Method.Put);
    request.AddJsonBody(requestModel); // RestSharp will automatically serialize the requestModel object to JSON and set the appropriate content type header.
    var response = await client.ExecuteAsync(request);
    Console.WriteLine("Update Result");
    Console.WriteLine(response.Content);
}
async Task Patch()
{
    int id = 1;
    var requestModel = new BlogPatchRequestModel
    {
        BlogTitle = "Partially Updated Blog Title",
        BlogAuthor = "Partially Updated Author Name",
        BlogContent = "This is the partially updated content of the blog."
    };
    RestRequest request = new RestRequest($"{baseUrl}/{id}", Method.Patch);
    request.AddJsonBody(requestModel); // RestSharp will automatically serialize the requestModel object to JSON and set the appropriate content type header.
    var response = await client.ExecuteAsync(request);
    Console.WriteLine("Patch Result");
    Console.WriteLine(response.Content);
}
async Task Delete()
{
    int id = 1;
    RestRequest request = new RestRequest($"{baseUrl}/{id}", Method.Delete);
    var response = await client.ExecuteAsync(request);
    Console.WriteLine("Delete Result");
    Console.WriteLine(response.Content);
}
internal class BlogPatchRequestModel
{
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}

internal class BlogUpdateRequestModel
{
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}

internal class BlogCreateRequestModel
{
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}