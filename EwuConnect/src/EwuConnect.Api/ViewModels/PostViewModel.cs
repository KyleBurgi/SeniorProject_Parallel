using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EwuConnect.Domain.Models.Forum;

namespace EwuConnect.Api.ViewModels
{
    public class PostViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Title { get; set; }

        public List<Response> Responses { get; set; }
        public bool IsViewable { get; set; }
    }
}
