using FluentValidation;
using MeuLivroDeReceitas.Communication.Requests;
using MeuLivroDeReceitas.Exceptions;

namespace MeuLivroDeReceitas.Application.UseCases.Usuario.Registrar
{
    internal class RegistrarUsuarioValidator : AbstractValidator<RequestRegistrarUsuarioJson>
    {
        public RegistrarUsuarioValidator()
        {
            RuleFor(user => user.Nome)
                .NotEmpty().WithMessage(ResourceMessageException.NOME_VAZIO);

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage(ResourceMessageException.EMAIL_VAZIO)
                .EmailAddress().WithMessage(ResourceMessageException.EMAIL_INCORRETO);

            RuleFor(user => user.Senha.Length)
                .NotEmpty().WithMessage(ResourceMessageException.SENHA_VAZIA)
                .GreaterThanOrEqualTo(6).WithMessage(ResourceMessageException.SENHA_INVALIDA);

        }
    }
}
