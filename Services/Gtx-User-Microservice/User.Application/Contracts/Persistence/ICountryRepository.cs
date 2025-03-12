using User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface ICountryRepository : IAsyncRepository<CountryMaster>
    {
       // Task<GetCountryVm> GetCountry(GetCountryQuery request);

    }
}
