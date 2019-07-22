using AutoMapper;
using SkyHigh.Domain;
using SkyHigh.Models.Aircrafts;
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
        }
    }
}
