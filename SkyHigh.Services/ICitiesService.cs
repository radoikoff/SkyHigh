using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Models.Cities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public interface ICitiesService
    {
        Task<bool> IsCityExistsAsync(string name, string countryId);

        Task<IEnumerable<CityIndexViewModel>> GetAllCitiesAsync();

        Task CreateCityAsync(string name, string countryId);

        Task UpdateCityAsync(string id, string newName, string countryId);

        Task<CityEditInputModel> GetCityEditData(string id);

        Task<bool> DeleteByIdAsync(string id);

        Task<IEnumerable<SelectListItem>> GetAllCitiesAsDropdownListAsync();

    }
}
