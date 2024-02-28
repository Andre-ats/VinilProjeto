using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;
using VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;

namespace WebAPIs.Controller.UsuarioCompradorController;

[ApiController]
[Route("[controller]/[action]")]
public class UsuarioCompradorController
{
    private readonly ICadastrarUsuarioCompradorUseCase _cadastrarUsuarioCompradorUseCase;
    private readonly IGetTodosVinilUseCase _getTodosVinilUseCase;

    public UsuarioCompradorController(ICadastrarUsuarioCompradorUseCase usuarioCompradorUseCase, IGetTodosVinilUseCase getTodosVinilUseCase)
    {
        _cadastrarUsuarioCompradorUseCase = usuarioCompradorUseCase;
        _getTodosVinilUseCase = getTodosVinilUseCase;
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostCadastrarUsuarioComprador")]

    public ICadastrarUsuarioCompradorUseCaseOutput postCadastrarUsuarioComprador([FromBody] ICadastrarUsuarioCompradorUseCaseInput input)
    {
        return _cadastrarUsuarioCompradorUseCase.executeUseCase(input);
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "GetTodosVinil")]

    public IGetTodosVinilUseCaseOutput getTodosVinil()
    {
        return _getTodosVinilUseCase.executeUseCase(new IGetTodosVinilUseCaseInput());
    }
}