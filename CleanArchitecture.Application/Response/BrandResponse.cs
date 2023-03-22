namespace CleanArchitecture.Application.Response
{
    public class BrandResponse
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
