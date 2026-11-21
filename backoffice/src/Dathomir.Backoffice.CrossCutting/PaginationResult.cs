namespace Dathomir.Backoffice.CrossCutting
{
    public class PaginationResult<TEntity>(IEnumerable<TEntity> items, int totalItems, int pageSize, int totalPages, int currentPage) where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; private set; } = items;
        public int TotalItems { get; private set; } = totalItems;
        public int PageSize { get; private set; } = pageSize;
        public int TotalPages { get; private set; } = totalPages;
        public int CurrentPage { get; private set; } = currentPage;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int NextPage => HasNextPage ? CurrentPage + 1 : TotalPages;
        public int PreviousPage => HasPreviousPage ? CurrentPage - 1 : 1;
        public int LastPage => TotalPages;

        public static PaginationResult<TEntity> ToPagedResult(IQueryable<TEntity> queryItems, int pageSize, int pageNumber)
        {
            var totalItems = queryItems.Count();
            var items = totalItems == 0
                ? []
                : queryItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return new PaginationResult<TEntity>(items, totalItems, pageSize, totalPages, pageNumber);
        }
    }
}
