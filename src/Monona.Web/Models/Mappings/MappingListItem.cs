using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.Mappings
{
    public class MappingListItem
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public int ProductId { get; set; }

        public string StoreSku { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public int QuantityMultiplier { get; set; }

        public string WarehouseLocation { get; set; }
    }

    internal class MappingListItemProfile : Profile
    {
        public MappingListItemProfile()
        {
            CreateMap<Mapping, MappingListItem>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.WarehouseLocation, opt => opt.MapFrom(src => src.Product.WarehouseLocation));
        }
    }
}
