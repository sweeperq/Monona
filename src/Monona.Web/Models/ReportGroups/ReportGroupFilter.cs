using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.ReportGroups
{
    public class ReportGroupFilter : BaseSearchFilter<ReportGroup>
    {
        public ReportGroupFilter()
        {
            SortField = "Name";
        }

        [StringLength(256)]
        public string Name { get; set; }

        public override Specification<ReportGroup> GetSpecification()
        {
            var spec = new Specification<ReportGroup>();
            if (!Ids.IsEmpty())
            {
                int[] ids = ArrayHelpers.StringToIntArray(Ids);
                if (ids != null && ids.Length > 0)
                {
                    spec.And(c => ids.Contains(c.Id));
                }
            }
            if (!Name.IsEmpty())
                spec.And(c => c.Name.StartsWith(Name));
            return spec;
        }

        public override SortSpecification<ReportGroup>[] GetSortSpecifications()
        {
            List<SortSpecification<ReportGroup>> specs = new List<SortSpecification<ReportGroup>>();
            specs.Add(new SortSpecification<ReportGroup>(SortField, SortDirection));
            return specs.ToArray();
        }
    }
}
