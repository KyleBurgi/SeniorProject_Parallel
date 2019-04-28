using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<ActionResult<PostViewModel>> CreatePost(PostInputViewModel viewModel)      // null reference happening with viewModel
        {
            if (viewModel == null)
            {
                return BadRequest();
            }

            Post createdPost = await PostService.AddPost(Mapper.Map<Post>(viewModel));

            return CreatedAtAction(nameof(Get_PostId),
                new { id = createdPost.Id },
                Mapper.Map<PostViewModel>(createdPost));
        }


        [HttpPut("{postId}")]
        public async Task<ActionResult<PostViewModel>> UpdatePost(int postId, Post post)
        {
            if (postId < 0)
            {
                return BadRequest();
            }

            Post foundPost = await PostService.GetPost_Id(postId);

            if (foundPost == null)
            {
                return NotFound();
            }

            foundPost.Title = post.Title;
            foundPost.Content = post.Content;
            await PostService.UpdatePost(foundPost);

            return NoContent();
        }



        // GET api/<controller>/1
        [HttpGet("{userId}")]
        public async Task<ActionResult<ICollection<PostViewModel>>> Get_UserId(int userId)
        {
            if (userId < 0)
            {
                return BadRequest();
            }
            List<Post> foundPosts = await PostService.GetPost_UserId(userId);

            if (foundPosts == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<PostViewModel>(foundPosts));
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<PostViewModel>> Get_PostId(int postId)
        {
            if (postId < 0)
            {
                return BadRequest();
            }
            Post foundPost = await PostService.GetPost_Id(postId);

            if (foundPost == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<PostViewModel>(foundPost));
        }
        [HttpGet()]
        public async Task<ActionResult<ICollection<PostViewModel>>> GetAllPosts()
        {
            List<Post> foundPosts = await PostService.GetBatchPosts();

            if (foundPosts == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<PostViewModel>(foundPosts));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{postId}")]
        public async Task<ActionResult> DeletePost(int postId)
        {
            bool postWasDeleted = await PostService.DeletePost(postId);
            return postWasDeleted ? (ActionResult)Ok() : (ActionResult)NotFound();
        }
    }
}
