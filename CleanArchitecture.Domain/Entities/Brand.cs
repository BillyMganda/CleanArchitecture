using CleanArchitecture.Domain.Entities.Base;

namespace CleanArchitecture.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string BrandName { get; set; } = string.Empty;
    }
}
