namespace EwuConnect.Domain.Models.Profile
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}