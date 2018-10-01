using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.AdjustmentTypes
{
    public class AdjustmentTypeListItem : AdjustmentTypeForm
    {
    }

    internal class AdjustmentTypeListItemMappingProfile : Profile
    {
        public AdjustmentTypeListItemMappingProfile()
        {
            CreateMap<AdjustmentType, AdjustmentTypeListItem>().ReverseMap();
        }
    }
}
