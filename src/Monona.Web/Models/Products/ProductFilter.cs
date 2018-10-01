using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Core.Helpers;
using Monona.Core.Specifications;
using Monona.Web.SearchFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Monona.Web.Models.Products
{
    public class ProductFilter : BaseSearchFilter<Product>
    {
        public ProductFilter()
        {
            SortField = "Sku";
        }

        public int? VendorId { get; set; }

        public ICollection<SelectListItem> Vendors { get; set; }

        [StringLength(64)]
        public string Sku { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(256)]
        public string WarehouseLocation { get; set; }

        [Display(Name = "Show all?")]
        public bool ShowAll { get; set; } = true;

        public override Specification<Product> GetSpecification()
        {
            var spec = new Specification<Product>();
            if (!Ids.IsEmpty())
            {
                int[] ids = ArrayHelpers.StringToIntArray(Ids);
                if (ids != null && ids.Length > 0)
                {
                    spec.And(c => ids.Contains(c.Id));
                }
            }
            if (VendorId.HasValue)
                spec.And(c => c.VendorId == VendorId.Value);
            if (!Sku.IsEmpty())
                spec.And(c => c.Sku.StartsWith(Sku));
            if (!Name.IsEmpty())
                spec.And(c => c.Name.StartsWith(Name));
            if (!WarehouseLocation.IsEmpty())
                spec.And(c => c.WarehouseLocation.StartsWith(WarehouseLocation) || c.BulkWarehouseLocation.StartsWith(WarehouseLocation));
            if (!ShowAll)
                spec.And(c => !c.Discontinued || c.Inventory.StockQuantity > 0);
            return spec;
        }

        public override SortSpecification<Product>[] GetSortSpecifications()
        {
            List<SortSpecification<Product>> specs = new List<SortSpecification<Product>>();
            if (SortField == "Vendor.Name")
            {
                specs.Add(new SortSpecification<Product>(p => p.Vendor.Name, SortDirection));
            }
            else
            {
                specs.Add(new SortSpecification<Product>(SortField, SortDirection));
            }
            if (SortField != "Sku")
            {
                specs.Add(new SortSpecification<Product>(p => p.Sku, SortDirection.Ascending));
            }
            return specs.ToArray();
        }
    }
}
