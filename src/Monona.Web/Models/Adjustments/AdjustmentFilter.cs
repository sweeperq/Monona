using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Adjustments
{
    public class AdjustmentFilter : BaseSearchFilter<Adjustment>
    {
        public AdjustmentFilter()
        {
            SortField = "Id";
        }

        public string ProductIds { get; set; }

        public int? AdjustmentTypeId { get; set; }

        public IEnumerable<SelectListItem> AdjustmentTypes { get; set; }

        public int? StoreId { get; set; }

        public IEnumerable<SelectListItem> Stores { get; set; }

        [StringLength(64)]
        public string Sku { get; set; }

        [StringLength(256)]
        public string ReferenceNumber { get; set; }

        public override Specification<Adjustment> GetSpecification()
        {
            var spec = new Specification<Adjustment>();
            if (!Ids.IsEmpty())
            {
                int[] ids = ArrayHelpers.StringToIntArray(Ids);
                if (ids != null && ids.Length > 0)
                {
                    spec.And(c => ids.Contains(c.Id));
                }
            }

            if (!ProductIds.IsEmpty())
            {
                int[] ids = ArrayHelpers.StringToIntArray(ProductIds);
                if (ids != null && ids.Length > 0)
                {
                    spec.And(c => ids.Contains(c.ProductId));
                }
            }

            if (AdjustmentTypeId.HasValue)
                spec.And(a => a.AdjustmentTypeId == AdjustmentTypeId.Value);
            if (StoreId.HasValue)
                spec.And(a => a.StoreId == StoreId.Value);
            if (!Sku.IsEmpty())
                spec.And(r => r.Product.Sku.StartsWith(Sku));
            if (!ReferenceNumber.IsEmpty())
                spec.And(r => r.ReferenceNumber.StartsWith(ReferenceNumber));
            return spec;
        }

        public override SortSpecification<Adjustment>[] GetSortSpecifications()
        {
            List<SortSpecification<Adjustment>> specs = new List<SortSpecification<Adjustment>>();
            specs.Add(new SortSpecification<Adjustment>(a => a.Id, SortDirection.Descending));
            return specs.ToArray();
        }
    }
}
