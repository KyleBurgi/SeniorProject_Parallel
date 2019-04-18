using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EwuConnect.Domain.Models.Profile;

namespace EwuConnect.Domain.Models.Forum
{
    public class Response
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public List<Response> Responses { get; set; }
        public bool IsViewable { get; set; }

        [Required]
        public User User { get; set; }
        [ForeignKey("UserId")]
        [Required]
        public int UserId { get; set; }
    }
}
