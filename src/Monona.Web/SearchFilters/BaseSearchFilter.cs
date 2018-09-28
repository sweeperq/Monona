using Monona.Core.Entities;
using Monona.Core.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.SearchFilters
{
    public abstract class BaseSearchFilter<T>
        where T : class
    {
        public string Ids { get; set; }

        public int Page { get; set; } = 1;

        [Display(Name = "Page Size")]
        public int PageSize { get; set; } = 20;

        [Display(Name = "Sort Field")]
        public string SortField { get; set; } = "Id";

        [Display(Name = "Sort Direction")]
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;

        public abstract Specification<T> GetSpecification();

        public abstract SortSpecification<T>[] GetSortSpecifications();
    }
}
