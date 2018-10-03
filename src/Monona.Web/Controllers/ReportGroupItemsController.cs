using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Data;
using Monona.Services;
using Monona.Web.Models.ReportGroupItems;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class ReportGroupItemsController : GenericCrudController<ReportGroupItem, int, GenericService<ReportGroupItem, int>, ReportGroupItemFilter, ReportGroupItemListItem, ReportGroupItemForm, ReportGroupItemForm>
    {
        private MononaDbContext _context;

        public ReportGroupItemsController(GenericService<ReportGroupItem, int> service, MononaDbContext context) : base(service)
        {
            _context = context;
        }

        protected override void LoadFilterModelData(ReportGroupItemFilter filter)
        {
            filter.ReportGroups = _context.ReportGroups.OrderBy(r => r.Name).Select(s => new { s.Id, s.Name }).ToList().Select(s => new SelectListItem(s.Name, s.Id.ToString()));
        }

        protected override void LoadRelatedCreateModelData(ReportGroupItemForm model)
        {
            model.ReportGroups = _context.ReportGroups.OrderBy(r => r.Name).Select(s => new { s.Id, s.Name }).ToList().Select(s => new SelectListItem(s.Name, s.Id.ToString()));
            if (Request.Method.ToLowerInvariant() == "get")
            {
                string reportGroupId = Request.Query["ReportGroupId"];
                if (!reportGroupId.IsEmpty())
                {
                    model.ReportGroupId = int.Parse(reportGroupId);
                }
            }
            
        }

        protected override bool LoadEntityDataBeforeCreate(ReportGroupItemForm model)
        {
            var prod = _context.Products.FirstOrDefault(p => p.Sku == model.Sku);
            if (prod == null)
            {
                ModelState.AddModelError("Sku", $"Sku '{model.Sku}' not found");
                return false;
            }
            model.ProductId = prod.Id;
            return true;
        }        


        public override IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        public override IActionResult Edit([FromRoute] int id, ReportGroupItemForm model)
        {
            throw new NotImplementedException();
        }
    }
}
