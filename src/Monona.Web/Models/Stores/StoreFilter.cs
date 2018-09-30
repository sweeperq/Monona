using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Stores
{
    public class StoreFilter : BaseSearchFilter<Store>
    {
        public StoreFilter()
        {
            SortField = "Name";
        }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(16)]
        public string Abbreviation { get; set; }

        [Display(Name = "Show all?")]
        public bool ShowAll { get; set; } = true;

        public override Specification<Store> GetSpecification()
        {
            var spec = new Specification<Store>();
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
            if (!Abbreviation.IsEmpty())
                spec.And(c => c.Abbreviation.StartsWith(Abbreviation));
            if (!ShowAll)
                spec.And(c => c.Enabled == true);
            return spec;
        }

        public override SortSpecification<Store>[] GetSortSpecifications()
        {
            List<SortSpecification<Store>> specs = new List<SortSpecification<Store>>();
            specs.Add(new SortSpecification<Store>(SortField, SortDirection));
            if (SortField == "Enabled")
                specs.Add(new SortSpecification<Store>("Name", SortDirection.Ascending));
            return specs.ToArray();
        }
    }
}
