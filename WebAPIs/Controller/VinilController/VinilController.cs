using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;
using VinilProjeto.UseCase.VinilUseCase.DeleteImagem;
using VinilProjeto.UseCase.VinilUseCase.DeleteVinil;
using VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;
using WebAPIs.DTO;
using WebAPIs.Service.GoogleCloudStorageService;

namespace WebAPIs.Controller.VinilController;

[ApiController]
[Route("[controller]/[action]")]
public class VinilController : ControllerBase
{
    private readonly GCSConfigOptions _options;
    private readonly GoogleCredential _googleCredential;
    private readonly IPostImagemVinilUseCase _postImagemVinilUseCase;
    private readonly IDeleteImagemVinilUseCase _deleteImagemVinilUseCase;
    private readonly ICadastrarVinilUseCase _vinilUseCase;
    private readonly IGetTodosVinilUseCase _getTodosVinil;
    private readonly IDeleteVinilUseCase _deleteVinilUseCase;

    
    public VinilController(IOptions<GCSConfigOptions> options, 
        IPostImagemVinilUseCase postImagemVinilUseCase, 
        IDeleteImagemVinilUseCase deleteImagemVinilUseCase,
        ICadastrarVinilUseCase cadastrarVinilUseCase,
        IGetTodosVinilUseCase getTodosVinilUseCase,
        IDeleteVinilUseCase deleteVinilUseCase
    )
    {
        
        _options = options.Value;
        _postImagemVinilUseCase = postImagemVinilUseCase;
        _deleteImagemVinilUseCase = deleteImagemVinilUseCase;
        _vinilUseCase = cadastrarVinilUseCase;
        _getTodosVinil = getTodosVinilUseCase;
        _deleteVinilUseCase = deleteVinilUseCase;
        
        try
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment == Environments.Production)
            {
                _googleCredential = GoogleCredential.FromJson(_options.GCPStorageAuthFile);
            }
            else
            {
                _googleCredential = GoogleCredential.FromFile(_options.GCPStorageAuthFile);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(200)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpPost(Name = "PostImagemVinil")]
    public async Task<IPostImagemVinilUseCaseOutput> UploadFileAsync([FromForm]PostImagemAdaptor input)
    {
        try
        {
            using (var memoryStream = new MemoryStream())
            {
                input.file.OpenReadStream().CopyTo(memoryStream);
                
                IPostImagemVinilUseCaseInput inputPostImagem = new IPostImagemVinilUseCaseInput();
                {
                    inputPostImagem.vinilId = input.vinilID;
                    inputPostImagem.nome = input.file.FileName;
                    inputPostImagem.Stream = memoryStream;
                    inputPostImagem.path = "https://storage.googleapis.com/sg-discos/" + input.file.FileName;
                }
                
                using (var storageClient = StorageClient.Create(_googleCredential))
                {
                    var uploadedFile = await storageClient.UploadObjectAsync(
                        _options.GoogleCloudStorageBucketName, 
                        input.file.FileName, 
                        input.file.ContentType, 
                        memoryStream
                    );
                    memoryStream.Flush();
                    memoryStream.Position = 0;

                }
                
                return _postImagemVinilUseCase.executeUseCase(inputPostImagem);
                
            }
        }
        catch (Exception ex)
        {
            throw;
        }
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
    [HttpDelete(Name = "DeleteVinil")]
    public async Task<IDeleteVinilUseCaseOutput> deleteVinil([FromBody] IDeleteVinilUseCaseInput input)
    {
        try
        {
            using (var storageClient = StorageClient.Create(_googleCredential))
            {
                foreach (var imagem in input.fileName)
                {
                    await storageClient.DeleteObjectAsync(_options.GoogleCloudStorageBucketName, imagem);
                }
            }
            
            return _deleteVinilUseCase.executeUseCase(input);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    [AllowAnonymous]
    [ProducesResponseType(201)]
    [ProducesResponseType(401)]
    [ProducesResponseType(400)]
    [Produces("application/json")]
    [HttpGet(Name = "GetTodosVinil")]
    public IGetTodosVinilUseCaseOutput getTodosVinil()
    {
        return _getTodosVinil.executeUseCase(new IGetTodosVinilUseCaseInput());
    }
    
}