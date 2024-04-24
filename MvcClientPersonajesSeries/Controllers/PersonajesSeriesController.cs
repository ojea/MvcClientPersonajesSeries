using Microsoft.AspNetCore.Mvc;
using MvcClientPersonajesSeries.Models;
using MvcClientPersonajesSeries.Services;

namespace MvcClientPersonajesSeries.Controllers
{
    public class PersonajesSeriesController : Controller
    {
        private ServicePersonajesSeries service;
        private IWebHostEnvironment hostEnvironment;

        public PersonajesSeriesController(ServicePersonajesSeries service, IWebHostEnvironment hostEnvironment)
        {
            this.service = service;
            this.hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<PersonajesSeries> perfumes = await this.service.GetPersonajesAsync();
            return View(perfumes);
        }

        public async Task<IActionResult> DetallesPersonaje(int id)
        {

            PersonajesSeries personaje = await this.service.GetPersonajesConSerieAsync(id);
            return View(personaje);

        }

        public async Task<IActionResult> BuscarSerie(int id)
        {

            List<string> serie = await this.service.GetSerieAsync();
            ViewData["SERIES"] = serie;
            return View();
        }


    }
}
