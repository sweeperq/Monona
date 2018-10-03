using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.ReportGroups
{
    public class ReportGroupForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        public string Description { get; set; }
    }

    internal class ReportGroupFormMappingProfile : Profile
    {
        public ReportGroupFormMappingProfile()
        {
            CreateMap<ReportGroup, ReportGroupForm>().ReverseMap();
        }
    }
}
