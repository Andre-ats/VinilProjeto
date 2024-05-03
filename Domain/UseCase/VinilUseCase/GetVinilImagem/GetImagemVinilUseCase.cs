using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.Service.FileService;

namespace VinilProjeto.UseCase.VinilUseCase.GetVinilImagem;

public class GetImagemVinilUseCase : IGetImagemVinilUseCase
{
    public GetImagemVinilUseCase(IVinilRespository _vinilRespository) : base(_vinilRespository)
    {
    }

    protected override IGetImagemVinilUseCaseOutput executeService(IGetImagemVinilUseCaseInput _useCaseInput)
    {
        try
        {

            var stream =
                new FileService().loadDocContent(
                    $"{_useCaseInput.path}/vinil/{_useCaseInput.vinilId}/{_useCaseInput.nomeVinil}");

            MemoryStream memoryStream = new MemoryStream();
            
            stream.CopyTo(memoryStream);
            
            return new IGetImagemVinilUseCaseOutput()
            {
                nome = _useCaseInput.nomeVinil,
                fileMemory = memoryStream
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}