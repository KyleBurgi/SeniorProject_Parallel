using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EwuConnect.Domain.Services
{
    public class PostService : IPostService
    {
        private ApplicationDbContext DbContext { get; }

        public PostService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Post> AddPost(Post post)
        {
            DbContext.Posts.Add(post);
            await DbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            DbContext.Posts.Update(post);
            await DbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post> GetPost_Id(int id)
        {
            return await DbContext.Posts.FindAsync(id);
        }
        public async Task<List<Post>> GetPost_UserId(int userId)
        {
            return await DbContext.Posts.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<List<Post>> GetBatchPosts()   //Figure out how we want to implement
        {
            return await DbContext.Posts.ToListAsync();
        }

        public async Task<bool> DeletePost(int id)
        {
            Post foundPost = await DbContext.Posts.FindAsync(id);

            if (foundPost != null)
            {
                foundPost.IsViewable = false;
                await DbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
