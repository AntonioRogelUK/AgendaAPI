using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAPI.Entities
{
    public class Contacto
    {
        [Key] 
        public int ContactoId { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime? FechaCaptura { get; set; }
       
        [Required, StringLength(maximumLength:250), Column(TypeName = "varchar(250)")]
        public string Nombre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }
        
        [Required, EmailAddress, StringLength(maximumLength: 250), Column(TypeName = "varchar(250)")]
        public string Email { get; set; }
        
        [StringLength(maximumLength: 20), Column(TypeName = "varchar(20)")]
        public string TelefonoParticular { get; set; }
       
        [StringLength(maximumLength: 20), Column(TypeName = "varchar(20)")]
        public string TelefonoCelular { get; set; }

        public bool? Activo { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }

    public class ContactoEntityTypeConfiguration : IEntityTypeConfiguration<Contacto>
    {
        public void Configure(EntityTypeBuilder<Contacto> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
        }
    }
}
