using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Factory.Entity.VinilVenda;
using VinilProjeto.Repository.VinilRepository;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public class CadastrarVinilUseCase : ICadastrarVinilUseCase
{
    public CadastrarVinilUseCase(IVinilRespository vinilRespository) : base(vinilRespository)
    {
    }

    protected override ICadastrarVinilUseCaseOutput executeService(ICadastrarVinilUseCaseInput _useCaseInput)
    {
        try
        {
            Vinil vinil = new VinilVendaFactory()
                .setNomeVinil(_useCaseInput.nomeVinil)
                .setDescricaoVinil(_useCaseInput.descricaoVinil)
                .setPrecoVinil(_useCaseInput.precoVinil)
                .setQuantiaVinil(_useCaseInput.quantiaVinil)
                .setEstiloMusical(_useCaseInput.estiloMusical)
                .setStatusVinil(_useCaseInput.statusVinil)
                .setVinilImagem(new List<VinilImagem>())
                .build();

            _ = _vinilRespository.createVinil(vinil)
                ? true
                : throw new Exception("Erro na criacao do vinil");
            
            return new ICadastrarVinilUseCaseOutput()
            {
                resposta = $"Vinil {vinil.nomeVinil} criado!"
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}