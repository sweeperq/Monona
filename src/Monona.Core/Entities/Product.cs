using System;
using System.ComponentModel.DataAnnotations;

namespace Monona.Core.Entities
{
    public class Product : IEntity<int>
    {
        [Key]
        public int Id { get; protected set; }

        public int StoreId { get; set; }

        public virtual Store Store { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        [StringLength(64)]
        public string VendorPartNumber { get; set; }

        [Required, StringLength(64)]
        public string Sku { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [Range(1, int.MaxValue)]
        public int CasePack { get; set; }

        public int ReorderPoint { get; set; }

        [StringLength(256)]
        public string WarehouseLocation { get; set; }

        [StringLength(256)]
        public string BulkWarehouseLocation { get; set; }

        [Range(0, int.MaxValue)]
        public int? LeadDays { get; set; }

        [Range(0, 99999999999999.9999)]
        public decimal? Cost { get; set; }

        [Range(0, 99999999999999.9999)]
        public decimal? Weight { get; set; }

        [Range(0, 99999999999999.9999)]
        public decimal? MaxLength { get; set; }

        [StringLength(256)]
        public string BoxSize { get; set; }

        public bool Dropshipped { get; set; }

        public bool Seasonal { get; set; }

        public bool DisallowBackorder { get; set; }

        public bool Discontinued { get; set; }

        public bool NotInStoresExclude { get; set; }

        public int? CountryOfOriginId { get; set; }

        public virtual Country CountryOfOrigin { get; set; }

        public int? GoogleCategoryId { get; set; }

        public virtual GoogleCategory GoogleCategory { get; set; }

        [StringLength(64)]
        public string Gtin { get; set; }

        [StringLength(256)]
        public string Brand { get; set; }

        [StringLength(64)]
        public string Mpn { get; set; }

        public string Notes { get; set; }

        public DateTimeOffset? LastPrintedOn { get; set; }

        public virtual ProductInventory Inventory { get; protected set; } = new ProductInventory();
    }
}
