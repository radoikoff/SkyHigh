using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Models.Countries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public interface ICountriesService
    {
        Task<bool> IsCountryExistsAsync(string name);

        Task CreateCountryAsync(string name);

        Task UpdateCountryAsync(string id, string newName);

        Task<IEnumerable<CountryViewModel>> GetAllCountriesAsync();

        Task<IEnumerable<SelectListItem>> GetAllCountriesAsDropdownListAsync();

        Task<IEnumerable<CountryIndexViewModel>> GetAllCountriesWithCitiesAsync();

        Task<CountryEditInputModel> GetCountryEditData(string id);
    }
}
