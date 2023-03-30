using CleanArchitecture.Domain.DTOs.Users;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Application.Commands.Users
{
    public class EditUserCommand : IRequest<GetUserDto>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        [JsonIgnore]
        public DateTime ModifiedDate { get; set; }
        public EditUserCommand()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}
