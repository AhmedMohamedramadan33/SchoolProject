namespace School.Core.Paginated
{
    public class PaginatedResponse<T>
    {
        public PaginatedResponse(bool succeeded, List<T> data = default, List<string> messages = null, int count = 0, int page = 1, int pageSize = 10)
        {
            Data = data;
            CurrentPage = page;
            Succeeded = succeeded;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
        }
        public List<T> Data { get; set; } = [];
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public object Meta { get; set; }
        public bool Succeeded { get; set; }
        public List<string> Messages { get; set; } = [];
        public static PaginatedResponse<T> Success(List<T> data, int count, int currentpage, int pagesize)
        {
            return new PaginatedResponse<T>(true, data, null, count, currentpage, pagesize);
        }
    }
}
