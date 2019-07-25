using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Data;
using SkyHigh.Domain;
using SkyHigh.Models.Airports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public class AirportsService : IAirportsService
    {
        private readonly SkyHighDbContext dbContext;
        private readonly ICitiesService citiesService;
        private readonly IMapper mapper;

        public AirportsService(SkyHighDbContext dbContext, ICitiesService citiesService, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.citiesService = citiesService;
            this.mapper = mapper;
        }

        public async Task CreateAirportAsync(AirportCreateInputModel model)
        {
            var airport = this.mapper.Map<Airport>(model);
            this.dbContext.Airports.Add(airport);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AirportCreateInputModel> GetAirportCreateInputModelAsync()
        {
            var model = new AirportCreateInputModel();
            model.Cities = await this.citiesService.GetAllCitiesAsDropdownListAsync();

            return model;
        }

        public async Task<bool> IsAirportExistsAsync(string icaoCode)
        {
            var airport = await this.dbContext.Airports.SingleOrDefaultAsync(a => a.IcaoCode == icaoCode);
            if (airport != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<AirportIndexViewModel>> GetAllAirportsAsync()
        {

            var model = await this.dbContext.Airports
                                  .OrderBy(a => a.IcaoCode)
                                  .ThenBy(a => a.Name)
                                  .Select(a => new AirportIndexViewModel
                                  {
                                      Id = a.Id,
                                      Name = a.Name,
                                      IcaoCode = a.IcaoCode,
                                      CityName = a.City.Name
                                  })
                                  .ToArrayAsync();
            //.ProjectTo<AirportIndexViewModel>();

            return model;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAirportsAsDropdownListAsync()
        {
            var airports = await this.dbContext.Airports
                                                .Select(a => new SelectListItem
                                                {
                                                    Value = a.Id,
                                                    Text = $"{a.IcaoCode}-{a.Name}-{a.City.Name}"
                                                })
                                                .ToArrayAsync();
            return airports;
        }
    }
}
