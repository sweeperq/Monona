using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Countries
{
    public class CountryFilter : BaseSearchFilter<Country>
    {
        public CountryFilter()
        {
            SortField = "Name";
        }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(2)]
        public string Abbreviation { get; set; }

        [Display(Name = "Show all?")]
        public bool ShowAll { get; set; } = true;

        public override Specification<Country> GetSpecification()
        {
            var spec = new Specification<Country>();
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

        public override SortSpecification<Country>[] GetSortSpecifications()
        {
            List<SortSpecification<Country>> specs = new List<SortSpecification<Country>>();
            specs.Add(new SortSpecification<Country>(SortField, SortDirection));
            if (SortField == "Enabled")
                specs.Add(new SortSpecification<Country>("Name", SortDirection.Ascending));
            return specs.ToArray();
        }
    }
}
