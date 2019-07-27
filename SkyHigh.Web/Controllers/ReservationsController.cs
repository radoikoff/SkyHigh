using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyHigh.Models.Flights;
using SkyHigh.Models.Reservations;
using SkyHigh.Services;

namespace SkyHigh.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IFlightsService flightsService;
        private readonly IAirportsService airportsService;
        private readonly IReservationsService reservationsService;

        public ReservationsController(IFlightsService flightsService, IAirportsService airportsService, IReservationsService reservationsService)
        {
            this.flightsService = flightsService;
            this.airportsService = airportsService;
            this.reservationsService = reservationsService;
        }

        public async Task<IActionResult> Index(FlightSearchViewModel model)
        {
            
            model.Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync();


            return View(model);
        }


        public IActionResult Routes(string sourceAirportId, string destinationAirportId)
        {
            var model = this.reservationsService.GetRoutes(sourceAirportId, destinationAirportId);

            return PartialView("Routes", model);
        }

        //public async Task<IActionResult> Create()
        //{
        //    var model = new FlightCreateInputModel
        //    {
        //        //Aircrafts = await this.aircraftsService.GetAllAircraftsAsDropdownListAsync(),
        //        Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync()
        //    };

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(FlightCreateInputModel model)
        //{
        //    bool isFlightExisits = await this.flightsService.IsFlightExistsAsync(model.ReferenceNumber);

        //    if (isFlightExisits)
        //    {
        //        this.ModelState.AddModelError("ReferenceNumber", "Provided flight number already exists");
        //    }

        //    if (model.SourceAirportId == model.DestinationAirportId)
        //    {
        //        this.ModelState.AddModelError("DestinationAirportId", "Source and destination airports must be different");
        //    }

        //    if (!this.ModelState.IsValid)
        //    {
        //        //model.Aircrafts = await this.aircraftsService.GetAllAircraftsAsDropdownListAsync();
        //        model.Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync();
        //        return this.View(model);
        //    }

        //    await this.flightsService.CreateFlightAsync(model);

        //    return RedirectToAction(nameof(Index));
        //}


    }
}