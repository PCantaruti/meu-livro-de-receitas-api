
using MeuLivroDeReceitas.Application.Services.AutoMapper;
using MeuLivroDeReceitas.Communication.Requests;
using MeuLivroDeReceitas.Communication.Responses;
using MeuLivroDeReceitas.Exceptions.ExceptionBase;

namespace MeuLivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    public class RegistrarUsuarioUseCase
    {
        public ResponseRegistrarUsuarioJson Execute(RequestRegistrarUsuarioJson request)
        {
            //1. validar request
            Validate(request);

            //2. Mapear request para entidade
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            var user = autoMapper.Map<Domain.Entities.Usuario>(request);

            //3. Criptografar senha

            //4. Persistir entidade no banco de dados

            return new ResponseRegistrarUsuarioJson
            {
                Nome = request.Nome
            };
        }


        private void Validate(RequestRegistrarUsuarioJson request)
        {

            var validator = new RegistrarUsuarioValidator();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);

            }
        }
    }

}
