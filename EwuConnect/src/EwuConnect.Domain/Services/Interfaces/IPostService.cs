using System.Collections.Generic;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Domain.Services.Interfaces
{ 
    public interface IPostService
    {
        Post AddPost(Post post);
        void UpdatePost(Post post);
        Post GetPost_Id(int id);
        List<Post> GetPost_UserId(int user_id);
        List<Post> GetBatchPosts();
        bool DeletePost(int id);
    }
}