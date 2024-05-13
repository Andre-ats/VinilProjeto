using VinilProjeto.Entity.VinilVenda;
using VinilProjeto.Repository.DTO.ValueObject.Vinil;
using VinilProjeto.UseCase.UseCaseInterfaces;

namespace VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;

public class ICadastrarVinilUseCaseInput : IUseCaseInput
{
    public string nomeVinil;
    public string descricaoVinil;
    public string listaMusica;
    public string precoVinil;
    public string quantiaVinil;
    public string UPC;
    public CaracteristicasPrincipaisDTO caracteristicasPrincipaisDto;
    public OutrasCaracteristicasDTO outrasCaracteristicasDto;
    public StatusVinil statusVinil;
}