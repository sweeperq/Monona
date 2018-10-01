using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.Stores
{
    public class StoreForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [StringLength(16)]
        public string Abbreviation { get; set; }

        [StringLength(256), Url]
        public string Url { get; set; }

        public bool Enabled { get; set; } = true;
    }

    internal class StoreFormMappingProfile : Profile
    {
        public StoreFormMappingProfile()
        {
            CreateMap<Store, StoreForm>().ReverseMap();
        }
    }
}
