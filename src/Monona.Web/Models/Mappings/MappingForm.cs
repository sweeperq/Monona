using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Mappings
{
    public class MappingForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, Display(Name = "Store")]
        public int StoreId { get; set; }

        [ReadOnly(true)]
        public ICollection<SelectListItem> Stores { get; set; }

        [Required, StringLength(64), Display(Name = "Store Sku")]
        public string StoreSku { get; set; }

        public int ProductId { get; set; }

        [Required, StringLength(64)]
        public string Sku { get; set; }        

        [Range(1, int.MaxValue), Display(Name = "Quantity Multiplier")]
        public int QuantityMultiplier { get; set; }
    }

    internal class MappingFormMappingProfile : Profile
    {
        public MappingFormMappingProfile()
        {
            CreateMap<Mapping, MappingForm>()
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku));
            CreateMap<MappingForm, Mapping>()
                .ForSourceMember(src => src.Sku, opt => opt.Ignore());
        }
    }
}
