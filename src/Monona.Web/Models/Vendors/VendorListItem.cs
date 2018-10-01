using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.Vendors
{
    public class VendorListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool Enabled { get; set; }
    }

    internal class VendorListItemMappingProfile : Profile
    {
        public VendorListItemMappingProfile()
        {
            CreateMap<Vendor, VendorListItem>();
        }
    }
}
