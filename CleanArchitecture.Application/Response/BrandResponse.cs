namespace CleanArchitecture.Application.Response
{
    public class BrandResponse
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public DateOnly CreatedDate { get; set; }
        public DateOnly ModifiedDate { get; set; }
    }
}
