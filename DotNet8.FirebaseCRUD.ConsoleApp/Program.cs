using DotNet8.FirebaseCRUD.ConsoleApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        BlogService blogService = new();
        var blog = new BlogModel()
        {
            Id = Guid.NewGuid().ToString(),
            BlogTitle = "Test Firebase Title",
            BlogAuthor = "Test Firebase Author",
            BlogContent = "Test Firebase Content"
        };

        //await blogService.AddBlogAsync(blog);

        var blogs = await blogService.GetBlogsAsync();
        foreach (var item in blogs)
        {
            Console.WriteLine($"Key: {item.Key}");
            Console.WriteLine($"Id: {item.Value.Id}");
            Console.WriteLine($"Blog Title: {item.Value.BlogTitle}");
            Console.WriteLine($"Blog Author: {item.Value.BlogAuthor}");
            Console.WriteLine($"Blog Content: {item.Value.BlogContent}");
            Console.WriteLine("------------------------------------");
        }
    }
}