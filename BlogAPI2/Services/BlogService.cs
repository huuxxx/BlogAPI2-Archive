using Amazon.DynamoDBv2.DataModel;
using BlogAPI2.Interfaces;
using BlogAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI2.Services
{
    public class BlogService : ControllerBase, IBlog
    {
        private readonly IDynamoDBContext _context;

        public BlogService(IDynamoDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CreateBlog(Blog blogRequest)
        {
            var latestBlog = await GetLastBlog();
            var id = latestBlog.Id + 1;
            blogRequest.Id = id;
            await _context.SaveAsync(blogRequest);
            return Ok();
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _context.LoadAsync<Blog>(id);
            if (blog == null) return NotFound();
            await _context.DeleteAsync(blog);
            return NoContent();
        }

        public async Task<IActionResult> EditBlog(Blog blogRequest)
        {
            var blog = await _context.LoadAsync<Blog>(blogRequest.Id);
            if (blog == null) return NotFound();
            await _context.SaveAsync(blogRequest);
            return Ok(blogRequest);
        }

        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _context.LoadAsync<Blog>(id);
            if (blog == null) return NotFound();
            return Ok(blog);
        }

        public async Task<IActionResult> GetBlogLatest()
        {
            var latestBlog = await GetLastBlog();
            return Ok(latestBlog);
        }

        public async Task<IActionResult> GetAllBlogIds()
        {
            List<ScanCondition> conditions = new();
            var blogs = await _context.ScanAsync<Blog>(conditions).GetRemainingAsync();
            var ids = blogs.OrderByDescending(x => x.Id).ToList().ToString();
            return Ok(ids);
        }

        public async Task<IActionResult> GetAllBlogs()
        {
            List<ScanCondition> conditions = new();
            var blogs = await _context.ScanAsync<Blog>(conditions).GetRemainingAsync();
            var orderedBlogs = blogs.OrderByDescending(x => x.Id);
            return Ok(orderedBlogs);
        }

        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            return Ok();
        }

        public async Task<IActionResult> DeleteImage(string id)
        {
            return Ok();
        }

        public async Task<IActionResult> GetAllImages()
        {
            return Ok();
        }

        private async Task<Blog> GetLastBlog()
        {
            List<ScanCondition> conditions = new();
            var blog = await _context.ScanAsync<Blog>(conditions).GetRemainingAsync();
            var lastBlog = blog.OrderByDescending(x => x.Id).FirstOrDefault();
            return lastBlog;
        }
    }
}
