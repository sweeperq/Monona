using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.GoogleCategories
{
    public class GoogleCategoryFilter : BaseSearchFilter<GoogleCategory>
    {
        public GoogleCategoryFilter()
        {
            SortField = "Name";
        }

        [StringLength(256)]
        public string Name { get; set; }

        [Display(Name = "Show all?")]
        public bool ShowAll { get; set; } = true;

        public override Specification<GoogleCategory> GetSpecification()
        {
            var spec = new Specification<GoogleCategory>();
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
            if (!ShowAll)
                spec.And(c => c.Enabled == true);
            return spec;
        }

        public override SortSpecification<GoogleCategory>[] GetSortSpecifications()
        {
            List<SortSpecification<GoogleCategory>> specs = new List<SortSpecification<GoogleCategory>>();
            specs.Add(new SortSpecification<GoogleCategory>(SortField, SortDirection));
            if (SortField == "Enabled")
                specs.Add(new SortSpecification<GoogleCategory>("Name", SortDirection.Ascending));
            return specs.ToArray();
        }
    }
}
