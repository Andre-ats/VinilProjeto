using Microsoft.AspNetCore.Mvc;
using VinilProjeto.Entity.Usuario;
using VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;
using VinilProjeto.UseCase.AdminUseCase.GetAdmin;

namespace WebAPIs.Controller.AdminController;


[ApiController]
[Route("[controller]/[action]")]
public class AdminController
{
    private readonly ICadastrarAdminUseCase _cadastrarAdminUseCase;
    private readonly IGetAdminUseCase _getAdminUseCase;

    public AdminController(ICadastrarAdminUseCase cadastrarAdminUseCase, IGetAdminUseCase GetAdminUseCase)
    {
        _cadastrarAdminUseCase = cadastrarAdminUseCase;
        _getAdminUseCase = GetAdminUseCase;
    }
    
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name="PostCadastrarAdmin")]
    public ICadastrarAdminUseCaseOutput postCadastrarAdmin([FromBody] ICadastrarAdminUseCaseInput input)
    {
        return _cadastrarAdminUseCase.executeUseCase(input);
    }

    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "GetTodosAdmins")]
    public IGetAdminUseCaseOutput getTodosAdmins()
    {
        return _getAdminUseCase.executeUseCase(new IGetAdminUseCaseInput());
    }
    
}