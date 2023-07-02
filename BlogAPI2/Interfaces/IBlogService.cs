using BlogAPI2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI2.Interfaces
{
    public interface IBlogService
    {
        Task<IActionResult> CreateBlog(Blog blogRequest);
        // GetBlog
        // GetBlogId
        // GetAllBlogs
        // GetBlogLatest
        // GetBlogCount
        // EditBlog
        // DeleteBlog
        // UploadImage
        // DeleteImage
        // GetAllImages
    }
}
