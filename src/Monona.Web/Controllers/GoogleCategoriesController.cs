using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Specifications;
using Monona.Services;
using Monona.Web.Models.GoogleCategories;
using Monona.Web.SearchFilters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class GoogleCategoriesController : Controller
    {
        private GoogleCategoryService _service;

        public GoogleCategoriesController(GoogleCategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            SearchFilterHelpers.ClearSearchFilter<GoogleCategoryFilter>(this);
            return RedirectToAction("List");
        }

        public IActionResult Search(GoogleCategoryFilter filter)
        {
            SearchFilterHelpers.SetSearchFilter(this, filter);
            return RedirectToAction("List");
        }

        public IActionResult Sort(string sortField, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (!sortField.IsEmpty())
            {
                var filter = SearchFilterHelpers.GetSearchFilter<GoogleCategoryFilter>(this);
                filter.SortField = sortField;
                filter.SortDirection = sortDirection;
                SearchFilterHelpers.SetSearchFilter(this, filter);
            }
            return RedirectToAction("List");
        }

        public IActionResult List(int page = 1)
        {
            var model = new PagedSearchResult<GoogleCategoryListItem, GoogleCategoryFilter>();
            model.Filter = SearchFilterHelpers.GetSearchFilter<GoogleCategoryFilter>(this);
            if (page != model.Filter.Page)
            {
                model.Filter.Page = page;
                SearchFilterHelpers.SetSearchFilter(this, model.Filter);
            }
            model.Results = _service.FindManyDtoPaged<GoogleCategoryListItem>(model.Filter.Page, model.Filter.PageSize, model.Filter.GetSpecification(), model.Filter.GetSortSpecifications());
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new GoogleCategoryForm();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(GoogleCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.CreateFromDto<GoogleCategoryForm>(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddResultErrors(result);
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetByIdDto<GoogleCategoryForm>(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(GoogleCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.UpdateFromDto<GoogleCategoryForm>(model.Id, model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddResultErrors(result);
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var result = _service.DeleteById(id);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddResultErrors(result);
            return BadRequest(ModelState);
        }
    }
}
