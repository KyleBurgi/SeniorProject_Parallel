using System;
using System.Collections.Generic;
using System.Linq;
using EwuConnect.Domain.Models;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Services.Interfaces;

namespace EwuConnect.Domain.Services
{
    class PostService : IPostService
    {
        private ApplicationDbContext DbContext { get; }

        public PostService(ApplicationDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Post AddPost(Post post)
        {
            DbContext.Posts.Add(post);
            DbContext.SaveChanges();
            return post;
        }

        public void UpdatePost(Post post)
        {
            DbContext.Posts.Update(post);
            DbContext.SaveChanges();
        }

        public Post GetPost_Id(int id)
        {
            return DbContext.Posts
                .SingleOrDefault(p => p.Id == id);
        }
        public List<Post> GetPost_UserId(int userId)
        {
            return DbContext.Posts.Where(p => p.UserId == userId).ToList();
        }

        public List<Post> GetBatchPosts()   //Figure out how we want to implement
        {
            return DbContext.Posts.ToList();
        }

        public bool DeletePost(int id)
        {
            Post foundPost = DbContext.Posts.Find(id);

            if (foundPost != null)
            {
                foundPost.IsViewable = false;
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
