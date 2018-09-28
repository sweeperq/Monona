using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Core.Specifications;
using Monona.Services;
using Monona.Web.Models.Countries;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            return RedirectToAction("List");   
        }

        public IActionResult List()
        {
            var models = _service.GetAllDto<CountryListItem>(new[] { new SortSpecification<Country>(x => x.Name) });
            return View(models);
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
