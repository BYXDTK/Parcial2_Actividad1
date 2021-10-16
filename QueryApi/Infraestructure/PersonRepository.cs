using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using QueryApi.Domain;
using System.Threading.Tasks;

namespace QueryApi.Repositories
{
    public class PersonRepository
    {
        List<Person> _persons;

        public PersonRepository()
        {
            var fileName = "dummy.data.queries.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _persons = JsonSerializer.Deserialize<IEnumerable<Person>>(json).ToList();
            }
        }

        public IEnumerable<Person> TDatos ()
        {
            return _persons;
        }

        //TD = Todos los datos
        //Escribe un método en el cual se retorne la información de todas las personas.

        public IEnumerable<Object> OCampos ()
        {
            var query = _persons.Select(person => new {

                NombreC = $"{person.FirstName} {person.LastName}",
                AnioN = DateTime.Now.AddYears(person.Age * -1).Year,
                Email = person.Email 
            });
            
            return query;
        }

        //OCampos = Obtener Campos
        //Escribe un método en el cual se retorne únicamente el nombre completo de las personas, el correo y el año de nacimiento.

        public IEnumerable<Person> OGeneros (char Gen)
        {
            var query = _persons.Where(person => person.Gender == Gen);
            return query;
        }

        //OGeneros = Obtener Generos
        //Escribe un método que retorne la información de todas las personas cuyo genero sea Femenino.
        
        public IEnumerable<Person> ORangoE (int minAge, int maxAge)
        {
            var query = _persons.Where(person => person.Age > minAge && person.Age < maxAge);
            return query;
        }
        //ORangoE = Obtener Rango Edad
        //Escribe un método que retorne la información de todas las personas cuya edad se encuentre entre los 20 y 30 años.

        public IEnumerable<string> OTrabajo()
        {
            var query = _persons.Select(person => person.Job).Distinct();
            return query;
        } 

        //OTra = Obtener Trabajo 
        //Escribe un método que retorne la información de los diferentes trabajos que tienen las personas.
        
        public IEnumerable<Person> OContenido (string PNombre)
        {
            var query = _persons.Where(person => person.FirstName.Contains(PNombre));
            return query;
        }
        // OCon = Obtener Contenido
        // PNombre = Parte de nombre A/R
        //Escribe un método que retorne la información de las personas cuyo nombre contenga la palabra “ar”
        public IEnumerable<Person> OEdades (int anio1, int anio2, int anio3)
        {
            var anios = new List<int>{anio1,anio2,anio3};
            var query = _persons.Where(person => anios.Contains(person.Age));
            return query;
        }

        // OEdades = Obtener por edades
        //Escribe un método que retorna la información de las personas cuyas edades sean 25, 35 y 45 años
        
        public IEnumerable<Person> OPersonasO (int age)
        {
            var query = _persons.Where(person => person.Age > age).OrderBy(person => person.Age);
            return query;
        }
        // OPersonasO = Obtener Personas Ordenadas
        //Escribe un método que retorne la información ordenas por edad para las personas que sean mayores a 40 años

        public IEnumerable<Person> OREdadGenero (int minAge, int maxAge, char Gen)
        {
            var query = _persons.Where(person => person.Age > minAge && person.Age < maxAge &&  person.Gender ==  Gen).OrderByDescending(person =>  person.Gender);
            return query;
        }

        // OREdad = Obtener Rango por Edad y Genero
        //Escribe un método que retorne la información ordenada de manera descendente para todas las personas de género masculino y que se encuentren entre los 20 y 30 años de edad
        
        public IEnumerable<Person> CGenero (char Gen)
        {
            var query = _persons.Where(person => person.Gender == Gen);
            return query;
        }

        // CGenero = ContarGenero
        //Escribe un método que retorne la cantidad de personas con género femenino.

        public bool PEApellido (string lastName)
        {
            var query = _persons.Any(p => p.LastName == lastName);

            return query;
        }
        //PEApellido = PersonaExistenteApellido
        //Escribe un método que retorna si existen personas con el apellido “Shemelt”.

        public IEnumerable<Person> OTPersonaEdad (string job, int age)
        {
            var query = _persons.Where(person => person.Job == job && person.Age == age);
            return query;
        }

        // OTP = Obtener Trabajo De Una Persona Y Su Edad
        //Escribe un método que retorne únicamente una persona cuyo trabajo sea “Software Consultant” y tenga 25 años de edad
        
        public IEnumerable<Person> TPersonas (string job, int take)
        {
            var query = _persons.Where(person => person.Job == job).Take(take);
            return query;
        }
        //Tp = Tomar Persona
        //Escribe un método que retorne la información de las primeras 3 personas cuyo puesto de trabajo sea “Software Consultant”

        public IEnumerable<Person> TUltimasPersonas (string job, int takeLast)
        {

            var query = _persons.Where(person => person.Job == job).TakeLast(takeLast);
            return query;
        }

        // Tul = Tomas las ultimas persona.
        //Escribe un método que omita la información de las primeras 3 personas cuyo puesto de trabajo sea “Software Consultant”

        public IEnumerable<Person> STPersona(string job, int skip, int take)
        {
            var query = _persons.Where(person => person.Job == job).Skip(skip).Take(take);
            return query;
        }
        //STP = Saltar y tomar persona.
        //Escribe un método que omita la información de las primeras 3 personas y que retorne la información de las siguientes 3 personas cuyo puesto de trabajo sea “Software Consultant”
    }
}

/*
 * Universidad Tecnologica Metropolitana
Mat: Aplicaciones Web Orientadas a Objetos
Mae: Chuc Uc Joel Ivan
Actividad: 1
Alu: Joatan de Jesus Lopez Canul
4-B
Parcial 2
*/