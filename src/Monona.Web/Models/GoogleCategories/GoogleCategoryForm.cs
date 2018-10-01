using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.GoogleCategories
{
    public class GoogleCategoryForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        public bool Enabled { get; set; } = true;
    }

    internal class GoogleCategoryFormMappingProfile : Profile
    {
        public GoogleCategoryFormMappingProfile()
        {
            CreateMap<GoogleCategory, GoogleCategoryForm>().ReverseMap();
        }
    }
}
