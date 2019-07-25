using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyHigh.Models.Flights;
using SkyHigh.Services;

namespace SkyHigh.Web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightsService flightsService;
        private readonly IAircraftsService aircraftsService;
        private readonly IAirportsService airportsService;

        public FlightsController(IFlightsService flightsService, IAircraftsService aircraftsService, IAirportsService airportsService)
        {
            this.flightsService = flightsService;
            this.aircraftsService = aircraftsService;
            this.airportsService = airportsService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Create()
        {
            var model = new FlightCreateInputModel
            {
                Aircrafts = await this.aircraftsService.GetAllAircraftsAsDropdownListAsync(),
                Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlightCreateInputModel model)
        {
            bool isFlightExisits = await this.flightsService.IsFlightExistsAsync(model.ReferenceNumber);

            if (isFlightExisits)
            {
                this.ModelState.AddModelError("ReferenceNumber", "Provided flight number already exists");
            }

            if (model.SourceAirportId == model.DestinationAirportId)
            {
                this.ModelState.AddModelError("DestinationAirportId", "Source and destination airports must be different");
            }

            if (!this.ModelState.IsValid)
            {
                model.Aircrafts = await this.aircraftsService.GetAllAircraftsAsDropdownListAsync();
                model.Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync();
                return this.View(model);
            }

            await this.flightsService.CreateFlightAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}