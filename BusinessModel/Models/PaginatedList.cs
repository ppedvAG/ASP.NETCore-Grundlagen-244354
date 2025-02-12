namespace BusinessModel.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; init; }

        public int TotalPages { get; private set; }

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;

        private PaginatedList(IEnumerable<T> items)
            : base(items)
        {
        }

        public PaginatedList(IEnumerable<T> items, int count, int pageSize) 
            : base(items)
        {
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public PaginatedList<TResult> Select<TResult>(Func<T, TResult> selector)
        {
            return new PaginatedList<TResult>(this.AsEnumerable().Select(selector))
            {
                PageIndex = PageIndex,
                TotalPages = TotalPages
            };
        }
    }
}
