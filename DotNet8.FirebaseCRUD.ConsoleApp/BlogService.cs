using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.FirebaseCRUD.ConsoleApp
{
    public class BlogService
    {
        private readonly string _firstBaseDbUrl = "https://blogcrud-b23cc-default-rtdb.firebaseio.com/";
        private readonly FirebaseClient _firebaseClient;

        public BlogService()
        {
            _firebaseClient = new(_firstBaseDbUrl);
        }

        public async Task AddBlogAsync(BlogModel blog)
        {
            try
            {
                string json = JsonConvert.SerializeObject(blog);
                await _firebaseClient.Child("Blogs").PostAsync(json);
                Console.WriteLine("Saving Successful.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
