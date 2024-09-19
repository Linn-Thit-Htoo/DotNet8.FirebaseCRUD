using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.FirebaseCRUD.ConsoleApp
{
    public class BlogService
    {
        private readonly string _firstBaseDbUrl = "https://blogcrud-b23cc-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient _firebaseClient;
        private readonly string _resourceName = string.Empty;

        public BlogService()
        {
            _firebaseClient = new(_firstBaseDbUrl);
            _resourceName = "Blogs";
        }

        public async Task<List<KeyValuePair<string, BlogModel>>> GetBlogsAsync()
        {
            var blogs = await _firebaseClient.Child(_resourceName).OnceAsync<BlogModel>();
            var blogList = blogs.Select(blog => new KeyValuePair<string, BlogModel>(blog.Key, blog.Object)).ToList();

            return blogList;
        }

        public async Task AddBlogAsync(BlogModel blog)
        {
            try
            {
                string json = JsonConvert.SerializeObject(blog);
                await _firebaseClient.Child(_resourceName).PostAsync(json);
                Console.WriteLine("Saving Successful.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
