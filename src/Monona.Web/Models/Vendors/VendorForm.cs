using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Vendors
{
    public class VendorForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Display(Name = "P.O. Email Addresses")]
        public string PoEmailAddresses { get; set; }

        [Display(Name = "Payment Terms")]
        public string PaymentTerms { get; set; }

        [StringLength(64), Display(Name = "Strip from Sku for Client")]
        public string StripFromSkuForClient { get; set; }

        [Display(Name = "Default Lead Days")]
        public int? DefaultLeadDays { get; set; }

        [Display(Name = "Default Country of Origin")]
        public int? DefaultCountryOfOriginId { get; set; }

        public ICollection<SelectListItem> Countries { get; set; }

        [Display(Name = "Default Google Category")]
        public int? DefaultGoogleCategoryId { get; set; }

        public ICollection<SelectListItem> GoogleCategories { get; set; }

        [StringLength(256), Display(Name = "Default Brand")]
        public string DefaultBrand { get; set; }

        public string Notes { get; set; }

        public bool Enabled { get; set; } = true;
    }

    internal class VendorFormMappingProfile : Profile
    {
        public VendorFormMappingProfile()
        {
            CreateMap<Vendor, VendorForm>();
            CreateMap<VendorForm, Vendor>()
                .ForSourceMember(src => src.Countries, opt => opt.Ignore())
                .ForSourceMember(src => src.GoogleCategories, opt => opt.Ignore())
                .ForMember(dest => dest.DefaultCountryOfOrigin, opt => opt.Ignore())
                .ForMember(dest => dest.DefaultGoogleCategory, opt => opt.Ignore());                
        }
    }
}
