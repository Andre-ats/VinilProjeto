using Microsoft.AspNetCore.Mvc;
using VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;

namespace WebAPIs.Controller.AdminController;


[ApiController]
[Route("[controller]/[action]")]
public class AdminController
{
    private readonly ICadastrarAdminUseCase _cadastrarAdminUseCase;

    public AdminController(ICadastrarAdminUseCase cadastrarAdminUseCase)
    {
        _cadastrarAdminUseCase = cadastrarAdminUseCase;
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
    
}