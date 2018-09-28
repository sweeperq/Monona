using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Core.Specifications;
using Monona.Services;
using Monona.Web.Models.Countries;
using Monona.Web.SearchFilters;

namespace Monona.Web.Controllers
{
    public class CountriesController : Controller
    {
        private CountryService _service;

        public CountriesController(CountryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            SearchFilterHelpers.ClearSearchFilter<CountryFilter>(this);
            return RedirectToAction("List");   
        }

        public IActionResult Search(CountryFilter filter)
        {
            SearchFilterHelpers.SetSearchFilter(this, filter);
            return RedirectToAction("List");
        }

        public IActionResult Sort(string sortField, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (!sortField.IsEmpty())
            {
                var filter = SearchFilterHelpers.GetSearchFilter<CountryFilter>(this);
                filter.SortField = sortField;
                filter.SortDirection = sortDirection;
                SearchFilterHelpers.SetSearchFilter(this, filter);
            }
            return RedirectToAction("List");
        }

        public IActionResult List(int page = 1)
        {
            var model = new PagedSearchResult<CountryListItem, CountryFilter>();
            model.Filter = SearchFilterHelpers.GetSearchFilter<CountryFilter>(this);
            if (page != model.Filter.Page)
            {
                model.Filter.Page = page;
                SearchFilterHelpers.SetSearchFilter(this, model.Filter);
            }
            model.Results = _service.FindManyDtoPaged<CountryListItem>(model.Filter.Page, model.Filter.PageSize, model.Filter.GetSpecification(), model.Filter.GetSortSpecifications());
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CountryForm();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CountryForm model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.CreateFromDto<CountryForm>(model);
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
            var model = _service.GetByIdDto<CountryForm>(id);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CountryForm model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.UpdateFromDto<CountryForm>(model.Id, model);
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
