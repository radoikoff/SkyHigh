using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Data;
using SkyHigh.Domain;
using SkyHigh.Models.Countries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly SkyHighDbContext dbContext;

        public CountriesService(SkyHighDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<bool> IsCountryExistsAsync(string name)
        {
            var country = await this.dbContext.Countries.SingleOrDefaultAsync(c => c.Name == name);

            if (country != null)
            {
                return true;
            }

            return false;
        }

        public async Task CreateCountryAsync(string name)
        {
            var country = new Country()
            {
                Name = name
            };

            await this.dbContext.Countries.AddAsync(country);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CountryViewModel>> GetAllCountriesAsync()
        {
            var countries = await this.dbContext.Countries
                                                .OrderBy(c => c.Name)
                                                .Select(c => new CountryViewModel
                                                {
                                                    Id = c.Id,
                                                    Name = c.Name
                                                })
                                                .ToArrayAsync();
            return countries;
        }

        public async Task<IEnumerable<SelectListItem>> GetAllCountriesAsDropdownListAsync()
        {
            var countries = await this.dbContext.Countries
                                                .OrderBy(c => c.Name)
                                                .Select(c => new SelectListItem
                                                {
                                                    Text = c.Name,
                                                    Value = c.Id
                                                })
                                                .ToArrayAsync();
            return countries;
        }

        public async Task<IEnumerable<CountryIndexViewModel>> GetAllCountriesWithCitiesAsync()
        {
            var countries = await this.dbContext.Countries
                                                .OrderBy(c => c.Name)
                                                .Select(c => new CountryIndexViewModel
                                                {
                                                    Id = c.Id,
                                                    Name = c.Name,
                                                    Cities = c.Cities.Select(city => city.Name).ToArray()
                                                })
                                                .ToArrayAsync();

            return countries;
        }

        public async Task UpdateCountryAsync(string id, string newName)
        {
            var country = await this.dbContext.Countries.FindAsync(id);

            if (country == null)
            {
                return;
            }

            country.Name = newName;

            this.dbContext.Countries.Update(country);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<CountryEditInputModel> GetCountryEditData(string id)
        {
            var country = await this.dbContext.Countries.FindAsync(id);

            if (country == null)
            {
                throw new NullReferenceException("Selected country does not exisit");
            }

            var model = new CountryEditInputModel
            {
                Id = country.Id,
                NewName = country.Name,
                CurrentName = country.Name
            };

            return model;
        }
    }
}
