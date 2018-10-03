using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Reservations
{
    public class ReservationFilter : BaseSearchFilter<Reservation>
    {
        public ReservationFilter()
        {
            SortField = "Id";
        }

        public string ProductIds { get; set; }

        [StringLength(64)]
        public string OrderNumber { get; set; }

        [StringLength(64)]
        public string Sku { get; set; }

        public bool ShowAll { get; set; }

        public override Specification<Reservation> GetSpecification()
        {
            var spec = new Specification<Reservation>();
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

            if (!OrderNumber.IsEmpty())
                spec.And(r => r.OrderNumber == OrderNumber);
            if (!Sku.IsEmpty())
                spec.And(r => r.Product.Sku.StartsWith(Sku));
            if (!ShowAll)
                spec.And(r => r.Quantity > 0);
            return spec;
        }

        public override SortSpecification<Reservation>[] GetSortSpecifications()
        {
            List<SortSpecification<Reservation>> specs = new List<SortSpecification<Reservation>>();
            if (SortField == "Product.Sku")
            {
                specs.Add(new SortSpecification<Reservation>(r => r.Product.Sku, SortDirection));
                specs.Add(new SortSpecification<Reservation>(r => r.ReservedOn, SortDirection.Ascending));
            }
            else if (SortField == "OrderNumber")
            {
                specs.Add(new SortSpecification<Reservation>(r => r.OrderNumber, SortDirection));
                specs.Add(new SortSpecification<Reservation>(r => r.ReservedOn, SortDirection.Ascending));
            }
            else
            {
                specs.Add(new SortSpecification<Reservation>(SortField, SortDirection));
            }
            return specs.ToArray();
        }
    }
}
