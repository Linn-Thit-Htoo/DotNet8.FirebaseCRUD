﻿using DotNet8.FirebaseCRUD.ConsoleApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        BlogService blogService = new();
        var blog = new BlogModel()
        {
            BlogId = Guid.NewGuid().ToString(),
            BlogTitle = "Test Firebase Title edited",
            BlogAuthor = "Test Firebase Author edited",
            BlogContent = "Test Firebase Content edited"
        };

        //await blogService.AddBlogAsync(blog);

        await blogService.UpdateBlogAsync("-O78Tno7NMVTn0OPt0Zr", blog);

        var blogs = await blogService.GetBlogsAsync();
        foreach (var item in blogs)
        {
            Console.WriteLine($"Key: {item.Key}");
            Console.WriteLine($"Blog Id: {item.Value.BlogId}");
            Console.WriteLine($"Blog Title: {item.Value.BlogTitle}");
            Console.WriteLine($"Blog Author: {item.Value.BlogAuthor}");
            Console.WriteLine($"Blog Content: {item.Value.BlogContent}");
            Console.WriteLine("------------------------------------");
        }
    }
}