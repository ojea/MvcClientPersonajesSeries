﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MvcClientPersonajesSeries.Models
{
    [Table("PERSONAJESSERIES")]
    public class PersonajesSeries
    {

        [Key]
        [Column("IDPERSONAJE")]
        public int IdPersonaje { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("IMAGEN")]
        public string Imagen { get; set; }

        [Column("SERIE")]
        public string Serie { get; set; }
    }
}
