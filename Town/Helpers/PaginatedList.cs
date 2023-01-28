namespace Town.Helpers
{
    public class PaginatedList<T>:List<T>
    {


        public PaginatedList(List<T> values,int count, int pageSize, int page)
        {
            ActivePage= page;
            TotalPageCount = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(values);

        }

        public int TotalPageCount { get; set; }
        public int ActivePage { get; set; }
        public bool HasNext { get => ActivePage < TotalPageCount; } 
        public bool HasPrevious { get => ActivePage > 1; }


    public static PaginatedList<T> Create(IQueryable<T> query, int pageSize, int page)
         {
             return new PaginatedList<T>(query.Skip((page - 1) * pageSize).Take(pageSize).ToList(), query.Count(), pageSize, page);
         }

    }
}
