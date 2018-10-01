using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Services;
using Monona.Web.Models.Vendors;

namespace Monona.Web.Controllers
{
    public class VendorsController : GenericCrudController<Vendor, int, GenericService<Vendor,int>, VendorFilter, VendorListItem, VendorForm, VendorForm>
    {
        private GenericService<Country, int> _countryService;
        private GenericService<GoogleCategory, int> _categoryService;

        public VendorsController(GenericService<Vendor,int> service, GenericService<Country, int> countryService, GenericService<GoogleCategory,int> categoryService) : base(service)
        {
            _countryService = countryService;
            _categoryService = categoryService;
        }

        [NonAction]
        protected override void LoadRelatedCreateModelData(VendorForm model)
        {
            LoadRelatedFormData(model);
        }

        [NonAction]
        protected override void LoadRelatedEditModelData(VendorForm model)
        {
            LoadRelatedFormData(model);
        }

        [NonAction]
        protected void LoadRelatedFormData(VendorForm model)
        {
            model.Countries = _countryService.Query.Where(c => c.Enabled).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
            model.GoogleCategories = _categoryService.Query.Where(c => c.Enabled).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
        }
    }
}
