using AutoMapper;
using EAPI.Data;
using EAPI.Data.DTOs;
using EAPI.Models;
using EAPI.Controllers;

namespace EAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, FilmeProfile>();
            CreateMap<Filme, ReadFilmeDTO>();
            CreateMap<UpdateFilmeDTO, Filme>();

        }
    }
}
