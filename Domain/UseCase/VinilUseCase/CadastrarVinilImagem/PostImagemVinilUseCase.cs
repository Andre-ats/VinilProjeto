using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Factory.Entity.VinilVenda;
using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.Service.FileService;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public class PostImagemVinilUseCase : IPostImagemVinilUseCase
{
    public PostImagemVinilUseCase(IVinilRespository _vinilRespository) : base(_vinilRespository)
    {
    }

    protected override IPostImagemVinilUseCaseOutput executeService(IPostImagemVinilUseCaseInput _useCaseInput)
    {
        var vinil = _vinilRespository.getVinilByID(_useCaseInput.vinilId);
        
        var vinilImagem = new VinilImagemFactory()
            .setFileName(_useCaseInput.nome)
            .setVinilId(_useCaseInput.vinilId)
            .build();

        var adicionarImagemVinil = vinil.adicionarVinilImagem(vinilImagem);
        _vinilRespository.updateVinil(adicionarImagemVinil);
        
        new FileService().saveImagemService($"{_useCaseInput.path}/vinil/{_useCaseInput.vinilId}/{_useCaseInput.nome}", _useCaseInput.Stream);
   

        return new IPostImagemVinilUseCaseOutput()
        {
            mensagem = $"Sucesso! {_useCaseInput.path} {_useCaseInput.Stream}"
        };

    }
}