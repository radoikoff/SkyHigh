using AutoMapper;
using AutoMapper.QueryableExtensions;
using SkyHigh.Data;
using SkyHigh.Models.Flights;
using SkyHigh.Models.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkyHigh.Services
{
    public class ReservationsService : IReservationsService
    {

        private readonly SkyHighDbContext dbContext;
        private readonly IMapper mapper;

        public ReservationsService(SkyHighDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<Route> GetRoutes(string sourceAirportId, string destinationAirportId)
        {
            var flights = this.dbContext.Flights.ProjectTo<BookingFlightViewModel>(this.mapper.ConfigurationProvider).ToList();

            var routes = new List<Route>()
            {
                new Route
                {
                       Flights = flights.Take(2).ToList()
                },
                new Route
                {
                       Flights = flights.Skip(2).Take(2).ToList()
                },
                new Route
                {
                       Flights = new List<BookingFlightViewModel>(){ flights.First() }

                }
            };

            return routes;
        }
    }

    public interface IReservationsService
    {
        IEnumerable<Route> GetRoutes(string sourceAirportId, string destinationAirportId);
    }
}
