using AutoMapper;
using Monona.Core.Entities;
using Monona.Data;
using System.Linq;

namespace Monona.Services
{
    public class CountryService : BaseService<Country, int>
    {
        public CountryService(MononaDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override ServiceResult ValidateEntity(Country entity)
        {
            var result = base.ValidateEntity(entity);
            if (result.Succeeded)
            {
                if (Entities.Any(c => c.Abbreviation == entity.Abbreviation && !entity.Id.Equals(c.Id)))
                {
                    result.AddError($"Abbreviation '{entity.Abbreviation}' already in use", "Abbreviation");
                }
            }
            return result;
        }
    }
}
