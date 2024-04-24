namespace Talabat.APIs.Helpers
{
    public class Pagination<T>
    {
       
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int PageIndex { get; set; }

        public IEnumerable<T> Date { get; set; }
        //public Pagination(int pageSize, int count, int pageIndex, IReadOnlyList<T> date)
        //{
        //    PageSize = pageSize;
        //    Count = count;
        //    PageIndex = pageIndex;
        //    Date = date;
        //}


    }
}
