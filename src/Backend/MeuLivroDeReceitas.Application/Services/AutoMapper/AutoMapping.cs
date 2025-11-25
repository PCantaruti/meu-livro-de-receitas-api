
using System.Runtime.InteropServices.Marshalling;
using AutoMapper;
using MeuLivroDeReceitas.Communication.Requests;

namespace MeuLivroDeReceitas.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            // de onde esta vindo, qual a classe que vai receber a informação
            CreateMap<RequestRegistrarUsuarioJson, Domain.Entities.Usuario>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore()); // mapeamento personalizado
        }

        //private void DomainToResponse()
        //{ }
    }
}
