using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.ReportGroupItems
{
    public class ReportGroupItemFilter : BaseSearchFilter<ReportGroupItem>
    {
        public ReportGroupItemFilter()
        {
            SortField = "Id";
        }

        [Display(Name = "Report Group")]
        public int? ReportGroupId { get; set; }

        public IEnumerable<SelectListItem> ReportGroups { get; set; }

        [StringLength(64)]
        public string Sku { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public override Specification<ReportGroupItem> GetSpecification()
        {
            var spec = new Specification<ReportGroupItem>();
            if (!Ids.IsEmpty())
            {
                int[] ids = ArrayHelpers.StringToIntArray(Ids);
                if (ids != null && ids.Length > 0)
                {
                    spec.And(c => ids.Contains(c.Id));
                }
            }
            if (ReportGroupId.HasValue)
                spec.And(i => i.ReportGroupId == ReportGroupId.Value);
            if (!Sku.IsEmpty())
                spec.And(i => i.Product.Sku.StartsWith(Sku));
            if (!Name.IsEmpty())
                spec.And(i => i.Product.Name.Contains(Name));            
            return spec;
        }

        public override SortSpecification<ReportGroupItem>[] GetSortSpecifications()
        {
            List<SortSpecification<ReportGroupItem>> specs = new List<SortSpecification<ReportGroupItem>>();
            specs.Add(new SortSpecification<ReportGroupItem>(SortField, SortDirection));
            return specs.ToArray();
        }
    }
}
