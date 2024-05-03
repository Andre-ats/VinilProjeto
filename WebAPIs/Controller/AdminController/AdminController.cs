using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;
using VinilProjeto.UseCase.AdminUseCase.GetAdmin;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;
using VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;
using VinilProjeto.UseCase.VinilUseCase.GetVinilImagem;
using WebApi.Services;
using WebAPIs.DTO;
using WebAPIs.Service.LoginService;
using WebAPIs.Service.LoginServiceAdmin;

namespace WebAPIs.Controller.AdminController;


[ApiController]
[Route("[controller]/[action]")]
public class AdminController : ControllerBase
{
    private readonly ICadastrarAdminUseCase _cadastrarAdminUseCase;
    private readonly IGetAdminUseCase _getAdminUseCase;
    private readonly ICadastrarVinilUseCase _vinilUseCase;
    private readonly ILoginServiceAdmin _login;
    private readonly IGetUsuarioCompradorUseCase _getUsuarioCompradorUseCase;
    private readonly IGetAdminPerfilUseCase _getAdminPerfilUseCase;
    private readonly IPostImagemVinilUseCase _postImagemVinilUseCase;

    public AdminController(
            ICadastrarAdminUseCase cadastrarAdminUseCase, 
            IGetAdminUseCase GetAdminUseCase, 
            ICadastrarVinilUseCase cadastrarVinilUseCase, 
            ILoginServiceAdmin login, 
            IGetUsuarioCompradorUseCase getUsuarioCompradorUseCase, 
            IGetAdminPerfilUseCase getAdminPerfilUseCase,
            IPostImagemVinilUseCase postImagemVinilUseCase
            
        )
    {
        _cadastrarAdminUseCase = cadastrarAdminUseCase;
        _getAdminUseCase = GetAdminUseCase;
        _getUsuarioCompradorUseCase = getUsuarioCompradorUseCase;
        _vinilUseCase = cadastrarVinilUseCase;
        _login = login;
        _getAdminPerfilUseCase = getAdminPerfilUseCase;
        _postImagemVinilUseCase = postImagemVinilUseCase;
        
        
        
    }
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name="LoginAdmin")]
    public UsuarioLoginOutput loginAdmin([FromBody] UsuarioLoginInput input)
    {
        var admin = _login.login(input.email, input.senha);
        if (admin == null)
        {
            var resposta = $"Usuario nao encontrado {input.email}";
            throw new BadHttpRequestException(resposta, 401);
        }

        TokenGenerator gerar = new TokenGenerator();
        string token = gerar.generate(new UsuarioToken { email = input.email, senha = input.senha, role = "Admin", id = admin.id});
        DateTime dateTime = gerar.getExpiration();

        return new UsuarioLoginOutput(token, dateTime);
    }
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name="PostCadastrarAdmin")]
    public ICadastrarAdminUseCaseOutput postCadastrarAdmin([FromBody] ICadastrarAdminUseCaseInput input)
    {
        return _cadastrarAdminUseCase.executeUseCase(input);
    }
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostCadastrarVinil")]
    public ICadastrarVinilUseCaseOutput postCadastrarVinil([FromBody] ICadastrarVinilUseCaseInput input)
    {
        return _vinilUseCase.executeUseCase(input);
    }
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostImagemVinil")]
    public IPostImagemVinilUseCaseOutput postImagemVinil([FromForm] PostImagemAdaptor input)
    {
        IPostImagemVinilUseCaseInput inputPostImagem = new IPostImagemVinilUseCaseInput();
        
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json",optional:false,reloadOnChange:false).Build();
        var pathfolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
               configuration.GetValue<string>("System:UsersDocBasePath");
        
        MemoryStream memoryStream = new MemoryStream();
        input.file.OpenReadStream().CopyTo(memoryStream);
        
        inputPostImagem.vinilId = input.vinilID;
        inputPostImagem.nome = input.nome;
        inputPostImagem.Stream = memoryStream;
        memoryStream.Flush();
        memoryStream.Position = 0;
        inputPostImagem.path = pathfolder;

        return _postImagemVinilUseCase.executeUseCase(inputPostImagem);
    }
    
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "GetTodosAdmins")]
    public IGetAdminUseCaseOutput getTodosAdmins()
    {
        return _getAdminUseCase.executeUseCase(new IGetAdminUseCaseInput());
    }
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "GetTodosUsuarios")]
    public IGetUsuarioCompradorUseCaseOutput getTodosUsuarios()
    {
        return _getUsuarioCompradorUseCase.executeUseCase(new IGetUsuarioCompradorUseCaseInput());
    }
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "GetPerfilAdmin")]
    public IGetAdminPerfilUseCaseOutput getAdminPerfil()
    {
        return _getAdminPerfilUseCase.executeUseCase(new IGetAdminPerfilUseCaseInput(Guid.Parse(User.FindFirstValue("id"))));
    }
}