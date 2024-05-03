using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.Entity.VinilVenda;
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

namespace WebAPIs.Controller.UsuarioCompradorController;

[ApiController]
[Route("[controller]/[action]")]
public class UsuarioCompradorController : ControllerBase
{
    private readonly ICadastrarUsuarioCompradorUseCase _cadastrarUsuarioCompradorUseCase;
    private readonly IGetTodosVinilUseCase _getTodosVinilUseCase;
    private readonly ILoginServiceUsuarioComprador _serviceUsuarioComprador;
    private readonly IPutUsuarioCompradorTelefoneUseCase _putUsuarioCompradorTelefoneUseCase;
    private readonly IGetPerfilUsuarioCompradorUseCase _getPerfilUsuarioCompradorUseCase;
    private readonly IPutUsuarioCompradorAtivarStatusUseCase _putUsuarioCompradorAtivarStatusUseCase;
    private readonly IPutUsuarioCompradorDesativarStatusUseCase _putUsuarioCompradorDesativarStatusUseCase;

    public UsuarioCompradorController(ICadastrarUsuarioCompradorUseCase usuarioCompradorUseCase, 
        IGetTodosVinilUseCase getTodosVinilUseCase, 
        ILoginServiceUsuarioComprador usuarioCompradorLogin,
        IPutUsuarioCompradorTelefoneUseCase _putUsuarioCompradorTelefoneUseCase,
        IGetPerfilUsuarioCompradorUseCase _getPerfilUsuarioCompradorUseCase,
        IPutUsuarioCompradorAtivarStatusUseCase _putUsuarioCompradorAtivarStatusUseCase,
        IPutUsuarioCompradorDesativarStatusUseCase _putUsuarioCompradorDesativarStatusUseCase
        )
    {
        _cadastrarUsuarioCompradorUseCase = usuarioCompradorUseCase;
        _getTodosVinilUseCase = getTodosVinilUseCase;
        _serviceUsuarioComprador = usuarioCompradorLogin;
        this._putUsuarioCompradorTelefoneUseCase = _putUsuarioCompradorTelefoneUseCase;
        this._getPerfilUsuarioCompradorUseCase = _getPerfilUsuarioCompradorUseCase;
        this._putUsuarioCompradorAtivarStatusUseCase = _putUsuarioCompradorAtivarStatusUseCase;
        this._putUsuarioCompradorDesativarStatusUseCase = _putUsuarioCompradorDesativarStatusUseCase;

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
    
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "getImagemVinil")]
    public string getImagemVinil([FromQuery] Guid vinilId)
    {
        
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json",optional:false,reloadOnChange:false).Build();
        var pathfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                         configuration.GetValue<string>("System:UsersDocBasePath");

        return $"{pathfolder}/vinil/{vinilId}";

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