using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Monona.Web.Models.AdjustmentTypes
{
    public class AdjustmentTypeForm
    {
        [Key, HiddenInput, ReadOnly(true)]
        public int Id { get; set; }

        [Required, StringLength(256)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public bool Enabled { get; set; } = true;
    }

    internal class AdjustmentTypeFormMappingProfile : Profile
    {
        public AdjustmentTypeFormMappingProfile()
        {
            CreateMap<AdjustmentType, AdjustmentTypeForm>();
        }
    }
}
