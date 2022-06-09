using AutoMapper;
using EAPI.Data;
using EAPI.Data.DTOs.Enderecos;
using EAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EAPI.Controllers
{
    [ApiController]
    [Route("[controller")]
    public class EnderecoController : Controller
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostEndereco([FromBody] CreateEnderecoDTO EndDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(EndDto);

            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnderecoId), new { Id = endereco.Id }, endereco;
        }

        [HttpGet]
        public IEnumerable<Endereco> GetFilme()
        {

            return _context.Enderecos;

        }

        // pra diferenciar do httpget sem argumento
        [HttpGet("{id}")]
        public IActionResult GetEnderecoId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(end => end.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDTO filmeDto = _mapper.Map<ReadEnderecoDTO>(endereco);

                return Ok(endereco);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AttEndereco(int id, [FromBody] UpdateEnderecoDTO EndDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(end => end.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            _mapper.Map(EndDto, endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(end => end.Id == id);
            if (endereco == null)
                return NotFound();

            _context.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }



    }
}
