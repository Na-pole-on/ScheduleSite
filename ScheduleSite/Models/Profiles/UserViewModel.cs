namespace ScheduleSite.Models.Profiles
{
    public class UserViewModel
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public RoleViewModel? UserRole { get; set; }
    }
}
