using CleanArchitecture.Application.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Commands.Stores
{
    public class EditStoreCommand : IRequest<StoreResponse>
    {
        public string StoreName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public DateTime ModifiedDate { get; set; }
        public EditStoreCommand()
        {
            ModifiedDate = DateTime.Now;
        }
    }
}
