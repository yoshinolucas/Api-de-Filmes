using AutoMapper;
using FilmesApi.Data.Dtos.Funcionarios.Gerente;
using FilmesApi.Models.Funcionarios;

namespace FilmesApi.Profiles.FuncionarioProfile
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<GerenteProfile, ReadGerenteDTO>();
        }
    }
}
