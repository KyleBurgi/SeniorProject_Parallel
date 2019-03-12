using System;
namespace EwuConnect.Domain.Models.Profile
{
    public class MentorMenteePairing
    {
        public int Id { get; set; }
        public User Mentor { get; set; }
        public int MentorId { get; set; }
        public User Mentee { get; set; }
        public int MenteeId { get; set; }
    }
}
