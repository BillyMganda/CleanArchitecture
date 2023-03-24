namespace CleanArchitecture.Domain.DTOs.Users
{
    public class ModifyUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;        
    }
}
