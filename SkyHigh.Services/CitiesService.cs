using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Data;
using SkyHigh.Domain;
using SkyHigh.Models.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly SkyHighDbContext dbContext;

        public CitiesService(SkyHighDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateCityAsync(string name, string countryId)
        {
            var country = await this.dbContext.Countries.FindAsync(countryId);

            if (country == null)
            {
                throw new NullReferenceException("Selected country does not exisit");
            }

            var city = new City()
            {
                Country = country,
                Name = name
            };

            await this.dbContext.Cities.AddAsync(city);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteByIdAsync(string id)
        {
            var city = await this.dbContext.Cities.FindAsync(id);

            if (city == null)
            {
                return false;
            }

            this.dbContext.Cities.Remove(city);
            await this.dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<CityIndexViewModel>> GetAllCitiesAsync()
        {

            var model = await this.dbContext.Cities
                                  .OrderBy(c => c.Name)
                                  .Select(c => new CityIndexViewModel
                                  {
                                      Id = c.Id,
                                      Name = c.Name,
                                      CountryName = c.Country.Name,
                                      AirportCodes = c.Airports.Select(a => a.IcaoCode).ToList()
                                  })
                                  .ToArrayAsync();
            return model;
        }

        public async Task<CityEditInputModel> GetCityEditData(string id)
        {
            var model = await this.dbContext.Cities.Where(c => c.Id == id).Select(x => new CityEditInputModel
            {
                NewName = x.Name,
                CurrentName = x.Name,
                CountryId = x.CountryId,
                CurrentCountry = x.Country.Name
            })
            .SingleOrDefaultAsync();

            return model;
        }

        public async Task<bool> IsCityExistsAsync(string name, string countryId)
        {
            var city = await this.dbContext.Cities.SingleOrDefaultAsync(c => c.Name == name && c.CountryId == countryId);

            if (city != null)
            {
                return true;
            }

            return false;
        }

        public async Task UpdateCityAsync(string id, string newName, string countryId)
        {
            var city = await this.dbContext.Cities.FindAsync(id);

            if (city == null)
            {
                return;
            }

            city.Name = newName;
            city.CountryId = countryId;

            this.dbContext.Cities.Update(city);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
