using Microsoft.AspNetCore.Mvc;
using netRestApi;
using netRestApi.Models;

namespace netRestApiRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlogs()
        {
            List<BlogDataModel> lst = _db.Blogs.ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogDataModel? item = _db.Blogs.FirstOrDefault(ea => ea.Blog_Id == id);

            if (item == null)
            {
                return NotFound("No data Not found.");
            }

            return Ok(item);

        }

        [HttpPost]
        public IActionResult CreateBlogs(BlogDataModel blog)
        {

            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();

            string message = result > 0 ? "Create Successful" : "Create fail";
            return Ok(message);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlogs(int id, BlogDataModel blog)
        {

            BlogDataModel? item = _db.Blogs.FirstOrDefault(ea => ea.Blog_Id == id);

            if (item == null)
            {
                return NotFound("No data Not found.");
            }

            item.Blog_Author = blog.Blog_Author;
            item.Blog_Content = blog.Blog_Content;
            item.Blog_Title = blog.Blog_Title;

            int result = _db.SaveChanges();

            string message = result >= 0 ? "Updateing Successful" : "Updateing Failed";

            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlogs(int id)
        {
            BlogDataModel? item = _db.Blogs.FirstOrDefault(ea => ea.Blog_Id == id);
            if (item == null)
            {
                return NotFound("No data Not found.");
            }

            _db.Blogs.Remove(item);

            int result = _db.SaveChanges();

            string message = result >= 0 ? "Deleting Successful" : "Deleting Failed";

            return Ok(message);
        }
    }

}