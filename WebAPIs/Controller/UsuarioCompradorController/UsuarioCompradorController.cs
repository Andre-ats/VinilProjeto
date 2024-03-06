using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;
using VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;
using WebApi.Services;
using WebAPIs.DTO;
using WebAPIs.Service.LoginService;
using WebAPIs.Service.LoginServiceUsuarioComprador;

namespace WebAPIs.Controller.UsuarioCompradorController;

[ApiController]
[Route("[controller]/[action]")]
public class UsuarioCompradorController
{
    private readonly ICadastrarUsuarioCompradorUseCase _cadastrarUsuarioCompradorUseCase;
    private readonly IGetTodosVinilUseCase _getTodosVinilUseCase;
    private readonly ILoginServiceUsuarioComprador _serviceUsuarioComprador;

    public UsuarioCompradorController(ICadastrarUsuarioCompradorUseCase usuarioCompradorUseCase, IGetTodosVinilUseCase getTodosVinilUseCase, ILoginServiceUsuarioComprador usuarioCompradorLogin)
    {
        _cadastrarUsuarioCompradorUseCase = usuarioCompradorUseCase;
        _getTodosVinilUseCase = getTodosVinilUseCase;
        _serviceUsuarioComprador = usuarioCompradorLogin;
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name="Login/UsuarioComprador")]
    public UsuarioLoginOutput loginUsuarioComprador([FromBody] UsuarioLoginInput input)
    {
        var usuarioComprador = _serviceUsuarioComprador.login(input.email, input.senha);
        if (usuarioComprador == null)
        {
            var resposta = $"Usuario nao encontrado {input.email}";
            throw new BadHttpRequestException(resposta, 401);
        }

        if (usuarioComprador.status != StatusUsuarioComprador.Ativo)
        {
            throw new Exception("Usuario inativo");
        }

        TokenGenerator gerar = new TokenGenerator();
        string token = gerar.generate(new UsuarioToken() { email = input.email, senha = input.senha, role = "UsuarioComprador", id = usuarioComprador.id});
        DateTime dateTime = gerar.getExpiration();

        return new UsuarioLoginOutput(token, dateTime);
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