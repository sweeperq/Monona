using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Monona.Core.Entities;
using Monona.Services;
using Monona.Web.Models.ReportGroups;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monona.Web.Controllers
{
    public class ReportGroupsController : GenericCrudController<ReportGroup, int, GenericService<ReportGroup, int>, ReportGroupFilter, ReportGroupListItem, ReportGroupForm, ReportGroupForm>
    {
        public ReportGroupsController(GenericService<ReportGroup, int> service) : base(service)
        {
        }
    }
}
