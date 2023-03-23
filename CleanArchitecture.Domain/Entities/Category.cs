using CleanArchitecture.Domain.Entities.Base;

namespace CleanArchitecture.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}
