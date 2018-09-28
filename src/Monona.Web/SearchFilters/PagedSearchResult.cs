using Monona.Core.Pagination;

namespace Monona.Web.SearchFilters
{
    public class PagedSearchResult<T,TFilter>
    {
        public PagedList<T> Results { get; set; }
        public TFilter Filter { get; set; }
    }
}
