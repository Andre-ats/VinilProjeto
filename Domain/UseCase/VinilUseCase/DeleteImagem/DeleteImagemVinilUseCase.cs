using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Repository.VinilRepository;

namespace VinilProjeto.UseCase.VinilUseCase.DeleteImagem;

public class DeleteImagemVinilUseCase : IDeleteImagemVinilUseCase
{
    public DeleteImagemVinilUseCase(IVinilRespository vinilRespository) : base(vinilRespository)
    {
    }

    protected override IDeleteImagemUseCaseOutput executeService(IDeleteImagemUseCaseInput _useCaseInput)
    {
        try
        {
            var vinil = _vinilRespository.getVinilByID(_useCaseInput.id);

            var imagemToRemove = new List<VinilImagem>(vinil.VinilImagem);
            
            foreach (var i in imagemToRemove)
            {
                if (i.fileName.Equals(_useCaseInput.fileName))
                {
                    vinil.VinilImagem.Remove(i);
                }
            }
            
            var path = $"{_useCaseInput.path}/vinil/{_useCaseInput.id}/{_useCaseInput.fileName}";
            
            _vinilRespository.updateVinil(vinil);

            return new IDeleteImagemUseCaseOutput()
            {
                mensagem = "Deletado com sucesso!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}