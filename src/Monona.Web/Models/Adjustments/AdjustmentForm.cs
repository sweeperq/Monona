using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Adjustments
{
    public class AdjustmentForm
    {
        [Required, Display(Name = "Adjustment Type")]
        public int AdjustmentTypeId { get; set; }

        public IEnumerable<SelectListItem> AdjustmentTypes { get; set; }

        [Required, Display(Name = "Store")]
        public int StoreId { get; set; }

        public IEnumerable<SelectListItem> Stores { get; set; }

        public int ProductId { get; set; }

        [Required, StringLength(256)]
        public string Sku { get; set; }

        [Required, StringLength(256), Display(Name = "Reference #")]
        public string ReferenceNumber { get; set; }

        [Required, RegularExpression(@"^(?!-?0)-?\d+$", ErrorMessage = "{0} cannot be 0")]
        public int Quantity { get; set; }
    }

    internal class AdjustmentFormMappingProfile : Profile
    {
        public AdjustmentFormMappingProfile()
        {
            CreateMap<AdjustmentForm, Adjustment>()
                .ForSourceMember(src => src.AdjustmentTypes, opt => opt.Ignore())
                .ForSourceMember(src => src.Stores, opt => opt.Ignore());
        }
    }
}
