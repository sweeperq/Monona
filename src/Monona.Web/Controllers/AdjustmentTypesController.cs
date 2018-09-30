using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Services;
using Monona.Web.Models.AdjustmentTypes;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class AdjustmentTypesController : GenericCrudController<AdjustmentType, int, GenericService<AdjustmentType, int>, AdjustmentTypeFilter, AdjustmentTypeListItem, AdjustmentTypeForm, AdjustmentTypeForm>
    {
        public AdjustmentTypesController(GenericService<AdjustmentType, int> service) : base(service)
        {
        }
    }
}
