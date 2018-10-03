using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monona.Core.Entities;
using Monona.Data;
using Monona.Services;
using Monona.Web.Models.Reservations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class ReservationsController : GenericCrudController<Reservation, int, ReservationService, ReservationFilter, ReservationListItem, ReservationCreateForm, ReservationEditForm>
    {
        private MononaDbContext _context;

        public ReservationsController(ReservationService service, MononaDbContext context): base(service)
        {
            _context = context;
        }

        protected override bool LoadEntityDataBeforeCreate(ReservationCreateForm model)
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

        protected override bool LoadEntityDataBeforeEdit(ReservationEditForm model)
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

        protected override void LoadRelatedCreateModelData(ReservationCreateForm model)
        {
            base.LoadRelatedCreateModelData(model);
            model.Stores = _context.Stores.Where(s => s.Enabled).OrderBy(s => s.Name).Select(s => new { s.Id, s.Name }).ToList().Select(s => new SelectListItem(s.Name, s.Id.ToString())).ToList();
        }

        protected override void LoadRelatedEditModelData(ReservationEditForm model)
        {
            base.LoadRelatedEditModelData(model);
            model.Store = _context.Stores.Find(model.StoreId);
        }        
    }
}
