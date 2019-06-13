﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EwuConnect.Api.ViewModels
{
    public class LoginInputViewModel
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}