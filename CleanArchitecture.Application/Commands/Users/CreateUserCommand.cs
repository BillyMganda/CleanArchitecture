using CleanArchitecture.Domain.DTOs.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Commands.Users
{
    public class CreateUserCommand : IRequest<GetUserDto>
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }
        public CreateUserCommand()
        {
            CreatedDate = DateTime.Now;
            ModifiedDate = DateTime.Now;
        }
    }
}
