using MeuLivroDeReceitas.Application.UseCases.Usuario.Registrar;
using MeuLivroDeReceitas.Communication.Requests;
using MeuLivroDeReceitas.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace MeuLivroDeReceitas.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegistrarUsuarioJson) ,StatusCodes.Status201Created)]
        public IActionResult Registrar(RequestRegistrarUsuarioJson request)
        {
            var useCase = new RegistrarUsuarioUseCase();

            var result = useCase.Execute(request);

            return Created(string.Empty, result);
        }
    }
}
