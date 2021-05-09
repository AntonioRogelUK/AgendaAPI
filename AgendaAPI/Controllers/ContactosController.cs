using AgendaAPI.Context;
using AgendaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly AgendaDbContext agendaDbContext;

        public ContactosController(AgendaDbContext agendaDbContext)
        {
            this.agendaDbContext = agendaDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contacto>>> Get() 
        {
            return await agendaDbContext.Contactos
                .Include(c => c.Comentarios)
                .ToListAsync();
        }

        [HttpGet("{contactoId:int}")]
        public async Task<ActionResult<Contacto>> Get(int contactoId)
        {
            return await agendaDbContext.Contactos
                .Include(c => c.Comentarios)
                .FirstOrDefaultAsync(x => x.ContactoId == contactoId);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Contacto contacto) 
        {
            contacto.FechaCaptura = DateTime.Now;
            agendaDbContext.Add(contacto);
            await agendaDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("eliminar/{contactoId:int}")]
        public async Task<ActionResult> Delete(int contactoId) 
        {
            var contactoDb = await agendaDbContext.Contactos
                .FirstOrDefaultAsync(x => x.ContactoId == contactoId);
            
            if (contactoDb == null) 
            {
                return NotFound();
            }

            agendaDbContext.Remove(contactoDb);
            await agendaDbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("actualizar/{contactoId:int}")]
        public async Task<ActionResult> Put(int contactoId, [FromBody] Contacto contacto) 
        {
            var contactoDb = await agendaDbContext.Contactos
                .FirstOrDefaultAsync(x => x.ContactoId == contactoId);

            if (contactoDb == null)
            {
                return NotFound();
            }

            contactoDb.Nombre = contacto.Nombre;
            contactoDb.Email = contacto.Email;

            if (contacto.FechaNacimiento != null) { contactoDb.FechaNacimiento = contacto.FechaNacimiento; }
            if (contacto.TelefonoParticular != null) { contactoDb.TelefonoParticular = contacto.TelefonoParticular; }
            if (contacto.TelefonoCelular != null) { contactoDb.TelefonoCelular = contacto.TelefonoCelular; }
            if (contacto.Activo != null) { contactoDb.Activo = contacto.Activo; }

            agendaDbContext.Entry(contactoDb).State = EntityState.Modified;
            await agendaDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
