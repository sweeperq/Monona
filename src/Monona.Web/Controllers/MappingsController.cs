using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Core.Specifications;
using Monona.Services;
using Monona.Web.Models.Mappings;

namespace Monona.Web.Controllers
{
    public class MappingsController : GenericCrudController<Mapping, int, GenericService<Mapping,int>, MappingFilter, MappingListItem, MappingForm, MappingForm>
    {
        private GenericService<Store, int> _storeService;
        private GenericService<Product, int> _productService;

        public MappingsController(GenericService<Mapping,int> service, GenericService<Store, int> storeService, GenericService<Product,int> productService) : base(service)
        {
            _storeService = storeService;
            _productService = productService;
        }

        protected override void LoadFilterModelData(MappingFilter filter)
        {
            filter.Stores = LoadStores();
        }

        protected override void LoadRelatedCreateModelData(MappingForm model)
        {
            model.Stores = LoadStores();
        }

        protected override void LoadRelatedEditModelData(MappingForm model)
        {
            model.Stores = LoadStores();
        }

        protected override bool LoadEntityDataBeforeCreate(MappingForm model)
        {
            return LoadEntityDataBeforeSave(model);
        }

        protected override bool LoadEntityDataBeforeEdit(MappingForm model)
        {
            return LoadEntityDataBeforeSave(model);
        }

        protected bool LoadEntityDataBeforeSave(MappingForm model)
        {
            var product = _productService.FindSingle(new Specification<Product>(p => p.Sku == model.Sku));
            if (product == null)
            {
                ModelState.AddModelError("Sku", "Sku not found");
                return false;
            }
            model.ProductId = product.Id;
            return true;
        }

        protected ICollection<SelectListItem> LoadStores()
        {
            return _storeService.Query.Where(s => s.Enabled).OrderBy(s => s.Name).Select(s => new { s.Id, s.Name }).ToList().Select(s => new SelectListItem(s.Name, s.Id.ToString())).ToList();
        }
    }
}
