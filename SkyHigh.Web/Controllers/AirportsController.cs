using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyHigh.Models.Airports;
using SkyHigh.Services;

namespace SkyHigh.Web.Controllers
{
    public class AirportsController : Controller
    {

        private readonly IAirportsService airportsService;
        private readonly ICitiesService citiesService;

        public AirportsController(IAirportsService airportsService, ICitiesService citiesService)
        {
            this.airportsService = airportsService;
            this.citiesService = citiesService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.airportsService.GetAllAirportsAsync();
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new AirportCreateInputModel();
            model.Cities = await this.citiesService.GetAllCitiesAsDropdownListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AirportCreateInputModel model)
        {
            bool isAirportExists = await this.airportsService.IsAirportExistsAsync(model.IcaoCode);

            if (isAirportExists)
            {
                this.ModelState.AddModelError("IcaoCode", "Provided ICAO Code already exists");
            }

            if (!this.ModelState.IsValid)
            {
                model.Cities = await this.citiesService.GetAllCitiesAsDropdownListAsync();
                return this.View(model);
            }

            await this.airportsService.CreateAirportAsync(model);

            return RedirectToAction("Index");
        }

    }
}