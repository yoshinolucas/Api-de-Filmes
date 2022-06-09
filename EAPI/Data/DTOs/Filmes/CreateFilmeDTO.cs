using System.ComponentModel.DataAnnotations;
using AutoMapper;
using System;
using EAPI.Models;
using EAPI.Controllers;

namespace EAPI.Data.DTOs.Filmes
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(30, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Titulo { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "O campo deve ser obrigatório")]
        public string Diretor { get; set; }
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ser de 1 a 600")]
        public int Duracao { get; set; }
    }
}
