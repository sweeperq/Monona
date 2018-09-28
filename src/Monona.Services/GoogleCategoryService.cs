using AutoMapper;
using Monona.Core.Entities;
using Monona.Data;

namespace Monona.Services
{
    public class GoogleCategoryService : BaseService<GoogleCategory, int>
    {
        public GoogleCategoryService(MononaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
