using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.Service.FileService;

namespace VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;

public class GetTodosVinilUseCase : IGetTodosVinilUseCase
{
    public GetTodosVinilUseCase(IVinilRespository _vinilRespository) : base(_vinilRespository)
    {
    }

    protected override IGetTodosVinilUseCaseOutput executeService(IGetTodosVinilUseCaseInput _useCaseInput)
    {
        try
        {
            var output = new List<Vinil>();

            output = _vinilRespository.getTodosVinil() ??
                     throw new Exception("Erro ao buscar");
            

            return new IGetTodosVinilUseCaseOutput()
            {
                vinilList = output
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}