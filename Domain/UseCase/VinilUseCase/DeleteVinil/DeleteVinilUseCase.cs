using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.VinilUseCase.DeleteImagem;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteVinil;

public class DeleteVinilUseCase : IDeleteVinilUseCase
{
    public DeleteVinilUseCase(IVinilRespository vinilRespository) : base(vinilRespository)
    {
    }

    protected override IDeleteVinilUseCaseOutput executeService(IDeleteVinilUseCaseInput _useCaseInput)
    {
        try
        {
            var vinil =_vinilRespository.getVinilByID(_useCaseInput.vinilId);
        
            _vinilRespository.deleteVinilCascade(vinil);

            return new IDeleteVinilUseCaseOutput()
            {
                mensagem = "Vinil Deletado com sucesso"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}