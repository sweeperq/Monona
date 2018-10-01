using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Services;
using Monona.Web.Models.Products;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class ProductsController : GenericCrudController<Product, int, GenericService<Product,int>, ProductFilter, ProductListItem, ProductForm, ProductForm>
    {
        private GenericService<Store, int> _storeService;
        private GenericService<Vendor, int> _vendorService;
        private GenericService<Country, int> _countryService;
        private GenericService<GoogleCategory, int> _categoryService;

        public ProductsController(GenericService<Product,int> service, GenericService<Store,int> storeService, 
            GenericService<Vendor,int> vendorService, GenericService<Country,int> countryService, GenericService<GoogleCategory,int> categoryService) : base(service)
        {
            _storeService = storeService;
            _vendorService = vendorService;
            _countryService = countryService;
            _categoryService = categoryService;
        }

        [NonAction]
        protected override void LoadFilterModelData(ProductFilter filter)
        {
            filter.Vendors = _vendorService.Query.Where(v => v.Enabled).OrderBy(v => v.Name).Select(v => new SelectListItem(v.Name, v.Id.ToString())).ToList();
        }

        [NonAction]
        protected override void LoadRelatedCreateModelData(ProductForm model)
        {
            LoadRelatedFormData(model);
        }

        [NonAction]
        protected override void LoadRelatedEditModelData(ProductForm model)
        {
            LoadRelatedFormData(model);
        }

        [NonAction]
        protected void LoadRelatedFormData(ProductForm model)
        {
            model.Stores = _storeService.Query.Where(s => s.Enabled).OrderBy(s => s.Name).Select(s => new SelectListItem(s.Name, s.Id.ToString())).ToList();
            model.Vendors = _vendorService.Query.Where(v => v.Enabled).OrderBy(v => v.Name).Select(v => new SelectListItem(v.Name, v.Id.ToString())).ToList();
            model.Countries = _countryService.Query.Where(c => c.Enabled).OrderBy(c => c.Name).Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToList();
            model.GoogleCategories = _categoryService.Query.Where(g => g.Enabled).OrderBy(g => g.Name).Select(g => new SelectListItem(g.Name, g.Id.ToString())).ToList();
        }

    }
}
