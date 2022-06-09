using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos.Funcionarios.Gerente;
using FilmesApi.Models.Funcionarios;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FilmesApi.Controllers.FuncionarioController
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult AdicionaGerente(CreateGerenteDTO dto)
        {
            Gerente gerente = _mapper.Map<Gerente>(dto);
            _context.Gerentes.Add(gerente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        public IActionResult RecuperaGerentesPorId(int id)     
        {
            Gerente gerente = _context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);
            if (gerente != null)
            {
                ReadGerenteDTO gerenteDto = _mapper.Map<ReadGerenteDTO>(gerente);
                return Ok(gerenteDto);
            }
            return NotFound();
        }
    }
}
