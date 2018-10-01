using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Countries
{
    public class CountryForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [Required, StringLength(2), RegularExpression(@"^[A-Z]{2}$", ErrorMessage = "{0} must be two upper-case letters")]
        public string Abbreviation { get; set; }

        public bool Enabled { get; set; } = true;
    }

    internal class CountryFormMappingProfile : Profile
    {
        public CountryFormMappingProfile()
        {
            CreateMap<Country, CountryForm>().ReverseMap();
        }
    }
}
