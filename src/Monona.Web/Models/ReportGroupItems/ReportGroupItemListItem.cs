using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.ReportGroupItems
{
    public class ReportGroupItemListItem
    {
        public int Id { get; set; }

        public int ReportGroupId { get; set; }

        public string ReportGroupName { get; set; }

        public int ProductId { get; set; }

        public string Sku { get; set; }

        public string Name { get; set; }

        public string WarehouseLocation { get; set; }
    }

    internal class ReportGroupListItemMappingProfile : Profile
    {
        public ReportGroupListItemMappingProfile()
        {
            CreateMap<ReportGroupItem, ReportGroupItemListItem>()
                .ForMember(dest => dest.ReportGroupName, opt => opt.MapFrom(src => src.ReportGroup.Name))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.WarehouseLocation, opt => opt.MapFrom(src => src.Product.WarehouseLocation));
        }
    }
}
