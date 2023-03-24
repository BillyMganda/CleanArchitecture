using CleanArchitecture.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public class Store : BaseEntity
    {
        public string StoreName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
    }
}
