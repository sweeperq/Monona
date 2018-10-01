using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Core.Specifications;
using Monona.Services;
using Monona.Web.SearchFilters;
using System;
using System.Linq;

namespace Monona.Web.Controllers
{
    public abstract class GenericCrudController<TEntity, TKey, TService, TFilter, TListItem, TCreateModel, TEditModel> : Controller
        where TKey : IEquatable<TKey>
        where TEntity : class, IEntity<TKey>
        where TService : GenericService<TEntity, TKey>
        where TFilter : BaseSearchFilter<TEntity>
        where TListItem : class
        where TCreateModel : class
        where TEditModel : class
    {
        private GenericService<TEntity, TKey> _service;

        public GenericCrudController(GenericService<TEntity, TKey> service)
        {
            _service = service;
        }

        public virtual IActionResult Index()
        {
            SearchFilterHelpers.ClearSearchFilter<TFilter>(this);
            return RedirectToAction("List");
        }

        public virtual IActionResult Search(TFilter filter)
        {
            SearchFilterHelpers.SetSearchFilter(this, filter);
            return RedirectToAction("List");
        }

        public virtual IActionResult Sort(string sortField, SortDirection sortDirection = SortDirection.Ascending)
        {
            if (!sortField.IsEmpty())
            {
                var filter = SearchFilterHelpers.GetSearchFilter<TFilter>(this);
                filter.SortField = sortField;
                filter.SortDirection = sortDirection;
                SearchFilterHelpers.SetSearchFilter(this, filter);
            }
            return RedirectToAction("List");
        }

        public virtual IActionResult List(int page = 1)
        {
            var model = new PagedSearchResult<TListItem, TFilter>();
            model.Filter = SearchFilterHelpers.GetSearchFilter<TFilter>(this);
            if (page != model.Filter.Page)
            {
                model.Filter.Page = page;
                SearchFilterHelpers.SetSearchFilter(this, model.Filter);
            }
            model.Results = _service.FindManyDtoPaged<TListItem>(model.Filter.Page, model.Filter.PageSize, model.Filter.GetSpecification(), model.Filter.GetSortSpecifications());
            return View(model);
        }

        public virtual IActionResult Create()
        {
            var model = (TCreateModel)Activator.CreateInstance(typeof(TCreateModel));
            LoadRelatedCreateModelData(model);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Create(TCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.CreateFromDto<TCreateModel>(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddResultErrors(result);
            }
            LoadRelatedCreateModelData(model);
            return View(model);
        }

        public virtual IActionResult Edit(TKey id)
        {
            var model = _service.GetByIdDto<TEditModel>(id);
            if (model == null)
                return NotFound();
            LoadRelatedEditModelData(model);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Edit([FromRoute]TKey id, TEditModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _service.UpdateFromDto<TEditModel>(id, model);
                if (result.Succeeded)
                {
                    return RedirectToAction("List");
                }
                ModelState.AddResultErrors(result);
            }
            LoadRelatedEditModelData(model);
            return View(model);
        }

        public virtual IActionResult Delete(TKey id)
        {
            var result = _service.DeleteById(id);
            if (result.Succeeded)
            {
                return RedirectToAction("List");
            }
            ModelState.AddResultErrors(result);
            return BadRequest(ModelState);
        }

        [NonAction]
        protected virtual void LoadRelatedCreateModelData(TCreateModel model)
        {
        }

        [NonAction]
        protected virtual void LoadRelatedEditModelData(TEditModel model)
        {
        }
    }
}
