using AutoMapper;
using SkyHigh.Domain;
using SkyHigh.Domain.Enums;
using SkyHigh.Models.Aircrafts;
using SkyHigh.Models.Airports;
using SkyHigh.Models.Flights;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkyHigh.Services
{
    public class ServicesMappingProfile : Profile
    {
        public ServicesMappingProfile()
        {
            CreateMap<AircraftCreateInputModel, Aircraft>();
            CreateMap<Aircraft, AircraftIndexViewModel>();

            CreateMap<AirportCreateInputModel, Airport>();

            CreateMap<FlightCreateInputModel, Flight>()
                .ForMember(m => m.FlightStatus, opt => opt.MapFrom(s => FlightStatus.Scheduled));

            CreateMap<Flight, FlightViewModel>();


        }
    }
}
