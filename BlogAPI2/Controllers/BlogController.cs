using BlogAPI2.Interfaces;
using BlogAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI2.Controllers
{
    [ApiController, Route("api/[controller]/[action]")]
    public class BlogController : ControllerBase, IBlog
    {
        private readonly IBlog _blogService;

        public BlogController(IBlog blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blogRequest)
        {
            var blog = await _blogService.CreateBlog(blogRequest);
            return Ok(blog);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var result = await _blogService.DeleteBlog(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditBlog(Blog blogRequest)
        {
            var blog = await _blogService.EditBlog(blogRequest);
            return Ok(blog);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogs()
        {
            var blogs = await _blogService.GetAllBlogs();
            return Ok(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _blogService.GetBlog(id);
            return Ok(blog);
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogLatest()
        {
            var blog = await _blogService.GetBlogLatest();
            return Ok(blog);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogIds()
        {
            var ids = await _blogService.GetAllBlogIds();
            return Ok(ids);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            //throw new NotImplementedException();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(string id)
        {
            //throw new NotImplementedException();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            //throw new NotImplementedException();
            return Ok();
        }
    }
}
