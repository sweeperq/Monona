using AutoMapper;
using Monona.Core.Entities;

namespace Monona.Web.Models.GoogleCategories
{
    public class GoogleCategoryListItem : GoogleCategoryForm
    {
    }

    internal class GoogleCategoryListItemMappingProfile : Profile
    {
        public GoogleCategoryListItemMappingProfile()
        {
            CreateMap<GoogleCategory, GoogleCategoryListItem>();
        }
    }
}
