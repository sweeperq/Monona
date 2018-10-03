using AutoMapper;
using Monona.Core.Entities;
using System;

namespace Monona.Web.Models.Adjustments
{
    public class AdjustmentListItem
    {
        public int Id { get; set; }

        public int AdjustmentTypeId { get; set; }

        public string AdjustmentTypeName { get; set; }

        public int? StoreId { get; set; }

        public string StoreName { get; set; }

        public string ReferenceNumber { get; set; }       

        public int ProductId { get; set; }

        public string Sku { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset AdjustmentDate { get; set; }
    }

    internal class AdjustmentListItemProfile : Profile
    {
        public AdjustmentListItemProfile()
        {
            CreateMap<Adjustment, AdjustmentListItem>()
                .ForMember(dest => dest.AdjustmentTypeName, opt => opt.MapFrom(src => src.AdjustmentType.Name))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));
        }
    }
}
