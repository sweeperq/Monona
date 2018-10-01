using AutoMapper;
using Monona.Core.Entities;
using System;

namespace Monona.Web.Models.Products
{
    public class ProductListItem
    {
        public int Id { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public string Notes { get; set; }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public int StockQuantity { get; set; }

        public int AvailableQuantity { get; set; }

        public int OnOrderQuantity { get; set; }

        public DateTimeOffset? NextPoOn { get; set; }

        public string WarehouseLocation { get; set; }

        public bool Discontinued { get; set; }        
    }

    public class ProductListItemMappingProfile : Profile
    {
        public ProductListItemMappingProfile()
        {
            CreateMap<Product, ProductListItem>()
                .ForMember(dest => dest.VendorName, opt => opt.MapFrom(src => src.Vendor.Name))
                .ForMember(dest => dest.StockQuantity, opt => opt.MapFrom(src => src.Inventory.StockQuantity))
                .ForMember(dest => dest.AvailableQuantity, opt => opt.MapFrom(src => src.Inventory.AvailableQuantity))
                .ForMember(dest => dest.OnOrderQuantity, opt => opt.MapFrom(src => src.Inventory.OnOrderQuantity))
                .ForMember(dest => dest.NextPoOn, opt => opt.MapFrom(src => src.Inventory.NextPoOn));
        }
    }
}
