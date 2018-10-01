using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.Countries
{
    public class CountryListItem : CountryForm
    {
    }

    internal class CountryListItemMappingProfile : Profile
    {
        public CountryListItemMappingProfile()
        {
            CreateMap<Country, CountryListItem>();
        }
    }
}
