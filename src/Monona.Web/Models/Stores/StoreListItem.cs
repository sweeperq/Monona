using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.Stores
{
    public class StoreListItem : StoreForm
    {
    }

    internal class StoreListItemMappingProfile : Profile
    {
        public StoreListItemMappingProfile()
        {
            CreateMap<Store, StoreListItem>();
        }
    }
}
