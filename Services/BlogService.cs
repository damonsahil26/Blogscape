using Blogscape.Models;
using System.Text.Json;

namespace Blogscape.Services
{
    public class BlogService : IBlogService
    {
        public bool CreateBlog(Blog blog)
        {
            try
            {
                Random rnd = new Random();
                int id = rnd.Next(1001, 9999);
                string fileName = $"{id}.json";
                string filePath = Path.Combine(Directory.GetCurrentDirectory() + "//Data", fileName);
                CreateFile(fileName, filePath);

                var blogToAdd = new Blog
                {
                    Id = id,
                    Content = blog.Content,
                    Author = blog.Author,
                    ImageUrl = blog.ImageUrl,
                    PublishedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    Title = blog.Title,
                };

                var fileStream = JsonSerializer.Serialize<Blog>(blogToAdd);
                File.WriteAllText(filePath, fileStream);
                Console.WriteLine($"File {fileName} created successfully");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Service : {nameof(CreateBlog)} " + ex.Message);
                return false;
            }                
    }

        private static void CreateFile(string fileName, string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    Console.WriteLine($"File {fileName} created successfully.");
                }
            }
        }

        public bool DeleteBlog(int id)
        {
            try
            {
                string fileName = $"{id}.json";
                string filePath = Path.Combine(Directory.GetCurrentDirectory() +"//Data", fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine($"File {fileName} deleted successfully");
                    return true;
                }
                else
                {
                    Console.WriteLine($"File {fileName} doesn't exists");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Service : {nameof(DeleteBlog)} " + ex.Message);
                return false;
            }
        }

        public Blog GetBlogById(int id)
        {
            try
            {
                string fileName = $"{id}.json";
                string filePath = Path.Combine(Directory.GetCurrentDirectory() + "//Data", fileName);
                if (File.Exists(filePath))
                {
                    var fileData = File.ReadAllText(filePath);
                    var blog = JsonSerializer.Deserialize<Blog>(fileData);
                    return blog ?? new();
                }
                else
                {
                    Console.WriteLine($"File {fileName} doesn't exists");
                    return new();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Service : {nameof(GetBlogById)} " + ex.Message);
                return new();
            }
        }

        public List<Blog> GetBlogs()
        {
            List<Blog> dataList = new List<Blog>();
            string directoryPath = Directory.GetCurrentDirectory() + "\\Data";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string[] blogFiles = Directory.GetFiles(directoryPath, "*.json");
            foreach (string blogFile in blogFiles)
            {
                // Read the JSON file content
                string jsonContent = File.ReadAllText(blogFile);

                // Deserialize the JSON content to the specified type
                var data = JsonSerializer.Deserialize<Blog>(jsonContent);

                // Add the deserialized data to the list
                dataList.Add(data);
            }

            return dataList.OrderBy(x=>x.PublishedDate).ToList();
        }

        public bool UpdateBlog(Blog blog)
        {
            try
            {
                string fileName = $"{blog.Id}.json";
                string filePath = Path.Combine(Directory.GetCurrentDirectory() + "//Data", fileName);
                if (File.Exists(filePath))
                {
                    var blogToAdd = new Blog
                    {
                        Id = blog.Id,
                        Content = blog.Content,
                        Author = blog.Author,
                        ImageUrl = blog.ImageUrl,
                        LastUpdatedDate = DateTime.Now,
                        PublishedDate= blog.PublishedDate,
                        Title = blog.Title,
                    };

                    File.Delete(filePath);

                    CreateFile(fileName, filePath);

                    var fileStream = JsonSerializer.Serialize<Blog>(blogToAdd);
                    File.WriteAllText(filePath, fileStream);
                    Console.WriteLine($"File {fileName} updated successfully");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Service : {nameof(CreateBlog)} " + ex.Message);
                return false;
            }
        }
    }
}
