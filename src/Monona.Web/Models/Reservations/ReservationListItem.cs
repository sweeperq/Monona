using AutoMapper;
using Monona.Core.Entities;
using System;

namespace Monona.Web.Models.Reservations
{
    public class ReservationListItem
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public string StoreName { get; set; }

        public string StoreUrl { get; set; }

        public int OrderId { get; set; }

        public int ShipmentId { get; set; }

        public string OrderNumber { get; set; }       

        public int ProductId { get; set; }

        public string Sku { get; set; }

        public int Quantity { get; set; }

        public DateTimeOffset ReservedOn { get; set; }

        public string GetOrderUrl()
        {
            if (StoreUrl.IsEmpty() || OrderId == 0)
                return string.Empty;
            return $"{StoreUrl}/Admin/Orders/ViewOrder.aspx?OrderId={OrderId}";
        }
    }

    internal class ReservationListItemProfile : Profile
    {
        public ReservationListItemProfile()
        {
            CreateMap<Reservation, ReservationListItem>()
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.Store.Name))
                .ForMember(dest => dest.StoreUrl, opt => opt.MapFrom(src => src.Store.Url))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku));
        }
    }
}
