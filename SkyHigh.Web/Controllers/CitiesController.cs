using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly ICountriesService countriesService;

        public CitiesController(ICitiesService citiesService, ICountriesService countriesService)
        {
            this.citiesService = citiesService;
            this.countriesService = countriesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await this.citiesService.GetAllCitiesAsync();

            return this.View(viewModel);
        }


        public async Task<IActionResult> Create()
        {
            var countries = await this.countriesService.GetAllCountriesAsync();

            var viewModel = new CityCreateInputModel()
            {
                Countries = countries.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id
                })
                .ToList()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CityCreateInputModel model)
        {
            bool isCityExisits = await this.citiesService.IsCityExistsAsync(model.Name, model.CountryId);

            if (isCityExisits)
            {
                this.ModelState.AddModelError("Name", "Provided city name already exists");
            }

            if (!this.ModelState.IsValid)
            {
                var countries = await this.countriesService.GetAllCountriesAsync();

                model.Countries = countries.Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id
                })
                .ToList();


                return this.View(model);
            }

            await this.citiesService.CreateCityAsync(model.Name, model.CountryId);

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(string id)
        {
            var model = await this.citiesService.GetCityEditData(id);

            var countriesList = await this.countriesService.GetAllCountriesAsDropdownListAsync();

            model.Countries = countriesList;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CityEditInputModel model)
        {

            bool isExisits = await this.citiesService.IsCityExistsAsync(model.NewName, model.CountryId);

            if (isExisits)
            {
                this.ModelState.AddModelError("NewName", "Provided city name already exists");
            }

            if (!this.ModelState.IsValid)
            {
                var countriesList = await this.countriesService.GetAllCountriesAsDropdownListAsync();
                model.Countries = countriesList;
                return this.View(model);
            }

            await this.citiesService.UpdateCityAsync(model.Id, model.NewName, model.CountryId);

            return RedirectToAction(nameof(Index));
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
