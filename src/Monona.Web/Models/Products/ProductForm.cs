using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Products
{
    public class ProductForm
    {
        [Key, ReadOnly(true)]
        public int Id { get; protected set; }

        [Display(Name = "Store")]
        public int StoreId { get; set; }

        public ICollection<SelectListItem> Stores { get; set; }

        [Display(Name = "Vendor")]
        public int VendorId { get; set; }

        public ICollection<SelectListItem> Vendors { get; set; }

        [StringLength(64), Display(Name = "Vendor Part #")]
        public string VendorPartNumber { get; set; }

        [Required, StringLength(64)]
        public string Sku { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [Range(1, int.MaxValue), Display(Name = "Case Pack")]
        public int CasePack { get; set; }

        [Display(Name = "Re-order Point")]
        public int ReorderPoint { get; set; }

        [StringLength(256), Display(Name = "Warehouse Location")]
        public string WarehouseLocation { get; set; }

        [StringLength(256), Display(Name = "Bulk Warehouse Location")]
        public string BulkWarehouseLocation { get; set; }

        [Range(0, int.MaxValue), Display(Name = "Lead Days")]
        public int? LeadDays { get; set; }

        [Range(0, 99999999999999.9999)]
        public decimal? Cost { get; set; }

        [Range(0, 99999999999999.9999)]
        public decimal? Weight { get; set; }

        [Range(0, 99999999999999.9999), Display(Name = "Max Length")]
        public decimal? MaxLength { get; set; }

        [StringLength(256), Display(Name = "Box Size")]
        public string BoxSize { get; set; }

        public bool Dropshipped { get; set; }

        public bool Seasonal { get; set; }

        [Display(Name = "Disallow Backorder")]
        public bool DisallowBackorder { get; set; }

        public bool Discontinued { get; set; }

        [Display(Name = "Not in Stores Exclude")]
        public bool NotInStoresExclude { get; set; }

        [Display(Name = "Country of Origing")]
        public int? CountryOfOriginId { get; set; }

        public ICollection<SelectListItem> Countries { get; set; }

        [Display(Name = "Google Category")]
        public int? GoogleCategoryId { get; set; }

        public ICollection<SelectListItem> GoogleCategories { get; set; }

        [StringLength(64), Display(Name = "GTIN")]
        public string Gtin { get; set; }

        [StringLength(256)]
        public string Brand { get; set; }

        [StringLength(64), Display(Name = "MPN")]
        public string Mpn { get; set; }

        public string Notes { get; set; }
    }

    public class ProductFormMappingProfile : Profile
    {
        public ProductFormMappingProfile()
        {
            CreateMap<Product, ProductForm>();
            CreateMap<ProductForm, Product>()
                .ForSourceMember(src => src.Stores, opt => opt.Ignore())
                .ForSourceMember(src => src.Vendors, opt => opt.Ignore())
                .ForSourceMember(src => src.Countries, opt => opt.Ignore())
                .ForSourceMember(src => src.GoogleCategories, opt => opt.Ignore())
                .ForMember(dest => dest.Store, opt => opt.Ignore())
                .ForMember(dest => dest.Vendor, opt => opt.Ignore())
                .ForMember(dest => dest.CountryOfOrigin, opt => opt.Ignore())
                .ForMember(dest => dest.GoogleCategory, opt => opt.Ignore())
                .ForMember(dest => dest.LastPrintedOn, opt => opt.Ignore());

        }
    }
}
