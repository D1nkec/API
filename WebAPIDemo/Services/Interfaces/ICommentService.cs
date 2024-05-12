using WebAPIDemo.Helpers;
using WebAPIDemo.Models;

namespace WebAPIDemo.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllAsync(CommentQueryObject queryObject);
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, Comment commentModel);
        Task<Comment?> DeleteAsync(int id);
       
    }
}
