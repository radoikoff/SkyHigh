using SkyHigh.Data;
using SkyHigh.Models.Countries;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyHigh.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly SkyHighDbContext dbContext;

        public CountriesService(SkyHighDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<CountryViewModel> GetAllCountriesAsync()
        {
            return null;
        }


    }

    public interface ICountriesService
    {


    }
}
