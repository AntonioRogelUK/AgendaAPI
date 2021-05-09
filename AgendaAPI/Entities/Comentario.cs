using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAPI.Entities
{
    public class Comentario
    {
        [Key]
        public int ComentarioId { get; set; }

        [Required, Column(TypeName = "varchar(max)")]
        public string Mensaje { get; set; }



        //Relacionar....
        //Llave foranea
        public int ContactoId { get; set; }
        //Navegacion
        public Contacto Contacto { get; set; }
    }
}
