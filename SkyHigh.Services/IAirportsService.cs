using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Models.Airports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public interface IAirportsService
    {
        Task<AirportCreateInputModel> GetAirportCreateInputModelAsync();

        Task CreateAirportAsync(AirportCreateInputModel model);

        Task<bool> IsAirportExistsAsync(string icaoCode);

        Task<IEnumerable<AirportIndexViewModel>> GetAllAirportsAsync();

        Task<IEnumerable<SelectListItem>> GetAllAirportsAsDropdownListAsync();
    }
}
