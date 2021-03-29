using AutoMapper;
using GrupoOneParx.Business.Models;
using GrupoOneParx.WEB.ViewModel;

namespace GrupoOneParx.WEB.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Empresa, EmpresaViewModel>().ReverseMap();
        }
    }
}
