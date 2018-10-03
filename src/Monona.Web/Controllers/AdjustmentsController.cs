using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Data;
using Monona.Services;
using Monona.Web.Models.Adjustments;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class AdjustmentsController : GenericCrudController<Adjustment, int, AdjustmentService, AdjustmentFilter, AdjustmentListItem, AdjustmentForm, AdjustmentForm>
    {
        private MononaDbContext _context;

        public AdjustmentsController(AdjustmentService service, MononaDbContext context) : base(service)
        {
            _context = context;
        }

        protected override void LoadFilterModelData(AdjustmentFilter filter)
        {
            filter.AdjustmentTypes = _context.AdjustmentTypes.Where(a => a.Enabled).OrderBy(a => a.Name).Select(a => new { a.Id, a.Name }).ToList().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            filter.Stores = _context.Stores.Where(s => s.Enabled).OrderBy(s => s.Name).Select(s => new { s.Id, s.Name }).ToList().Select(s => new SelectListItem(s.Name, s.Id.ToString()));
        }

        protected override void LoadRelatedCreateModelData(AdjustmentForm model)
        {
            model.AdjustmentTypes = _context.AdjustmentTypes.Where(a => a.Enabled).OrderBy(a => a.Name).Select(a => new { a.Id, a.Name }).ToList().Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            model.Stores = _context.Stores.Where(s => s.Enabled).OrderBy(s => s.Name).Select(s => new { s.Id, s.Name }).ToList().Select(s => new SelectListItem(s.Name, s.Id.ToString()));
        }

        protected override bool LoadEntityDataBeforeCreate(AdjustmentForm model)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Sku == model.Sku);
            if (prod == null)
            {
                ModelState.AddModelError("Sku", $"Sku '{model.Sku}' not found");
                return false;
            }
            model.ProductId = prod.Id;
            return true;
        }

        /* No Edit or Delete for Adjustments. They are a permanent history. */
        public override IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Edit([FromRoute] int id, AdjustmentForm model)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
