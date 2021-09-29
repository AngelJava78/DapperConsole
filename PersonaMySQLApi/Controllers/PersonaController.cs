using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaMySQLApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        readonly PersonaData data;
        public PersonaController()
        {
            data = new PersonaData();
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<Persona>();
            result = data.GetAll();
            if (!result.Any())
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(Persona persona)
        {
            var result = 0;
            result = data.Add(persona);
            return Ok(result);

        }

        [HttpPut]
        public IActionResult Edit(Persona persona)
        {
            var result = 0;
            result = data.Update(persona);
            return Ok(result);

        }

        [HttpDelete]
        public IActionResult Delete(Persona persona)
        {
            var result = 0;
            result = data.Delete(persona.Id);
            return Ok(result);
        }
    }
}
