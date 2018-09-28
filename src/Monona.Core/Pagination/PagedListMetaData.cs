using System;

namespace Monona.Core.Pagination
{
    /// <summary>
    /// This class contains meta data about a paged list. It calculates the metadata based
    /// on the total item count, current page number, and page size
    /// </summary>
    public class PagedListMetaData
    {
        protected static readonly string NEGATIVE_ERROR = "Value must be zero or greater. Value provided = {0}";
        protected static readonly string ZERO_OR_NEGATIVE_ERROR = "Value must be greater than 0. Value provided = {0}";

        /// <summary>
        /// Constructor. Populates the paged list meta data property values
        /// </summary>
        /// <param name="totalItemCount">Total item count</param>
        /// <param name="page">Current page</param>
        /// <param name="pageSize">Page size</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if totalItemCount is negative,
        /// page is less than one, or pageSize is less than one.</exception>"
        public PagedListMetaData(int totalItemCount, int page, int pageSize)
        {
            // Total item count can never be less than zero
            if (totalItemCount < 0)
                throw new ArgumentOutOfRangeException(nameof(page), string.Format(NEGATIVE_ERROR, page));

            // Page can never be less than one
            if (page < 1)
                throw new ArgumentOutOfRangeException(nameof(page), string.Format(ZERO_OR_NEGATIVE_ERROR, page));

            // Page size can never be less than one
            if (pageSize < 1)
            {
                if (pageSize == 0)
                {
                    pageSize = int.MaxValue;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(pageSize), string.Format(ZERO_OR_NEGATIVE_ERROR, pageSize));
                }                
            }

            Page = page;
            PageSize = pageSize;
            TotalItemCount = totalItemCount;


            // Only need to calculate the remaining values if the total item count is greater than one
            if (TotalItemCount > 0)
            {
                PageCount = (int)Math.Ceiling(TotalItemCount / (double)PageSize);

                // If the page is greater than the page count, it compromises these calculations
                if (Page <= PageCount)
                {
                    FirstItemOnPage = (Page - 1) * PageSize + 1;
                    LastItemOnPage = FirstItemOnPage + PageSize - 1;
                    LastItemOnPage = LastItemOnPage > TotalItemCount ? TotalItemCount : LastItemOnPage;
                    PageItemCount = LastItemOnPage - (FirstItemOnPage - 1);
                }

                IsFirstPage = (Page == 1);
                IsLastPage = (Page == PageCount);
                HasPreviousPage = Page > 1;
                HasNextPage = Page < PageCount;
            }
        }

        /// <summary>
        /// Current page number
        /// </summary>
        public int Page { get; protected set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; protected set; }

        /// <summary>
        /// Total page count
        /// </summary>
        public int PageCount { get; protected set; }

        /// <summary>
        /// Count of items on this page
        /// </summary>
        public int PageItemCount { get; protected set; }

        /// <summary>
        /// Total item count
        /// </summary>
        public int TotalItemCount { get; protected set; }

        /// <summary>
        /// Index of the first item on this page
        /// </summary>
        public int FirstItemOnPage { get; protected set; }

        /// <summary>
        /// Index of the last item on this page
        /// </summary>
        public int LastItemOnPage { get; protected set; }

        /// <summary>
        /// Is this the first page in the source?
        /// </summary>
        public bool IsFirstPage { get; protected set; }

        /// <summary>
        /// Is this the last page in the source?
        /// </summary>
        public bool IsLastPage { get; protected set; }

        /// <summary>
        /// Does this page have a previous page?
        /// </summary>
        public bool HasPreviousPage { get; protected set; }

        /// <summary>
        /// Does this page have a next page?
        /// </summary>
        public bool HasNextPage { get; protected set; }
    }
}