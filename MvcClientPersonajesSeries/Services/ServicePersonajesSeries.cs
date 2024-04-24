using MvcClientPersonajesSeries.Data;
using MvcClientPersonajesSeries.Models;
using System.Net.Http.Headers;

namespace MvcClientPersonajesSeries.Services
{
    public class ServicePersonajesSeries
    {
        private string urlApiPersonajes;
        private MediaTypeWithQualityHeaderValue header;
        private IHttpContextAccessor httpContextAccessor;
        private PersonajesSeriesContext context;


        public ServicePersonajesSeries(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, PersonajesSeriesContext context)
        {
            this.urlApiPersonajes = configuration.GetValue<string>("ConnectionStrings:ApiPersonajes");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.httpContextAccessor = httpContextAccessor;
            this.context = context;
        }

        public async Task<List<PersonajesSeries>> GetPersonajesAsync()
        {
            string request = "api/PersonajesSeries";

            List<PersonajesSeries> personajes = await this.CallApiSync<List<PersonajesSeries>>(request);

            return personajes;
        }

        public async Task<PersonajesSeries> GetPersonajesConSerieAsync(int id)
        {
            string request = "/api/PersonajesSeries/" + id;

            PersonajesSeries personaje = await this.CallApiSync<PersonajesSeries>(request);

            return personaje;
        }

        public async Task<List<string>> GetSerieAsync()
        {
            string request = "api/PersonajesSeries/Series";

           return await this.CallApiSync<List<string>>(request);

        }
        public async Task<PersonajesSeries> GetPersonajesConSerieAsync(string serie)
        {
            string request = "api/PersonajesSeries/PeronajesSeries/" + serie;

            PersonajesSeries personaje = await this.CallApiSync<PersonajesSeries>(request);

            return personaje;
        }
        //public Task CreatePersonajeAsync(PersonajesSeries personaje)
        //{
        //    string request = "api/PersonajesSeries/InsertarPersonaje";
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(this.urlApiPersonajes);
        //        client.DefaultRequestHeaders.Clear();
        //    }
        //}

        private async Task<T> CallApiSync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {

                client.BaseAddress = new Uri(this.urlApiPersonajes);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);

                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        
    }

    
}
