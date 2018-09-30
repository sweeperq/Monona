using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Core.Specifications;
using Monona.Services;
using Monona.Web.Models.GoogleCategories;
using Monona.Web.SearchFilters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class GoogleCategoriesController : 
        GenericCrudController<GoogleCategory, int, GenericService<GoogleCategory,int>, GoogleCategoryFilter, GoogleCategoryListItem, GoogleCategoryForm, GoogleCategoryForm>
    {
        public GoogleCategoriesController(GenericService<GoogleCategory,int> service) : base(service)
        {
        }
    }
}
