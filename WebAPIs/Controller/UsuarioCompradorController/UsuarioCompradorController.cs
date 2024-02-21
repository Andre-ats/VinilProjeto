using Microsoft.AspNetCore.Mvc;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;

namespace WebAPIs.Controller.UsuarioCompradorController;

[ApiController]
[Route("[controller]/[action]")]
public class UsuarioCompradorController
{
    private readonly ICadastrarUsuarioCompradorUseCase _cadastrarUsuarioCompradorUseCase;

    public UsuarioCompradorController(ICadastrarUsuarioCompradorUseCase usuarioCompradorUseCase)
    {
        _cadastrarUsuarioCompradorUseCase = usuarioCompradorUseCase;
    }

    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostCadastrarUsuarioComprador")]

    public ICadastrarUsuarioCompradorUseCaseOutput postCadastrarUsuarioComprador([FromBody] ICadastrarUsuarioCompradorUseCaseInput input)
    {
        return _cadastrarUsuarioCompradorUseCase.executeUseCase(input);
    }
}