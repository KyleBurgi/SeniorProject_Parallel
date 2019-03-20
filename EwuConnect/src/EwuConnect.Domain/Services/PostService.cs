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

        public void AddPost(Post post)
        {
            DbContext.Posts.Add(post);
            DbContext.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            DbContext.Posts.Update(post);
            DbContext.SaveChanges();
        }

        public Post GetPost(int id)
        {
            return DbContext.Posts
                .SingleOrDefault(u => u.Id == id);
        }

        public List<Post> GetBatchPost()   //Figure out how we want to implement
        {
            return null;
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
