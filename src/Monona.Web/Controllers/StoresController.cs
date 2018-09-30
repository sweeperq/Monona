using Monona.Core.Entities;
using Monona.Services;
using Monona.Web.Models.Stores;

namespace Monona.Web.Controllers
{
    public class StoresController : GenericCrudController<Store, int, GenericService<Store,int>, StoreFilter, StoreListItem, StoreForm, StoreForm>
    {
        public StoresController(GenericService<Store,int> service) : base(service)
        {
        }
    }
}
