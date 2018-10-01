using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Vendors
{
    public class VendorFilter : BaseSearchFilter<Vendor>
    {
        public VendorFilter()
        {
            SortField = "Name";
        }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(16)]
        public string Abbreviation { get; set; }

        [Display(Name = "Show all?")]
        public bool ShowAll { get; set; } = true;

        public override Specification<Vendor> GetSpecification()
        {
            var spec = new Specification<Vendor>();
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

        public override SortSpecification<Vendor>[] GetSortSpecifications()
        {
            List<SortSpecification<Vendor>> specs = new List<SortSpecification<Vendor>>();
            specs.Add(new SortSpecification<Vendor>(SortField, SortDirection));
            if (SortField == "Enabled")
                specs.Add(new SortSpecification<Vendor>("Name", SortDirection.Ascending));
            return specs.ToArray();
        }
    }
}
