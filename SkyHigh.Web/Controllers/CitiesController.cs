using Microsoft.AspNetCore.Mvc;
using SkyHigh.Models.Cities;
using SkyHigh.Models.Countries;
using SkyHigh.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkyHigh.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICitiesService citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.citiesService.GetAllCitiesAsync();

            return this.View(viewModel);
        }


        public IActionResult Create()
        {
            var viewModel = this.citiesService.GetAllCountries();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.citiesService.AddCityAsync(model.Name, model.CountryId);

            return RedirectToAction("Index");
        }


        public IActionResult Edit(string id)
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Edit()
        {

            return this.View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index"); //TODO: Redirect to error
            }

            bool sucess = await this.citiesService.DeleteByIdAsync(id);

            if (sucess == false)
            {
                return RedirectToAction("Index"); //TODO: Redirect to error
            }

            return RedirectToAction("Index");
        }
    }
}
