using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Mappings
{
    public class MappingFilter : BaseSearchFilter<Mapping>
    {
        public MappingFilter()
        {
            SortField = "StoreSku";
        }

        public string ProductIds { get; set; }

        public int? StoreId { get; set; }

        public ICollection<SelectListItem> Stores { get; set; }

        [StringLength(64)]
        public string Sku { get; set; }

        [StringLength(64)]
        public string StoreSku { get; set; }

        public override Specification<Mapping> GetSpecification()
        {
            var spec = new Specification<Mapping>();
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
            if (StoreId.HasValue)
                spec.And(m => m.StoreId.Equals(StoreId.Value));
            if (!Sku.IsEmpty())
                spec.And(m => m.Product.Sku.StartsWith(Sku));
            if (!StoreSku.IsEmpty())
                spec.And(m => m.StoreSku.StartsWith(StoreSku));
            return spec;
        }

        public override SortSpecification<Mapping>[] GetSortSpecifications()
        {
            List<SortSpecification<Mapping>> specs = new List<SortSpecification<Mapping>>();
            if (SortField == "Product.Sku")
            {
                specs.Add(new SortSpecification<Mapping>(m => m.Product.Sku, SortDirection));
                specs.Add(new SortSpecification<Mapping>(m => m.StoreSku, SortDirection.Ascending));
            }
            else if (SortField == "Store.Name")
            {
                specs.Add(new SortSpecification<Mapping>(m => m.Store.Name, SortDirection));
                specs.Add(new SortSpecification<Mapping>(m => m.StoreSku, SortDirection.Ascending));
            }
            else if (SortField == "Product.WarehouseLocation")
            {
                specs.Add(new SortSpecification<Mapping>(m => m.Product.WarehouseLocation, SortDirection));
            }
            else if (SortField == "Product.Name")
            {
                specs.Add(new SortSpecification<Mapping>(m => m.Product.Name, SortDirection));
            }
            else
            {
                specs.Add(new SortSpecification<Mapping>(SortField, SortDirection));
            }
            return specs.ToArray();
        }
    }
}
