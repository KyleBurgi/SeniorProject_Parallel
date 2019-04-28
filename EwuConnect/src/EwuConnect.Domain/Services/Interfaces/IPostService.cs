using System.Collections.Generic;
using System.Threading.Tasks;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Domain.Services.Interfaces
{ 
    public interface IPostService
    {
        Task<Post> AddPost(Post post);
        Task<Post> UpdatePost(Post post);
        Task<Post> GetPost_Id(int id);
        Task<List<Post>> GetPost_UserId(int user_id);
        Task<List<Post>> GetBatchPosts();
        Task<bool> DeletePost(int id);
    }
}