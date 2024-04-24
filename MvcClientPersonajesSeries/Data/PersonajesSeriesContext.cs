using Microsoft.EntityFrameworkCore;
using MvcClientPersonajesSeries.Models;
using System.Collections.Generic;

namespace MvcClientPersonajesSeries.Data
{
    public class PersonajesSeriesContext: DbContext 
    {
        public PersonajesSeriesContext(DbContextOptions<PersonajesSeriesContext> options) : base(options) { }

        public DbSet<PersonajesSeries> PersonajesSeries { get; set; }
    }
}
