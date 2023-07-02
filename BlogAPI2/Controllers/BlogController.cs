using Amazon.DynamoDBv2.DataModel;
using BlogAPI2.Interfaces;
using BlogAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI2.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class BlogController : ControllerBase, IBlogService
    {
        private readonly IDynamoDBContext _context;

        public BlogController(IDynamoDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blogRequest)
        {
            //var blog = await _context.LoadAsync<Blog>(blogRequest.Id);
            //if (blog != null) return BadRequest($"Blog with Id {blogRequest.Id} Already Exists");
            await _context.SaveAsync(blogRequest);
            return Ok(blogRequest);
        }
    }
}
