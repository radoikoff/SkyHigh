using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SkyHigh.Models.Aircrafts;
using SkyHigh.Services;

namespace SkyHigh.Web.Controllers
{
    public class AircraftsController : Controller
    {
        private readonly IAircraftsService aircraftsService;

        public AircraftsController(IAircraftsService aircraftsService)
        {
            this.aircraftsService = aircraftsService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await this.aircraftsService.GetAllAircraftsAsync();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(AircraftCreateInputModel model)
        {
            bool isAircraftExisits = await this.aircraftsService.IsAircraftExistsAsync(model.RegistrationNumber);

            if (isAircraftExisits)
            {
                this.ModelState.AddModelError("RegistrationNumber", "Provided registration number already exists");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.aircraftsService.CreateAircraftAsync(model);

            return RedirectToAction(nameof(Index));
        }



    }
}