using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.ReportGroups
{
    public class ReportGroupListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    internal class ReportGroupListItemMappingProfile : Profile
    {
        public ReportGroupListItemMappingProfile()
        {
            CreateMap<ReportGroup, ReportGroupListItem>();
        }
    }
}
