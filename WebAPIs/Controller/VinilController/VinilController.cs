using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;
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

    
    public VinilController(IOptions<GCSConfigOptions> options, IPostImagemVinilUseCase postImagemVinilUseCase)
    {
        
        _options = options.Value;
        _postImagemVinilUseCase = postImagemVinilUseCase;
        
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
    [HttpPost(Name = "postImagemGoogleStorage")]
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
                    
                    return _postImagemVinilUseCase.executeUseCase(inputPostImagem);
                    
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}