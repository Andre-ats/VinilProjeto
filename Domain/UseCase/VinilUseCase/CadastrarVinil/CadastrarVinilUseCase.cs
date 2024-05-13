using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Factory.Entity.VinilVenda;
using VinilProjeto.Factory.ValueObject.Vinil;
using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.ValueObject.Vinil;

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
                .setListaMusica(_useCaseInput.listaMusica)
                .setUPC(_useCaseInput.UPC)
                .setCaracteristicasPrincipais(new CaracteristicasPrincipaisFactory()
                    .setNomeArtista(_useCaseInput.caracteristicasPrincipaisDto.nomeArtista)
                    .setGravadora(_useCaseInput.caracteristicasPrincipaisDto.gravadora)
                    .setAnoLancamento(_useCaseInput.caracteristicasPrincipaisDto.anoLancamento)
                    .setTipoAlbum(_useCaseInput.caracteristicasPrincipaisDto.tipoDeAlbum)
                    .setTipoDeEmbalagem(_useCaseInput.caracteristicasPrincipaisDto.tipoDeEmbalagem)
                    .build()
                )
                .setOutrasCaracteristicas(new OutrasCaracteristicasFactory()
                    .setEstiloMusical(_useCaseInput.outrasCaracteristicasDto.estiloMusical)
                    .setQuantiaCancoes(_useCaseInput.outrasCaracteristicasDto.quantiaCancoes)
                    .build()
                )
                .setStatusVinil(_useCaseInput.statusVinil)
                .setVinilImagem(new List<VinilImagem>())
                .build();

            _ = _vinilRespository.createVinil(vinil)
                ? true
                : throw new Exception("Erro na criacao do vinil");
            
            return new ICadastrarVinilUseCaseOutput()
            {
                vinilId = vinil.id
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}