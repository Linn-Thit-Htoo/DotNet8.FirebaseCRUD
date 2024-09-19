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

        await blogService.AddBlogAsync(blog);
    }
}