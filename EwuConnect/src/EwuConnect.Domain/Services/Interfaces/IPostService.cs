using System.Collections.Generic;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Domain.Services.Interfaces
{ 
    public interface IPostService
    {
        void AddPost(Post post);
        void UpdatePost(Post post);
        Post GetPost(int id);
        List<Post> GetBatchPost();
        bool DeletePost(int id);
    }
}