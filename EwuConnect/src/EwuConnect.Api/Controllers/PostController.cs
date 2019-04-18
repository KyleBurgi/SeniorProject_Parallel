using System;
using System.Collections.Generic;
using AutoMapper;
using EwuConnect.Api.ViewModels;
using EwuConnect.Domain.Models.Forum;
using EwuConnect.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EwuConnect.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostService PostService { get; }

        private IMapper Mapper { get; }

        public PostController(IPostService postService)
        {
            PostService = postService ?? throw new ArgumentNullException(nameof(postService));
        }


        // POST api/<controller>
        [HttpPost]
        public ActionResult<PostViewModel> CreatePost(PostInputViewModel viewModel)      // null reference happening with viewModel
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            Post createdPost = PostService.AddPost(Mapper.Map<Post>(viewModel));

            return CreatedAtAction(nameof(Get_PostId),
                new { id = createdPost.Id },
                Mapper.Map<PostViewModel>(createdPost));
        }


        [HttpPut("{postId}")]
        public ActionResult<PostViewModel> UpdatePost(int postId, Post post)
        {
            if (postId < 0)
            {
                return BadRequest();
            }

            Post foundPost = PostService.GetPost_Id(postId);

            if (foundPost == null)
            {
                return NotFound();
            }

            foundPost.Title = post.Title;
            foundPost.Content = post.Content;
            PostService.UpdatePost(foundPost);

            return Ok(Mapper.Map<PostViewModel>(foundPost));
        }



        // GET api/<controller>/1
        [HttpGet("{userId}")]
        public ActionResult<ICollection<PostViewModel>> Get_UserId(int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }
            List<Post> foundPosts = PostService.GetPost_UserId(userId);

            if (foundPosts == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<PostViewModel>(foundPosts));
        }

        [HttpGet("{postId}")]
        public ActionResult<PostViewModel> Get_PostId(int postId)
        {
            if (postId < 0)
            {
                return BadRequest();
            }
            Post foundPost = PostService.GetPost_Id(postId);

            if (foundPost == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<PostViewModel>(foundPost));
        }
        [HttpGet()]
        public ActionResult<ICollection<PostViewModel>> GetAllPosts()
        {
            List<Post> foundPosts = PostService.GetBatchPosts();

            if (foundPosts == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<PostViewModel>(foundPosts));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{postId}")]
        public ActionResult DeletePost(int postId)
        {
            bool postWasDeleted = PostService.DeletePost(postId);
            return postWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }
    }
}
