using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.AdjustmentTypes
{
    public class AdjustmentTypeFilter : BaseSearchFilter<AdjustmentType>
    {
        public AdjustmentTypeFilter()
        {
            SortField = "Name";
        }

        [StringLength(256)]
        public string Name { get; set; }

        [Display(Name = "Show all?")]
        public bool ShowAll { get; set; } = true;

        public override Specification<AdjustmentType> GetSpecification()
        {
            var spec = new Specification<AdjustmentType>();
            if (!Ids.IsEmpty())
            {
                int[] ids = ArrayHelpers.StringToIntArray(Ids);
                if (ids != null && ids.Length > 0)
                {
                    spec.And(a => ids.Contains(a.Id));
                }
            }
            if (!Name.IsEmpty())
                spec.And(a => a.Name.StartsWith(Name));
            if (!ShowAll)
                spec.And(a => a.Enabled == true);
            return spec;
        }

        public override SortSpecification<AdjustmentType>[] GetSortSpecifications()
        {
            List<SortSpecification<AdjustmentType>> specs = new List<SortSpecification<AdjustmentType>>();
            specs.Add(new SortSpecification<AdjustmentType>(SortField, SortDirection));
            if (SortField == "Enabled")
                specs.Add(new SortSpecification<AdjustmentType>("Name", SortDirection.Ascending));
            return specs.ToArray();
        }
    }
}
