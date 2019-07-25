using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Data;
using SkyHigh.Domain;
using SkyHigh.Models.Aircrafts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyHigh.Services
{
    public class AircraftsService : IAircraftsService
    {
        private readonly SkyHighDbContext dbContext;
        private readonly IMapper mapper;

        public AircraftsService(SkyHighDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }


        public async Task CreateAircraftAsync(AircraftCreateInputModel model)
        {
            var aircraft = this.mapper.Map<Aircraft>(model);

            await this.dbContext.Aircrafts.AddAsync(aircraft);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAircraftsAsDropdownListAsync()
        {
            var aircrafts = await this.dbContext.Aircrafts
                                                .Select(a => new SelectListItem
                                                {
                                                    Value = a.Id,
                                                    Text = $"{a.RegistrationNumber}-{a.Type}-{a.Manufacturer}"
                                                })
                                                .ToArrayAsync();
            return aircrafts;
        }

        public async Task<IEnumerable<AircraftIndexViewModel>> GetAllAircraftsAsync()
        {
            var aircrafts = await this.dbContext.Aircrafts.ToArrayAsync();

            var model = this.mapper.Map<IEnumerable<AircraftIndexViewModel>>(aircrafts);

            return model;
        }

        public async Task<bool> IsAircraftExistsAsync(string registrationNumber)
        {
            var aircraft = await this.dbContext.Aircrafts.SingleOrDefaultAsync(a => a.RegistrationNumber == registrationNumber);

            if (aircraft != null)
            {
                return true;
            }

            return false;
        }
    }

    public interface IAircraftsService
    {
        Task CreateAircraftAsync(AircraftCreateInputModel model);

        Task<IEnumerable<SelectListItem>> GetAllAircraftsAsDropdownListAsync();

        Task<IEnumerable<AircraftIndexViewModel>> GetAllAircraftsAsync();

        Task<bool> IsAircraftExistsAsync(string registrationNumber);
    }
}
