using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Data;
using SkyHigh.Domain;
using SkyHigh.Models.Flights;

namespace SkyHigh.Services
{
    public class FlightsService : IFlightsService
    {

        private readonly SkyHighDbContext dbContext;
        private readonly IMapper mapper;

        public FlightsService(SkyHighDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task CreateFlightAsync(FlightCreateInputModel model)
        {
            var flight = this.mapper.Map<Flight>(model);

            await this.dbContext.Flights.AddAsync(flight);
            await this.dbContext.SaveChangesAsync();
        }

        public FlightIndexViewModel GetIndexView(string searchString)
        {

            var model = new FlightIndexViewModel
            {
                Flights = this.dbContext.Flights.ProjectTo<FlightViewModel>(this.mapper.ConfigurationProvider).ToList(),
                AirportName = searchString
            };

            return model;
        }

        public async Task<bool> IsFlightExistsAsync(string referenceNumber)
        {
            var flight = await this.dbContext.Flights.SingleOrDefaultAsync(a => a.ReferenceNumber == referenceNumber);
            if (flight != null)
            {
                return true;
            }
            return false;
        }
    }

    public interface IFlightsService
    {
        Task<bool> IsFlightExistsAsync(string referenceNumber);

        Task CreateFlightAsync(FlightCreateInputModel model);

        FlightIndexViewModel GetIndexView(string searchString);
    }
}
