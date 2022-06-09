
using AutoMapper;
using EAPI.Data;
using EAPI.Data.DTOs;
using EAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostFilme([FromBody] CreateFilmeDTO filmeDto)
        {
            Filme filme = new Filme
            {
                Titulo = filmeDto.Titulo,
                Genero = filmeDto.Genero,
                Diretor = filmeDto.Diretor,
                Duracao = filmeDto.Duracao,
            };
          
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFilmeId), new { id = filme.Id }, filme);
                //aonde esse filme foi criado?
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilme()
        {

            return _context.Filmes;

        }

        // pra diferenciar do httpget sem argumento
        [HttpGet("{id}")]
        public IActionResult GetFilmeId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if(filme != null)
            {
                ReadFilmeDTO filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

                return Ok(filme);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AttFilme(int id, [FromBody] UpdateFilmeDTO filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if(filme == null)
            {
                return NotFound();
            }
            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();
            return NoContent();   
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null)
                return NotFound();

            _context.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
