using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkyHigh.Models.Countries;
using SkyHigh.Services;

namespace SkyHigh.Web.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesService countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            this.countriesService = countriesService;
        }


        public async Task<ActionResult> Index()
        {
            var viewModel = await this.countriesService.GetAllCountriesWithCitiesAsync();

            return this.View(viewModel);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CountryCreateInputModel model)
        {
            bool isExisits = await this.countriesService.IsCountryExistsAsync(model.Name);

            if (isExisits)
            {
                this.ModelState.AddModelError("Name", "Provided country name already exists");
            }

            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.countriesService.CreateCountryAsync(model.Name);

            return RedirectToAction(nameof(Index));

        }

        public async Task<ActionResult> Edit(string id)
        {
            var model = await this.countriesService.GetCountryEditData(id);

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CountryEditInputModel model)
        {
            bool isExisits = await this.countriesService.IsCountryExistsAsync(model.NewName);

            if (isExisits)
            {
                this.ModelState.AddModelError("NewName", "Provided country name already exists");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.countriesService.UpdateCountryAsync(model.Id, model.NewName);

            return RedirectToAction(nameof(Index));
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Countries/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}