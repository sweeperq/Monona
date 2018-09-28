using System;
using System.Collections.Generic;
using System.Linq;

namespace Monona.Core.Pagination
{
    public static class PagedListExtensions
    {
        /// <summary>
        /// Convert an enumerable collection to a paged list
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <param name="sortedSource">Enumerable sorted source data</param>
        /// <param name="page">Desired page number</param>
        /// <param name="pageSize">Size of page</param>
        /// <returns>A single page of results from the source with paged list meta data</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if page or pageSize are less than one.</exception>"
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> sortedSource, int page, int pageSize)
        {
            return new PagedList<T>(sortedSource, page, pageSize);
        }

        /// <summary>
        /// Convert an enumerable collection to a paged list
        /// </summary>
        /// <typeparam name="T">Type of items</typeparam>
        /// <param name="sortedSource">Queryable sorted source data</param>
        /// <param name="page">Desired page number</param>
        /// <param name="pageSize">Size of page</param>
        /// <returns>A single page of results from the source with paged list meta data</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if page or pageSize are less than one.</exception>"
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> sortedSource, int page, int pageSize)
        {
            return new PagedList<T>(sortedSource, page, pageSize);
        }
    }
}