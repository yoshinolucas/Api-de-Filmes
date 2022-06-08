
using EAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        [HttpPost]
        public IActionResult PostFilme([FromBody] Filme filme)
        {
           
            return CreatedAtAction(nameof(GetFilmeId), new { id = filme.Id }, filme);
                //aonde esse filme foi criado?
        }

        [HttpGet]
        public IActionResult GetFilme()
        {
            return Ok();

        }

        // pra diferenciar do httpget sem argumento
        [HttpGet("{id}")]
        public IActionResult GetFilmeId(int id)
        {
            Filme filme = .FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                return Ok(filme);
            }
            return NotFound();
        }
    }
}
