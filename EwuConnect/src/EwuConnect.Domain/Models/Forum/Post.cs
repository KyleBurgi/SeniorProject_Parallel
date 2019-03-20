using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Models.Forum
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Content { get; set; }
        public List<Response> Responses { get; set; }
        public bool IsViewable { get; set; }
    }
}
