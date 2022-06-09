using AutoMapper;
using EAPI.Data;
using EAPI.Models;
using EAPI.Controllers;
using EAPI.Data.DTOs.Filmes;

namespace EAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, Filme>();

        }
    }
}
