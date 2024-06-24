using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetPerfilUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarDesativarStatusUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarStatusUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarTelefone;
using VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;
using WebApi.Services;
using WebAPIs.DTO;
using WebAPIs.Service.LoginService;
using WebAPIs.Service.LoginServiceUsuarioComprador;
using Microsoft.Extensions.Caching.Memory;
using VinilProjeto.Helpers.Email;
using VinilProjeto.Helpers.Hash;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.AtivarContaUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.MandarEmailPergunta;

namespace WebAPIs.Controller.UsuarioCompradorController;

[ApiController]
[Route("[controller]/[action]")]
public class UsuarioCompradorController : ControllerBase
{
    private readonly ICadastrarUsuarioCompradorUseCase _cadastrarUsuarioCompradorUseCase;
    private readonly ILoginServiceUsuarioComprador _serviceUsuarioComprador;
    private readonly IPutUsuarioCompradorTelefoneUseCase _putUsuarioCompradorTelefoneUseCase;
    private readonly IGetPerfilUsuarioCompradorUseCase _getPerfilUsuarioCompradorUseCase;
    private readonly IPutUsuarioCompradorAtivarStatusUseCase _putUsuarioCompradorAtivarStatusUseCase;
    private readonly IPutUsuarioCompradorDesativarStatusUseCase _putUsuarioCompradorDesativarStatusUseCase;
    private readonly IAtivarUsuarioCompradorUseCase _ativarUsuarioCompradorUseCase;
    private readonly IMandarEmailPerguntaUseCase _mandarEmailPerguntaUseCase;
    
    private readonly IMemoryCache _memoryCache;

    public UsuarioCompradorController(ICadastrarUsuarioCompradorUseCase usuarioCompradorUseCase, 
        ILoginServiceUsuarioComprador usuarioCompradorLogin,
        IPutUsuarioCompradorTelefoneUseCase _putUsuarioCompradorTelefoneUseCase,
        IGetPerfilUsuarioCompradorUseCase _getPerfilUsuarioCompradorUseCase,
        IPutUsuarioCompradorAtivarStatusUseCase _putUsuarioCompradorAtivarStatusUseCase,
        IPutUsuarioCompradorDesativarStatusUseCase _putUsuarioCompradorDesativarStatusUseCase,
        IAtivarUsuarioCompradorUseCase _ativarUsuarioCompradorUseCase,
        IMandarEmailPerguntaUseCase _mandarEmailPerguntaUseCase,
        
        IMemoryCache memoryCache
        )
    {
        _cadastrarUsuarioCompradorUseCase = usuarioCompradorUseCase;
        _serviceUsuarioComprador = usuarioCompradorLogin;
        this._putUsuarioCompradorTelefoneUseCase = _putUsuarioCompradorTelefoneUseCase;
        this._getPerfilUsuarioCompradorUseCase = _getPerfilUsuarioCompradorUseCase;
        this._putUsuarioCompradorAtivarStatusUseCase = _putUsuarioCompradorAtivarStatusUseCase;
        this._putUsuarioCompradorDesativarStatusUseCase = _putUsuarioCompradorDesativarStatusUseCase;
        this._ativarUsuarioCompradorUseCase = _ativarUsuarioCompradorUseCase;
        this._mandarEmailPerguntaUseCase = _mandarEmailPerguntaUseCase;
        
        this._memoryCache = memoryCache;
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name="Login/UsuarioComprador")]
    public UsuarioLoginOutput loginUsuarioComprador([FromBody] UsuarioLoginInput input)
    {
        
        
        var hash = Hash256.stringHash256(input.senha);
        
        var usuarioComprador = _serviceUsuarioComprador.login(input.email, hash);
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
        string token = gerar.generate(new UsuarioToken() { email = input.email, senha = hash, role = "UsuarioComprador", id = usuarioComprador.id});
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
        new EmailVerificacao(_memoryCache).emailToken(input.email);
        return _cadastrarUsuarioCompradorUseCase.executeUseCase(input);
    }
    
    
    [Authorize(Roles = "UsuarioComprador")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostMandarEmailPergunta")]
    public IMandarEmailPerguntaUseCaseOutput postEmailDuvida([FromBody] IMandarEmailPerguntaUseCaseInput input)
    {
        input.setUsuarioId((Guid.Parse(User.FindFirstValue("id"))));
        return _mandarEmailPerguntaUseCase.executeUseCase(input);
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostTokenVerificacao")]
    public IAtivarUsuarioCompradorUseCaseOutput verificarEmailToken([FromBody] IAtivarUsuarioCompradorUseCaseInput input)
    {
        var retorno = new EmailVerificacao(_memoryCache).verificarToken(input.email, input.codigo);
        
        if (retorno)
        {
            return _ativarUsuarioCompradorUseCase.executeUseCase(input); 
        }
        else
        {
            throw new Exception("" + retorno);
        }
    }

    [Authorize(Roles = "UsuarioComprador")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "getUsuarioCompradorPerfil")]
    public IGetPerfilUsuarioCompradorUseCaseOutput getUsuarioCompradorPerfil()
    {
        return _getPerfilUsuarioCompradorUseCase.executeUseCase(new IGetPerfilUsuarioCompradorUseCaseInput(Guid.Parse(User.FindFirstValue("id"))));
    }
    
    [Authorize(Roles = "UsuarioComprador")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPut(Name = "putTelefone")]
    public IPutUsuarioCompradorTelefoneUseCaseOutput putTelefone([FromBody] IPutUsuarioCompradorTelefoneUseCaseInput input)
    {
        input.setUsuarioId((Guid.Parse(User.FindFirstValue("id"))));
        return _putUsuarioCompradorTelefoneUseCase.executeUseCase(input);
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPut(Name = "putStatusAtivarUsuarioComprador")]
    public IPutUsuarioCompradorAtivarStatusUseCaseOutput putStatusAtivarUsuarioComprador([FromBody] IPutUsuarioCompradorAtivarStatusUseCaseInput useCaseInput)
    {
        return _putUsuarioCompradorAtivarStatusUseCase.executeUseCase(useCaseInput);
    }
    [Authorize(Roles = "UsuarioComprador")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPut(Name = "putStatusDesativarUsuarioComprador")]
    public IPutUsuarioCompradorDesativarStatusUseCaseOutput putStatusDesativarUsuarioComprador([FromBody] IPutUsuarioCompradorDesativarStatusUseCaseInput useCaseInput)
    {
        useCaseInput.setUsuarioId((Guid.Parse(User.FindFirstValue("id"))));
        return _putUsuarioCompradorDesativarStatusUseCase.executeUseCase(useCaseInput);
    }
    
}