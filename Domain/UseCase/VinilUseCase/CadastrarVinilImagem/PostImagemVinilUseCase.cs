using VinilProjeto.Factory.Entity.VinilVenda;
using VinilProjeto.Repository.VinilRepository;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public class PostImagemVinilUseCase : IPostImagemVinilUseCase
{
    public PostImagemVinilUseCase(IVinilRespository _vinilRespository) : base(_vinilRespository)
    {
    }

    protected override IPostImagemVinilUseCaseOutput executeService(IPostImagemVinilUseCaseInput _useCaseInput)
    {

        var vinilImagem = new VinilImagemFactory()
            .setFileName(_useCaseInput.nome)
            .setHashName(_useCaseInput.hash)
            .setVinilId(_useCaseInput.vinilId)
            .build();
        
        _vinilRespository.postImagemVinil(vinilImagem);

        return new IPostImagemVinilUseCaseOutput()
        {
            mensagem = "Sucesso!"
        };

    }
}