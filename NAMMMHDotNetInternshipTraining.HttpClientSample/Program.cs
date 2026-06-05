using Newtonsoft.Json;

HttpClient client = new HttpClient();
string baseUrl = "https://localhost:7006/api/student";

await Read();
await Edit();
await Patch();
await Create();
await Delete();

Console.ReadLine();

async Task Read()
{
    var response = await client.GetAsync(baseUrl);
    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Read Result");
        Console.WriteLine(content);
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
    string jsonRequest = JsonConvert.SerializeObject(requestModel);
    var stringContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
    
    var response = await client.PostAsync(baseUrl, stringContent);

    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Create Result");
    Console.WriteLine(content);
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
    string jsonRequest = JsonConvert.SerializeObject(requestModel);
    var stringContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");

    var response = await client.PutAsync($"{baseUrl}/{id}", stringContent); // Assuming 1 is the ID of the blog to update
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Update Result");
    Console.WriteLine(content);
}
async Task Patch()
{
    int id = 1;
    var requestModel = new BlogPatchRequestModel
    {
        BlogTitle = "Partially Updated Blog Title"
    };
    string jsonRequest = JsonConvert.SerializeObject(requestModel);
    var stringContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
    var response = await client.PatchAsync($"{baseUrl}/{id}", stringContent); // Assuming 1 is the ID of the blog to patch

    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Patch Result");
    Console.WriteLine(content);
}
async Task Delete()
{
    int id = 1;
    var response = await client.DeleteAsync($"{baseUrl}/{id}"); // Assuming 1 is the ID of the blog to delete
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Delete Result");
    Console.WriteLine(content);
}
internal class BlogPatchRequestModel
{
    public string BlogTitle { get; set; }
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