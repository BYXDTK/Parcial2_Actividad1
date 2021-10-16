using System.Collections;
using Microsoft.AspNetCore.Mvc;
using QueryApi.Repositories;
using QueryApi.Domain;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        [Route("Traer_Datos")]
        public IActionResult Traer_Datos ()
        {
            var repository = new PersonRepository();
            var persons = repository.TDatos();
            return Ok(persons);
        } 
        [HttpGet]
        [Route("Elecciones")]
        public IActionResult Elecciones ()
        {
            var repository = new PersonRepository();
            var persons = repository.OCampos();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Genero_Buscar")]
        public IActionResult Genero_Buscar (char Gen)
        {
            var repository = new PersonRepository();
            var persons = repository.OGeneros(Gen);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Rango_De_Edad")]
        public IActionResult Rango_De_Edad (int minAge, int maxAge)
        {
            var repository = new PersonRepository();
            var persons = repository.ORangoE(minAge, maxAge);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Trabajos_Disponibles")]
        public IActionResult Trabajos_Disponibles ()
        {
            var repository = new PersonRepository();
            var persons = repository.OTrabajo();
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Contenido_Obtenido")]
        public IActionResult Contenido_Obtenido (string PNombre)
        {
            var repository = new PersonRepository();
            var persons = repository.OContenido(PNombre);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Edades_Obtenidas")]
        public IActionResult Edades_Obtenidas (int anio1, int anio2, int anio3)
        {
            var repository = new PersonRepository();
            var persons = repository.OEdades(anio1, anio2, anio3);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Personas_Ordenadadas_Obtenidas")]
        public IActionResult Personas_Ordenadadas_Obtenidas (int anio)
        {
            var repository = new PersonRepository();
            var persons = repository.OPersonasO(anio);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Rango_Por_Edad_Y_Genero_Buscar")]
        public IActionResult Rango_Por_Edad_Y_Genero_Buscar (int minAge, int maxAge, char Gen)
        {
            var repository = new PersonRepository();
            var persons = repository.OREdadGenero(minAge, maxAge, Gen);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Genero_Contar")]
        public IActionResult Genero_Contar (char Gen)
        {
            var repository = new PersonRepository();
            var persons = repository.CGenero(Gen);
            return Ok(persons);
        }

            [HttpGet]
        [Route("Existente_Apellido_Persona")]
        public IActionResult Existente_Apellido_Persona (string lastName)
        {
            var repository = new PersonRepository();
            var persons = repository.PEApellido(lastName);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Trabajo_Persona_Edad_Obtener")]
        public IActionResult Trabajo_Persona_Edad_Obtener (string job, int age)
        {
            var repository = new PersonRepository();
            var persons = repository.OTPersonaEdad(job, age);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Persona_Tomar")]
        public IActionResult Persona_Tomar (string job, int take)
        {
            var repository = new PersonRepository();
            var persons = repository.TPersonas(job, take);
            return Ok(persons);
        }

        [HttpGet]
        [Route("Ultimas_Personas_Tomar")]
        public IActionResult Ultimas_Personas_Tomar (string job, int takeLast)
        {
            var repository = new PersonRepository();
            var persons = repository.TUltimasPersonas(job, takeLast);
            return Ok(persons);
        } 

        [HttpGet]
        [Route("Saltar_Tomar_Persona")]
        public IActionResult Saltar_Tomar_Persona (string job, int skip, int take)
        {
            var repository = new PersonRepository();
            var persons = repository.STPersona(job, skip, take);
            return Ok(persons);
        }

    }

}