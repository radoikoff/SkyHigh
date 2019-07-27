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

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Create));
        }


        public IActionResult Routes(string sourceAirportId, string destinationAirportId)
        {
            var model = this.reservationsService.GetRoutes(sourceAirportId, destinationAirportId);

            return PartialView("_RoutesPartial", model);
        }

        public async Task<IActionResult> Create()
        {
            var model = new ReservationCreateInputModel
            {
                Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateInputModel model)
        {
            if (model.SourceAirportId == model.DestinationAirportId)
            {
                this.ModelState.AddModelError("DestinationAirportId", "Source and destination airports must be different");
            }

            if (!this.ModelState.IsValid)
            {
                model.Airports = await this.airportsService.GetAllAirportsAsDropdownListAsync();
                return this.View(model);
            }
            ;

            return RedirectToAction("Index", "Home");
        }


    }
}