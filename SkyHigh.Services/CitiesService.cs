using Microsoft.AspNetCore.Mvc.Rendering;
using SkyHigh.Data;
using SkyHigh.Domain;
using SkyHigh.Models.Cities;
using System;
using System.Collections.Generic;
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

        public async Task AddCityAsync(string name, string countryId)
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

        public async Task<CityIndexViewModel> GetAllCitiesAsync()
        {
            var result = new CityIndexViewModel
            {
                CityViewModels = new List<CityViewModel>()
                 {
                     new CityViewModel
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "Sofia",
                         CountryName = "Bulgaria",
                         Airports = new List<string> {"LBSF, FRA, MUC" }
                     },

                     new CityViewModel
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "London",
                         CountryName = "UK",
                         Airports = new List<string> {"AZS, FFGT, UART, JJK" }
                     },

                     new CityViewModel
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "New York",
                         CountryName = "United States of America",
                         Airports = new List<string> {"JFK, HOL, LAX"}
                     },
                     new CityViewModel
                     {
                         Id = Guid.NewGuid().ToString(),
                         Name = "Varna",
                         CountryName = "Bulgaria",
                         Airports = new List<string>()
                     }
                 }
            };

            return result;
        }

        public CityCreateInputModel GetAllCountries()
        {
            var viewModel = new CityCreateInputModel()
            {
                Countries = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "Pehso",
                        Value = "1"
                    },
                    new SelectListItem
                    {
                        Text = "Gosho",
                        Value = "2"
                    },
                    new SelectListItem
                    {
                        Text = "Uli",
                        Value = "3"
                    }
                }

            };


            return viewModel;
        }
    }

    public interface ICitiesService
    {
        Task<CityIndexViewModel> GetAllCitiesAsync();

        CityCreateInputModel GetAllCountries();

        Task AddCityAsync(string name, string countryId);

        Task<bool> DeleteByIdAsync(string id);
    }
}
