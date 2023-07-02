using BlogAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI2.Interfaces
{
    public interface IBlog
    {
        Task<IActionResult> CreateBlog(Blog blogRequest);
        Task<IActionResult> GetBlog(int id);
        Task<IActionResult> GetBlogLatest();
        Task<IActionResult> EditBlog(Blog blogRequest);
        Task<IActionResult> DeleteBlog(int id);
        Task<IActionResult> GetAllBlogs();
        Task<IActionResult> GetAllBlogIds();
        Task<IActionResult> UploadImage([FromForm] IFormFile file);
        Task<IActionResult> DeleteImage(string id);
        Task<IActionResult> GetAllImages();
    }
}
