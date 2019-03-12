using System;
using System.Collections.Generic;

namespace EwuConnect.Domain.Models.Profile
{
    public class PersonalBiography
    {
        public int Id { get; set; }
        public string TextBio { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}