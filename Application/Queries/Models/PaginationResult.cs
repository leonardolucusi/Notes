namespace Notes.Application.Queries.Models
{
    public class PaginationResult<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<T>? Items { get; set; }
    }
}
