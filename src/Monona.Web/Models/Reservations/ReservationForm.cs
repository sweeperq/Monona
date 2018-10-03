using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Reservations
{
    public abstract class ReservationForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, Display(Name = "Store")]
        public int StoreId { get; set; }

        [Range(0, int.MaxValue)]
        public int OrderId { get; set; }

        [Range(0, int.MaxValue)]
        public int ShipmentId { get; set; }

        [Range(0, int.MaxValue)]
        public int OrderItemId { get; set; }

        [Required, StringLength(64)]
        public string OrderNumber { get; set; }

        public int ProductId { get; set; }

        [Required, StringLength(64)]
        public string Sku { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        public DateTimeOffset ReservedOn { get; set; } = DateTimeOffset.Now;
    }

    public class ReservationCreateForm : ReservationForm
    {
        public ICollection<SelectListItem> Stores { get; set; }
    }

    public class ReservationEditForm : ReservationForm
    {
        public virtual Store Store { get; set; }
    }

    internal class ReservationFormMappingProfile : Profile
    {
        public ReservationFormMappingProfile()
        {
            CreateMap<Reservation, ReservationEditForm>()
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku));
            CreateMap<ReservationEditForm, Reservation>()
                .ForSourceMember(src => src.Sku, opt => opt.Ignore());

            CreateMap<ReservationCreateForm, Reservation>()
                .ForSourceMember(src => src.Sku, opt => opt.Ignore());

        }
    }
}
