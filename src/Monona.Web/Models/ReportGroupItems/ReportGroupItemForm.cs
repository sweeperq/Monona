using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.ReportGroupItems
{
    public class ReportGroupItemForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, Display(Name = "Report Group")]
        public int ReportGroupId { get; set; }

        public IEnumerable<SelectListItem> ReportGroups { get; set; }

        public int ProductId { get; set; }

        [Required, StringLength(64)]
        public string Sku { get; set; }
    }

    internal class ReportGroupItemFormMappingProfile : Profile
    {
        public ReportGroupItemFormMappingProfile()
        {
            CreateMap<ReportGroupItem, ReportGroupItemForm>()
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Product.Sku));
            CreateMap<ReportGroupItemForm, ReportGroupItem>()
                .ForSourceMember(src => src.ReportGroups, opt => opt.Ignore())
                .ForSourceMember(src => src.Sku, opt => opt.Ignore());

        }
    }
}
