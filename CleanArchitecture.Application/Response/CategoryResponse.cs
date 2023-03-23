namespace CleanArchitecture.Application.Response
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
