using System.Collections.Generic;
using System.Linq;

namespace Monona.Core.Pagination
{
    /// <summary>
    /// Creates a paged list of results from a sorted data source
    /// </summary>
    /// <typeparam name="T">Type of items in the list</typeparam>
    public class PagedList<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sortedSource">Enumerable collection of source data (must be sorted in order to provide consistent results)</param>
        /// <param name="page">Desired page of data</param>
        /// <param name="pageSize">Size of pages</param>
        public PagedList(IEnumerable<T> sortedSource, int page, int pageSize) : this(sortedSource.AsQueryable(), page, pageSize)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sortedSource">Queryable collection of source data (must be sorted in order to provide consistent results)</param>
        /// <param name="page">Desired page of data</param>
        /// <param name="pageSize">Size of pages</param>
        public PagedList(IQueryable<T> sortedSource, int page, int pageSize)
        {
            int totalItemCount = sortedSource.Count();
            MetaData = new PagedListMetaData(totalItemCount, page, pageSize);
            if (MetaData.PageSize == int.MaxValue)
                Items = sortedSource.ToList();
            else if (MetaData.Page > 1)
                Items = sortedSource.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            else
                Items = sortedSource.Take(pageSize).ToList();
        }

        /// <summary>
        /// Items contained in current page of the list
        /// </summary>
        public List<T> Items { get; protected set; }

        /// <summary>
        /// Paged list meta data (e.g. page, page size, # items, # pages, etc)
        /// </summary>
        public PagedListMetaData MetaData { get; protected set; }
    }
}